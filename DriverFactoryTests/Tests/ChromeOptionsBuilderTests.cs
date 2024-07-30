using DriverFactory;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DriverFactoryTests;

[TestFixture]
public class ChromeOptionsBuilderTests
{
    private ChromeOptionsBuilder? _chromeOptionsBuilder;

    [SetUp]
    public void CreateBuilder()
    {
        _chromeOptionsBuilder = new ChromeOptionsBuilder();
    }

    [Test]
    public void ChromeOptionsBuilder_SetHeadless()
    {
        //var chromeOptionsBuilder = new ChromeOptionsBuilder();

        _chromeOptionsBuilder?.SetHeadless();
        var newOptions = _chromeOptionsBuilder?.Get<ChromeOptions>();

        Assert.That(newOptions?.Arguments, Has.Member("--headless"));
    }

    [Test]
    public void ChromeOptionsBuilder_MaximizeScreen()
    {
        // var chromeOptionsBuilder = new ChromeOptionsBuilder();
        _chromeOptionsBuilder?.MaximizeScreen();
        var newOptions = _chromeOptionsBuilder?.Get<ChromeOptions>();

        Assert.That(newOptions?.Arguments, Has.Member("--start-maximized"));
    }

    [Test]
    public void ChromeOptionsBuilder_Multiple()
    {
        var newOptions = _chromeOptionsBuilder?
        .SetHeadless()
        .MaximizeScreen()
        .Get<ChromeOptions>();

        Assert.That(newOptions?.Arguments, Has.All.Matches<string>(arg =>
        arg == "--headless" || arg == "--start-maximized"));
    }

    [Test]
    public void ChromeOPtionsBuilder_InvalidCast()
    {
        Assert.Throws<InvalidCastException>(() =>{
            var newOptions = _chromeOptionsBuilder?
            .Get<FirefoxOptions>();
        });
    }
}


