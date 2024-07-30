using OpenQA.Selenium.Chrome;

namespace DriverFactory;

public class ChromeOptionsBuilder : iDriverOptions
{
    private ChromeOptions _chromeOptions;

    public ChromeOptionsBuilder()
    {
        _chromeOptions = new ChromeOptions();
    }

    public T Get<T>() where T : class
    {
        if(typeof(T) == typeof(ChromeOptions))
        {
            return _chromeOptions as T ?? throw new NullReferenceException("chrome options can't be null");
        }
        throw new InvalidCastException("must be cast as ChromeOptions");
    }

    public iDriverOptions MaximizeScreen()
    {
        _chromeOptions.AddArgument("--start-maximized");
        return this;
    }

    public iDriverOptions SetHeadless()
    {
        _chromeOptions.AddArgument("--headless");
        return this;
    }
}