using System;

namespace UkTransmitter.Core.Contracts
{

    /// <summary>
    /// Интерфейс описывает репозиторий с возможностью CRUD операций над данными в БД
    /// </summary>
    public interface IMeteringDataRepository<TModel> : IDisposable
        where TModel : class
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void Create(TModel item);

        /// <summary>
        /// Метод обновления данных в конкретной модели
        /// </summary>
        /// <param name="item">Модель данных для обновления</param>
        void Update(TModel item);

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