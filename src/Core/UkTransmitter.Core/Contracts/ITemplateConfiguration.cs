namespace UkTransmitter.Core.Contracts
{

    /// <summary>
    /// Интерфейс описывает Конфигурацию Шаблона файла для заполнения показаниями
    /// </summary>
    public interface ITemplateConfiguration
    {
        /// <summary>
        /// Свойство описывает имя Шаблона Word для заполнения показаний
        /// </summary>
        string TemplateFileName { get; }
    }
}
