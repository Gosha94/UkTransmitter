using System;

namespace UkTransmitter.Core.Contracts
{

    /// <summary>
    /// Интерфейс описывает ограниченный чтением данных репозиторий с данными из Контекста БД
    /// </summary>
    public interface IReadOnlyRepository<T> : IDisposable
        where T : class
    {

        /// <summary>
        /// Метод проверяет соответствие передаваемой модели с моделью в контексте БД
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        bool FindEqualModelInDatabase(T userModel);

    }
}