using Serilog.Events;
using Serilog;

namespace Core.Api;

public static class CoreApi
{
    public static void FatalException(Exception ex)
    {
        var appSettingsFile = $"{Directory.GetCurrentDirectory()}/appsettings.json";
        var settingsJson = File.ReadAllText(appSettingsFile);
        var appSettings = System.Text.Json.JsonDocument.Parse(settingsJson);
        var logsPath = appSettings.RootElement.GetProperty("Logging").GetProperty("LogsFolder").GetString();
        var logger = new LoggerConfiguration()
            .WriteTo.File($"{logsPath}/Log-Run-Error-.txt", LogEventLevel.Error, rollingInterval: RollingInterval.Hour,
                retainedFileCountLimit: 30)
            .CreateLogger();
        logger.Fatal(ex.Message, ex);
    }
}
