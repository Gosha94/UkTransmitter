using System;
using System.IO;

namespace UkSender.CommonLibrary.Helpers
{
    /// <summary>
    /// Класс записывает логи (отправка письма для УК) в текстовый файл
    /// </summary>
    internal sealed class LogWriter
    {
#pragma warning disable CS0414 // Полю "LogWriter.fileForLogsName" присвоено значение, но оно ни разу не использовано.
        private string fileForLogsName = "log.txt";
#pragma warning restore CS0414 // Полю "LogWriter.fileForLogsName" присвоено значение, но оно ни разу не использовано.
        //private string 

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
    }
}
