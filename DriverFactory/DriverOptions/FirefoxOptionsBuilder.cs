using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DriverFactory;

public class FirefoxOptionsBuilder : iDriverOptions
{
    private FirefoxOptions _firefoxOptions;

    public FirefoxOptionsBuilder()
    {
        _firefoxOptions = new FirefoxOptions();
    }

    public T Get<T>() where T : class
    {
        if(typeof(T) == typeof(FirefoxOptions))
        {
            return _firefoxOptions as T ?? throw new NullReferenceException("firefox options can't be null");
        }
        throw new InvalidCastException("must be cast as FirefoxOptions");
    }

    public iDriverOptions MaximizeScreen()
    {
        _firefoxOptions.AddArgument("--start-maximized");
        return this;
    }

    public iDriverOptions SetHeadless()
    {
        _firefoxOptions.AddArgument("--headless");
        return this;
    }
}