﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

public static class Program
{
    public async static Task Main(string[] args)
    {
        // Configure Chrome options
        var options = new ChromeOptions();
        //options.AddArgument("--headless"); // Run in headless mode
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/117.0.0.0 Safari/537.36";

        // Set up ChromeOptions
        options.AddArgument($"--user-agent={userAgent}");
        
        // Initialize WebDriver
        var driverPath = new DriverManager().SetUpDriver(new ChromeConfig());
        var driver = new ChromeDriver(driverPath);
        //
        // driver = webdriver.Chrome(executable_path=r'C:\path\to\chromedriver.exe')
        // driver.get('http://google.com/')
        //     
        // Target URL
        string url = "https://www.latamairlines.com/br/pt";
        
        // Open the page
        driver.Navigate().GoToUrl(url);
        
        // Get the page title
        string title = driver.Title;

        // Print the page title
        Console.WriteLine($"Page Title: {title}");
        
        ClickElementIfExists(driver, "cookies-politics-button");

        string origin_airport = "LDB";
        string destination_airport = "GRU";
        string search_url =
            $"https://www.latamairlines.com/br/pt/oferta-voos?origin={origin_airport}&inbound=2025-01-31T12%3A00%3A00.000Z&outbound=2025-01-01T12%3A00%3A00.000Z&destination={destination_airport}&adt=1&chd=0&inf=0&trip=RT&cabin=Economy&redemption=true&sort=RECOMMENDED";
        driver.Navigate().GoToUrl(search_url);        
        
         origin_airport = "GRU";
         destination_airport = "JFK";
         search_url =
            $"https://www.latamairlines.com/br/pt/oferta-voos?origin={origin_airport}&inbound=2025-01-31T12%3A00%3A00.000Z&outbound=2025-01-01T12%3A00%3A00.000Z&destination={destination_airport}&adt=1&chd=0&inf=0&trip=RT&cabin=Economy&redemption=true&sort=RECOMMENDED";
        driver.Navigate().GoToUrl(search_url);
        
        origin_airport = "LDB";
        destination_airport = "MCZ";
         search_url =
            $"https://www.latamairlines.com/br/pt/oferta-voos?origin={origin_airport}&inbound=2025-01-31T12%3A00%3A00.000Z&outbound=2025-01-01T12%3A00%3A00.000Z&destination={destination_airport}&adt=1&chd=0&inf=0&trip=RT&cabin=Economy&redemption=true&sort=RECOMMENDED";
        driver.Navigate().GoToUrl(search_url);
        //ClickElementIfExists(browser, "txtInputOrigin");
        //FillInput(browser, "txtInputOrigin_field", "Londrina");

        //browser.Quit();
    }

    private static void FillInput(ChromeDriver browser, string inputId, string inputValue)
    {
        try
        {
            IWebElement textBox = browser.FindElement(By.Id(inputId));
            
            // Enter text into the textbox
            textBox.Clear(); // Optional: Clears any existing text
            textBox.SendKeys(inputValue);

            Console.WriteLine($"Text '{inputValue}' entered on input '{inputId}' successfully");
        }
        catch (NoSuchElementException)
        {
            // Handle the case where the textbox is not found
            Console.WriteLine($"Textbox not found: '{inputId}'");
        }
    }

    private static void ClickElementIfExists(ChromeDriver browser, string buttonId)
    {
        try
        {
            // Locate the button by its ID
            IWebElement element = browser.FindElement(By.Id(buttonId));
            
            // Click the button if found
            element.Click();
            
            Console.WriteLine($"Element '{buttonId}' clicked successfully.");
        }
        catch (NoSuchElementException)
        {
            // Handle the case where the button is not found
            Console.WriteLine($"Element '{buttonId}' not found.");
        }
    }
}