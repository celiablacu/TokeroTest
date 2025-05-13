using Microsoft.Playwright;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokeroWinAppTests
{
    public partial class MainForm : Form
    {
        private string logText = "";
        private string baseUrl = "https://tokero.dev";

        public MainForm()
        {
            InitializeComponent();
            cmbBrowser.SelectedIndex = 0; // Default to Chromium
            txtBaseUrl.Text = baseUrl;
        }

        private async void installPlaywrightBrowsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AppendLog("[INFO] Installing Playwright browsers...");
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "playwright",
                    Arguments = "install",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (var process = System.Diagnostics.Process.Start(psi))
                {
                    string output = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();
                    process.WaitForExit();

                    AppendLog("[INFO] Playwright install output:");
                    AppendLog(output);
                    if (!string.IsNullOrWhiteSpace(error))
                        AppendLog("[ERROR] " + error);
                }

                AppendLog("[INFO] Playwright browsers installed.");
            }
            catch (Exception ex)
            {
                AppendLog("[ERROR] Failed to install browsers: " + ex.Message);
            }
        }


        private async void btnRunTests_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            logText = "";
            progressBar.Value = 0;
            baseUrl = txtBaseUrl.Text.Trim().TrimEnd('/');

            try
            {
                using var playwright = await Playwright.CreateAsync();
                IBrowser browser = null;
                string browserType = cmbBrowser.SelectedItem.ToString();

                switch (browserType)
                {
                    case "Chromium":
                        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
                        break;
                    case "Firefox":
                        browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
                        break;
                    case "WebKit":
                        browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
                        break;
                }

                var context = await browser.NewContextAsync();
                var page = await context.NewPageAsync();

                await RunTest(page, "Privacy Policy Page", async () =>
                {
                    await page.GotoAsync($"{baseUrl}/en/");
                    await page.ClickAsync("footer >> text=Privacy Policy");
                    var title = await page.TitleAsync();
                    return title.Contains("Privacy Policy");
                });

                progressBar.Value = 33;

                await RunTest(page, "Language Switch", async () =>
                {
                    await page.GotoAsync($"{baseUrl}/en/");
                    await page.ClickAsync("text=RO");
                    return page.Url.Contains("/ro");
                });

                progressBar.Value = 66;

                await RunTest(page, "Policy Links Check", async () =>
                {
                    await page.GotoAsync($"{baseUrl}/en/");
                    var links = await page.QuerySelectorAllAsync("footer a");
                    foreach (var link in links)
                    {
                        var href = await link.GetAttributeAsync("href");
                        if (href != null && href.Contains("/policy"))
                        {
                            var testPage = await context.NewPageAsync();
                            var response = await testPage.GotoAsync(baseUrl + href);
                            bool success = response?.Status == 200;
                            AppendLog($"{(success ? "[PASS]" : "[FAIL]")} Policy page: {href} - Status: {response?.Status}");
                            if (!success) await testPage.ScreenshotAsync(new PageScreenshotOptions { Path = $"policy_{href.Replace("/", "_")}.png" });
                            await testPage.CloseAsync();
                        }
                    }
                    return true;
                });

                progressBar.Value = 100;
                AppendLog("[INFO] All tests completed.");
            }
            catch (Exception ex)
            {
                AppendLog("[ERROR] " + ex.Message);
            }
        }

        private async Task RunTest(IPage page, string testName, Func<Task<bool>> testFunc)
        {
            AppendLog($"[TEST] {testName}");
            bool result = false;
            try
            {
                result = await testFunc();
                AppendLog(result ? $"[PASS] {testName}" : $"[FAIL] {testName}");
                if (!result)
                {
                    string screenshotName = $"{testName.Replace(" ", "_")}_fail.png";
                    await page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotName });
                    AppendLog($"[INFO] Screenshot saved: {screenshotName}");
                }
            }
            catch (Exception ex)
            {
                AppendLog($"[ERROR] {testName} threw an exception: {ex.Message}");
            }
        }

        private void AppendLog(string message)
        {
            txtLog.AppendText(message + Environment.NewLine);
            logText += message + Environment.NewLine;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Save Test Results"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, logText);
                MessageBox.Show("Test results saved.");
            }
        }
    }
}