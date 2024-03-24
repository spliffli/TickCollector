using TradingApis;
using TradingApis.Common;
using TradingApis.Common.Loggers;

namespace TickCollector;

internal class TickCollector
{
    private readonly Logger _logger;
    private readonly IList<TradingSessionController> _sessionControllers;

    private TickCollector()
    {
        _logger = new ConsoleLogger();
        _logger.Log("TickCollector initialized without passing a Logger, so defaulting to ConsoleLogger.");

        _sessionControllers = null!; 
    }

    private TickCollector(Logger logger)
    {
        _logger = logger;

        _sessionControllers = null!;
    }

    public TickCollector(IList<TradingSessionController> sessionControllers)
        : this()
    {
        _sessionControllers = sessionControllers;
    }

    public TickCollector(IList<TradingSessionController> sessionControllers, Logger logger)
        : this(logger)
    {
        _sessionControllers = sessionControllers;
    }

    public TickCollector(TradingSessionController sessionController)
        : this()
    {
        var sessionControllers = new List<TradingSessionController>();
        sessionControllers.Add(sessionController);
        _sessionControllers = sessionControllers;
    }

    public TickCollector(TradingSessionController sessionController, Logger logger)
        : this(sessionController)
    {
        _logger = logger;
    }

    public void Start()
    {
        foreach (var sessionController in _sessionControllers)
        {
            sessionController.StartThread();
        }
    }
}