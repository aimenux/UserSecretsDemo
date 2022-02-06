using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace App;

public class DummyService : IDummyService
{
    private readonly ILogger _logger;
    private readonly IOptions<Secrets> _options;

    public DummyService(ILogger logger, IOptions<Secrets> options)
    {
        _logger = logger;
        _options = options;
    }

    public Task RunAsync()
    {
        _logger.LogInformation($"{nameof(Secrets.Username)}: {_options.Value.Username}");
        _logger.LogInformation($"{nameof(Secrets.Password)}: {_options.Value.Password}");
        return Task.Delay(TimeSpan.FromSeconds(1));
    }
}