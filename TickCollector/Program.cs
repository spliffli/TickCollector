using TradingApis;
using TradingApis.Common.Loggers;
using TradingApis.MetaTrader;

namespace TickCollector;
class Program
{
    static void Main(string[] args)
    {
        var logger = new FileLogger("log.txt", logToConsole: true);
        var config = new MTConfiguration("C:\\Users\\Jonathon\\source\\repos\\TickCollectionEngine\\TickCollectionEngine\\mt4ConfigExample.ini");
        var mt4EventHandler = new MTEventHandler(config, logger);
        var fpMarketsLiveSessionController = new MTSessionController(config, mt4EventHandler, logger);


        var tickCollector = new TickCollector(fpMarketsLiveSessionController, logger);
        tickCollector.Start();
    }
}