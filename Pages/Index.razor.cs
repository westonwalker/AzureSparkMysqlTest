using Microsoft.AspNetCore.Components;
using Spark.Library.Logging;
using ILogger = Spark.Library.Logging.ILogger;

namespace MyAppTestVite.Pages;

public partial class Index
{
    [Inject]
    public ILogger Logger { get; set; } = default!;

    protected override void OnInitialized()
    {
        Logger.Information($"Initialized at {DateTime.Now}");
    }
}
