namespace UkTransmitter.Wpf.FrontEnd.Infrastructure
{
    /// <summary>
    /// Интерфейс для описания пользовательских моделей представления (View Models)
    /// </summary>
    internal interface ICustomViewModel
    {
        /// <summary>
        /// Заголовок представления
        /// </summary>
        string Title { get; }
    }
}
