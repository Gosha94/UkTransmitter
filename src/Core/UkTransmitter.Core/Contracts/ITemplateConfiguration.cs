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

        /// <summary>
        /// Свойство описывает имя каталога с Шаблоном
        /// </summary>
        string TemplateCatalogName { get; }

        /// <summary>
        /// Свойство описывает имя Тега в шаблоне Word, который программа заменяеи на текущую дату
        /// </summary>
        string TemplateDateTagName { get; }

    }
}
