using System;

namespace TrueLogger
{
    public class App
    {
        private const int Cycles = 100;
        private const int MaxRnd = 3;

        private readonly IActionService _actionService;
        private readonly IConfigService _configService;
        private readonly IFileService _fileService;
        private readonly ILoggerService _loggerService;

        private readonly Random _rnd = new Random();

        public App(
            IActionService actionService,
            IConfigService configService,
            IFileService fileService,
            ILoggerService loggerService)
        {
            _actionService = actionService;
            _configService = configService;
            _fileService = fileService;
            _loggerService = loggerService;
        }

        public void Start()
        {
            EnvironmentPrepair();
            RandomMethod();

            Console.WriteLine($"{Environment.NewLine}Log has been successfully written to \"{_loggerService.Path}\"{Environment.NewLine}");
            Console.ReadKey();
        }

        private void EnvironmentPrepair()
        {
            _fileService.MakeDir(_configService.DirConfig.DirPath);
            _fileService.CleanDir(_configService.DirConfig.DirPath, _configService.DirConfig.DirSize);
        }

        private void RandomMethod()
        {
            for (var i = 0; i < Cycles; i++)
            {
                var rnd = _rnd.Next(MaxRnd);

                try
                {
                    switch (rnd)
                    {
                        case 0:
                            _actionService.InfoLog();
                            break;
                        case 1:
                            _actionService.WarningLog();
                            break;
                        case 2:
                            _actionService.ErrorLog();
                            break;
                        default:
                            throw new ArgumentException();
                    }
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
