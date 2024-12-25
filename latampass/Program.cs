using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

public static class Program
{
    public static void Main(string[] args)
    {
        // Configure Chrome options
        var options = new ChromeOptions();
        //options.AddArgument("--headless"); // Run in headless mode
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        
        // Initialize WebDriver
        var driver = new DriverManager().SetUpDriver(new ChromeConfig());
        var browser = new ChromeDriver(driver);
        //
        // driver = webdriver.Chrome(executable_path=r'C:\path\to\chromedriver.exe')
        // driver.get('http://google.com/')
        //     
        // Target URL
        string url = "https://www.latamairlines.com/br/pt";
        
        // Open the page
        browser.Navigate().GoToUrl(url);
        
        // Get the page title
        string title = browser.Title;

        // Print the page title
        Console.WriteLine($"Page Title: {title}");
        
        ClickButtonIfExists(browser, "cookies-politics-button");
        FillInput(browser, "txtInputOrigin_field", "Londrina");
        
        //browser.Quit();
    }

    private static void FillInput(ChromeDriver browser, string inputId, string inputValue)
    {
        try
        {
            // Locate the textbox by its ID
            IWebElement textBox = browser.FindElement(By.Id(inputId));

            // Enter text into the textbox
            //textBox.Clear(); // Optional: Clears any existing text
            textBox.SendKeys(inputValue);

            Console.WriteLine($"Text '{inputValue}' entered on input '{inputId}' successfully");
        }
        catch (NoSuchElementException)
        {
            // Handle the case where the textbox is not found
            Console.WriteLine($"Textbox not found: '{inputId}'");
        }

    }

    private static void ClickButtonIfExists(ChromeDriver browser, string buttonId)
    {
        try
        {
            // Locate the button by its ID
            IWebElement cookiesButton = browser.FindElement(By.Id(buttonId));
            
            // Click the button if found
            cookiesButton.Click();
            
            Console.WriteLine($"Button '{buttonId}' clicked successfully.");
        }
        catch (NoSuchElementException)
        {
            // Handle the case where the button is not found
            Console.WriteLine($"Button '{buttonId}' not found.");
        }
    }
}