# TokeroWinAppTests

A Windows Forms application that runs automated Playwright tests on https://tokero.dev/en.

## ✅ Features
- Run functional tests with a button click
- Log test status in a text area
- Visual progress bar indicating test stages
- Uses Microsoft Playwright (Chromium) for UI automation

## 🧪 Test Scenarios
1. Navigate to "Privacy Policy" page and verify page title
2. Switch language from EN to RO and verify URL change
3. Parse and verify all footer links that lead to policy pages

## 🛠 Requirements
- .NET 6 SDK or higher
- Windows OS
- Internet connection
- Playwright CLI (for browser binaries): run `playwright install` once

## 🚀 Getting Started

1. Clone or unzip this project
2. Restore dependencies and build:
   ```
   dotnet restore
   dotnet build
   ```
3. Run the project:
   ```
   dotnet run
   ```

Or open the `.csproj` file in Visual Studio and click **Start**.

## 📦 Dependencies
- [Microsoft.Playwright](https://www.nuget.org/packages/Microsoft.Playwright)