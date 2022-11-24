namespace AspnCoreMvcLogging.Logging;
public class CustomLogger : ILogger
{
    readonly string loggerName;
    readonly CustomLoggerProviderConfiguration loggerConfig;
    public CustomLogger(string name, CustomLoggerProviderConfiguration config)
    {
        loggerName = name;
        loggerConfig = config;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        throw new NotImplementedException();
    }
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        string message = string.Format("{0}: {1} - {2}", logLevel.ToString(), eventId.Id, formatter(state, exception));
        EscreverTextoNoArquivo(message);
    }
    private static void EscreverTextoNoArquivo(string message)
    {
        string caminhoArquivo = @"/home/marcelle/repository/Projetos/Extras/c-sharp/AspnCoreMvcLogging/Marcelle_Log.txt";
        using StreamWriter streamWriter = new(caminhoArquivo, true);
        streamWriter.WriteLine(message);
        streamWriter.Close();
    }

}