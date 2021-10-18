using NLog;
using NLog.Config;
using NLog.Targets;
using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.LogModule.Service
{

    /// <summary>
    /// Служба для логирования работы приложения
    /// </summary>
    public sealed class LogService : ILogService
    {

        private LoggingConfiguration _logConfig;

        #region Constructor

        public LogService()
        {
            SetUpNLogConfiguration();
            
        }

        #endregion

        #region Public API

        // TODO Ситуации для логирования
        //LogWriter.LogWrite("Структура модели БД изменена, просьба проверить поля таблиц, сущности в коде.", "log.txt");
        //LogWriter.LogWrite(" Данные для отправки email получены из БД.", "log.txt");
        //LogWriter.LogWrite("Ошибка выполнения запроса в MSSQL, просьба проверить поля таблиц, сущности в коде.", "log.txt");
        //LogWriter.LogWrite("Неизвестная ошибка при получении учетных данных Email из БД!", "log.txt");
        //LogWriter.LogWrite("Показания счетчиков успешно записаны в БД.", "log.txt");
        //LogWriter.LogWrite("Проблема с БД показаний счетчиков, данные не добавлены.", "log.txt");
        //LogWriter.LogWrite("Показания счетчиков для графиков получены из БД.", "log.txt");
        //LogWriter.LogWrite("Дата сдачи показаний счетчиков считана из БД.", "log.txt");

        /// <summary>
        /// Запись логов
        /// </summary>
        /// <param name="message"></param>
        internal static void LogWrite(string message, string pathFile)
        {
            using (var log = File.AppendText(pathFile))
            {
                log.WriteLine($"\n{DateTime.Now.ToString()}: { message }");
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод настраивает службу логирования
        /// </summary>
        private void SetUpNLogConfiguration()
        {
            this._logConfig = new LoggingConfiguration();

            var logfile = new FileTarget("logfile") { FileName = "file.txt" };
            var logconsole = new ConsoleTarget("logconsole");
            
            this._logConfig.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            this._logConfig.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            LogManager.Configuration = this._logConfig;
        }

        #endregion

    }
}
