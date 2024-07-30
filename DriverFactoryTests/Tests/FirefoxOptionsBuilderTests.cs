using DriverFactory;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DriverFactoryTests;

[TestFixture]
public class FirefoxOptionsBuilderTests
{
    private FirefoxOptionsBuilder? _firefoxOptionsBuilder;

    [SetUp]
    public void CreateBuilder()
    {
        _firefoxOptionsBuilder = new FirefoxOptionsBuilder();
    }

    [Test]
    public void ChromeOptionsBuilder_SetHeadless()
    {
        _firefoxOptionsBuilder?.SetHeadless();
        var newOptions = _firefoxOptionsBuilder?.Get<FirefoxOptions>();

        var arguments = newOptions.ToCapabilities().GetCapability("moz:firefoxOptions") as IDictionary<string, object>;
        var args = arguments?["args"] as IList<object>;

        // Assert
        Assert.That(args, Has.Member("--headless"));
    }

    [Test]
    public void ChromeOptionsBuilder_MaximizeScreen()
    {
        _firefoxOptionsBuilder?.MaximizeScreen();
        var newOptions = _firefoxOptionsBuilder?.Get<FirefoxOptions>();

        var arguments = newOptions.ToCapabilities().GetCapability("moz:firefoxOptions") as IDictionary<string, object>;
        var args = arguments?["args"] as IList<object>;

        // Assert
        Assert.That(args, Has.Member("--start-maximized"));
    }

    [Test]
    public void ChromeOptionsBuilder_Multiple()
    {
        var newOptions = _firefoxOptionsBuilder?
        .SetHeadless()
        .MaximizeScreen()
        .Get<FirefoxOptions>();

        var arguments = newOptions.ToCapabilities().GetCapability("moz:firefoxOptions") as IDictionary<string, object>;
        var args = arguments?["args"] as IList<object>;

        Assert.That(args, Has.All.Matches<string>(arg =>
        arg == "--headless" || arg == "--start-maximized"));
    }

    [Test]
    public void ChromeOPtionsBuilder_InvalidCast()
    {
        Assert.Throws<InvalidCastException>(() =>{
            var newOptions = _firefoxOptionsBuilder?
            .Get<ChromeOptions>();
        });
    }
}


