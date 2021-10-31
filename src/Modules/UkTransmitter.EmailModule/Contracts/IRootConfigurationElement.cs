namespace UkTransmitter.EmailModule.Contracts
{

    /// <summary>
    /// Интерфейс описывает корневой элемент Json файла конфигурации
    /// </summary>
    internal interface IRootConfigurationElement<T>
    {
        T CustomEmailSettings { get; }
    }
}
