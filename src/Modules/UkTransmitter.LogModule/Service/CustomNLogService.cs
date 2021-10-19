using NLog;
using NLog.Config;
using NLog.Targets;
using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.LogModule.Service
{

    /// <summary>
    /// Служба для логирования работы приложения
    /// </summary>
    public sealed class CustomNLogService : ILogService
    {
        private static Logger _loggerStaticInstance = LogManager.GetCurrentClassLogger();

        #region Constructor

        public CustomNLogService()
        {
            SetUpNLogConfiguration();
        }

        #endregion

        #region Public API

        public void WriteIntoLog(string message)
        {
            _loggerStaticInstance.Debug(message);

            /* TODO Ситуации для логирования
                LogWriter.LogWrite("Структура модели БД изменена, просьба проверить поля таблиц, сущности в коде.", "log.txt");
                LogWriter.LogWrite(" Данные для отправки email получены из БД.", "log.txt");
                LogWriter.LogWrite("Ошибка выполнения запроса в MSSQL, просьба проверить поля таблиц, сущности в коде.", "log.txt");
                LogWriter.LogWrite("Неизвестная ошибка при получении учетных данных Email из БД!", "log.txt");
                LogWriter.LogWrite("Показания счетчиков успешно записаны в БД.", "log.txt");
                LogWriter.LogWrite("Проблема с БД показаний счетчиков, данные не добавлены.", "log.txt");
                LogWriter.LogWrite("Показания счетчиков для графиков получены из БД.", "log.txt");
                LogWriter.LogWrite("Дата сдачи показаний счетчиков считана из БД.", "log.txt");
            */
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод настраивает службу логирования
        /// </summary>
        private void SetUpNLogConfiguration()
        {
            var loggerConfig = new LoggingConfiguration();

            var fileTarget = new FileTarget("logfile")
            {
                FileName = "file.txt"
            };

            var consoleTarget = new ConsoleTarget
            {
                Name = "console",
                Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}",
            };

            loggerConfig.AddRule(LogLevel.Debug, LogLevel.Fatal, fileTarget, "*");
            loggerConfig.AddRule(LogLevel.Info, LogLevel.Fatal, consoleTarget, "*");

            LogManager.Configuration = loggerConfig;
        }

        #endregion

    }
}