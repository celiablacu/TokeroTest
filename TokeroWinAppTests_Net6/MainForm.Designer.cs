namespace TokeroWinAppTests
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnRunTests;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox cmbBrowser;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtBaseUrl;
        private System.Windows.Forms.Label lblBaseUrl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installPlaywrightBrowsersToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnRunTests = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cmbBrowser = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtBaseUrl = new System.Windows.Forms.TextBox();
            this.lblBaseUrl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installPlaywrightBrowsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();

            // 
            // btnRunTests
            // 
            this.btnRunTests.Location = new System.Drawing.Point(12, 30);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(150, 30);
            this.btnRunTests.TabIndex = 0;
            this.btnRunTests.Text = "Run Tests";
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // cmbBrowser
            // 
            this.cmbBrowser.FormattingEnabled = true;
            this.cmbBrowser.Items.AddRange(new object[] { "Chromium", "Firefox", "WebKit" });
            this.cmbBrowser.Location = new System.Drawing.Point(180, 35);
            this.cmbBrowser.Name = "cmbBrowser";
            this.cmbBrowser.Size = new System.Drawing.Size(121, 23);
            this.cmbBrowser.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(320, 30);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 30);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export Results";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblBaseUrl
            // 
            this.lblBaseUrl.Location = new System.Drawing.Point(12, 70);
            this.lblBaseUrl.Size = new System.Drawing.Size(80, 15);
            this.lblBaseUrl.Text = "Base URL:";
            // 
            // txtBaseUrl
            // 
            this.txtBaseUrl.Location = new System.Drawing.Point(90, 67);
            this.txtBaseUrl.Size = new System.Drawing.Size(480, 23);
            this.txtBaseUrl.Text = "https://tokero.dev";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 100);
            this.txtLog.Multiline = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(560, 250);
            this.txtLog.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 360);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(560, 23);
            this.progressBar.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installPlaywrightBrowsersToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // installPlaywrightBrowsersToolStripMenuItem
            // 
            this.installPlaywrightBrowsersToolStripMenuItem.Name = "installPlaywrightBrowsersToolStripMenuItem";
            this.installPlaywrightBrowsersToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.installPlaywrightBrowsersToolStripMenuItem.Text = "Install Playwright Browsers";
            this.installPlaywrightBrowsersToolStripMenuItem.Click += new System.EventHandler(this.installPlaywrightBrowsersToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(584, 401);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblBaseUrl);
            this.Controls.Add(this.txtBaseUrl);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.cmbBrowser);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnRunTests);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Tokero QA Test Runner";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}