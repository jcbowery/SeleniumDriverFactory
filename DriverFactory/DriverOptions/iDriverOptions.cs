namespace DriverFactory;

public interface iDriverOptions
{
    public T Get<T>() where T : class;

    public iDriverOptions SetHeadless();

    public iDriverOptions MaximizeScreen();
}