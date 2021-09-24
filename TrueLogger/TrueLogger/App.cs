using System;

namespace TrueLogger
{
    public class App
    {
        private const int Cycles = 100;
        private const int MaxRnd = 3;

        private readonly Actions _actions;
        private readonly IConfigService _configService;
        private readonly ILoggerService _loggerService;

        private readonly Random _rnd = new Random();

        public App(
            IConfigService configService,
            ILoggerService loggerService,
            Actions actions)
        {
            _actions = actions;
            _configService = configService;
            _loggerService = loggerService;
        }

        public void Start()
        {
            RandomMethod();

            if (_configService.FilePath != null)
            {
                Console.WriteLine($"{Environment.NewLine}Log has been successfully written to \"{_configService.FilePath}\"{Environment.NewLine}");
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine}There is error occured! File \"{_configService.FilePath}\" not found!{Environment.NewLine}");
            }

            Console.ReadKey();
        }

        private void RandomMethod()
        {
            for (var i = 0; i < Cycles; i++)
            {
                try
                {
                    var rnd = _rnd.Next(MaxRnd) switch
                    {
                        0 => _actions.InfoLog(),
                        1 => _actions.WarningLog(),
                        2 => _actions.ErrorLog(),
                        _ => throw new ArgumentException(),
                    };
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine($"There is no such method: {ae.Message}!");
                }
                catch (BusinessException be)
                {
                    _loggerService.LogEventWarning($"Action got this custom Exception: {be.Message}!");
                }
                catch (Exception ex)
                {
                    _loggerService.LogEventError($"Action failed by a reason: {ex.Message}!");
                }
            }
        }
    }
}
