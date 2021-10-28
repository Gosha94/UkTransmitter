using System;
using System.Globalization;

namespace UkSender.EmailAPI.Models
{
    /// <summary>
    /// Модель данных для отправки письма в УК через Gmail API
    /// </summary>
    internal sealed class GmailMessageModel
    {
        
        /// <summary>
        /// Тема письма
        /// </summary>
        public static string Subject { get; private set; } = "ЛС 012100000026 (34-К-1-0026)";

        /// <summary>
        /// Содержимое письма
        /// </summary>
        public static string Body { get; private set; } = $"Добрый день.\nВо вложении показания счетчиков по кв.26 за { DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("ru")) }";

        /// <summary>
        /// От кого
        /// </summary>
        public static string From { get; private set; } = "igeorg70@gmail.com";

        /// <summary>
        /// Кому, основной получатель
        /// </summary>
        public static string MainTo { get; private set; } = "larionov_zhora_94@mail.ru"; //9924107@mail.ru

        /// <summary>
        /// Копия, carbon copy, вторичный получатель письма
        /// </summary>
        public static string CopyTo { get; private set; } = "gerizch@rambler.ru";   //lik2193@gmail.com

        /// <summary>
        /// Вложение
        /// </summary>
        public static string Attachment { get; private set; }
        
        /// <summary>
        /// Id письма, выдается GmailApi после отправки
        /// </summary>
        public static string MessageId { get; private set; }

    }
}