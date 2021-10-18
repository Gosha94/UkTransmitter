using System;

namespace UkTransmitter.Core.Contracts
{

    /// <summary>
    /// Интерфейс описывает репозиторий с возможностью CRUD операций над данными в БД
    /// </summary>
    public interface IWritableRepository<T> : IDisposable
        where T : class
    {

        /// <summary>
        /// Метод получения модели из БД по Id
        /// </summary>
        /// <param name="id">Идентификатор модели в БД</param>
        /// <returns>Модель данных</returns>
        T GetConcreteModelById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);

        /// <summary>
        /// Метод обновления данных в конкретной модели
        /// </summary>
        /// <param name="item">Модель данных для обновления</param>
        void Update(T item);

        /// <summary>
        /// Метод удаления данных в конкретной модели
        /// </summary>
        /// <param name="id">Модель данных для удаления</param>
        void Delete(int id);

        /// <summary>
        /// Метод сохранения данных в контексте БД
        /// </summary>
        void Save();

    }
}