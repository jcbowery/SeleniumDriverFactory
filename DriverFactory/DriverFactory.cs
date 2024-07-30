using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace DriverFactory;

public static class DriverFactory
{
    public static IWebDriver GetWebDriver(
        BrowserType browserType,
        string url, 
        bool remote = false, 
        bool headless = false, 
        bool maximize = false
        )
    {
        switch(browserType)
        {
            case BrowserType.Chrome:
                if (remote)
                {
                    return new RemoteWebDriver(new Uri(url),DriverOptionsBuilder.BuildAndGetChromeOptions(headless, maximize));
                }
                return new ChromeDriver(DriverOptionsBuilder.BuildAndGetChromeOptions(headless, maximize));
            case BrowserType.Firefox:
                if (remote)
                {
                    return new RemoteWebDriver(new Uri(url),DriverOptionsBuilder.BuildAndGetFirefoxOptions(headless, maximize));
                }
                return new FirefoxDriver(DriverOptionsBuilder.BuildAndGetFirefoxOptions(headless, maximize));
            default:
                throw new ArgumentException("Browser type not implemented yet");
        }
    }
}