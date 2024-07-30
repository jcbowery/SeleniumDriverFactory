using DriverFactory;

namespace DriverFactoryTests;

[TestFixture]
public class DriverOptionsBuilderTests
{
    [Theory]
    [TestCase(true,true, new[] {"--headless","--start-maximized"})]
    [TestCase(true, false, new[] { "--headless" })]
    [TestCase(false, true, new[] { "--start-maximized" })]
    [TestCase(false, false, new string[] { })]
    public void TestDriverFactory_Chrome(bool headless, bool maximize, string[] expected)
    {
        var options = DriverOptionsBuilder.BuildAndGetChromeOptions(headless, maximize);
        var actualArguments = options.Arguments.ToArray();

        // Assert that the number of arguments matches
        Assert.That(actualArguments.Length, Is.EqualTo(expected.Length), "The number of arguments does not match.");

        // Assert that each argument in 'expected' is present in 'actualArguments'
        foreach (var arg in expected)
        {
            Assert.That(actualArguments, Contains.Item(arg), $"Argument '{arg}' is missing.");
        }

        // Assert that no extra arguments are present
        foreach (var arg in actualArguments)
        {
            Assert.That(expected, Contains.Item(arg), $"Unexpected argument '{arg}' found.");
        }
    }

    [Theory]
    [TestCase(true, true, new[] { "--headless", "--start-maximized" })]
    [TestCase(true, false, new[] { "--headless" })]
    [TestCase(false, true, new[] { "--start-maximized" })]
    public void TestDriverFactory_Firefox(bool headless, bool maximize, string[] expected)
    {
        // Build the Firefox options
        var options = DriverOptionsBuilder.BuildAndGetFirefoxOptions(headless, maximize);

        // Retrieve the arguments from the Firefox options
        var arguments = options.ToCapabilities().GetCapability("moz:firefoxOptions") as IDictionary<string, object>;
        var actualArguments = arguments?["args"] as IList<object>;

        // Convert actualArguments to a list of strings for easier comparison
        var actualArgumentsList = actualArguments?.Cast<string>().ToList() ?? new List<string>();

        // Assert that each argument in 'expected' is present in 'actualArguments'
        foreach (var arg in expected)
        {
            Assert.That(actualArgumentsList, Has.Member(arg), $"Argument '{arg}' is missing.");
        }

        // Assert that no extra arguments are present
        foreach (var arg in actualArgumentsList)
        {
            Assert.That(expected, Has.Member(arg), $"Unexpected argument '{arg}' found.");
        }
    }

    public void TestDriverFactory_Firefox_empty()
    {
        var options = DriverOptionsBuilder.BuildAndGetFirefoxOptions();
        var arguments = options.ToCapabilities().GetCapability("moz:firefoxOptions") as Dictionary<string, object>;
        var actualArguments = arguments?["args"] as List<object>;
        var count = actualArguments?.Count;
        Assert.That(count, Is.EqualTo(0));
    }

}