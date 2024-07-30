using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DriverFactory;

public static class DriverOptionsBuilder
{
    public static ChromeOptions BuildAndGetChromeOptions(bool headless = false, bool maximize = false)
    {
        var options = new ChromeOptionsBuilder();
        
        if (headless)
        {
            options.SetHeadless();
        }

        if (maximize)
        {
            options.MaximizeScreen();
        }

        return options.Get<ChromeOptions>();
    }

     public static FirefoxOptions BuildAndGetFirefoxOptions(bool headless = false, bool maximize = false)
    {
        var options = new FirefoxOptionsBuilder();
        
        if (headless)
        {
            options.SetHeadless();
        }

        if (maximize)
        {
            options.MaximizeScreen();
        }

        return options.Get<FirefoxOptions>();
    }
}