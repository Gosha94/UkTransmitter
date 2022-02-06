using NLog;
using NLog.Config;
using NLog.Targets;
using System.Threading.Tasks;
using UkTransmitter.Core.Contracts.Services;

namespace Services.UkTransmitter.LogService
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
        public void WriteLog(string message) => _loggerStaticInstance.Debug(message);

        /// <summary>
        /// Асинхронный метод записи сообщения в лог, без ожидания выполнения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task WriteLogAsync(string message) => Task.Run(() => WriteLog(message));

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
                FileName = "UkTransmitterLogs.txt"
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