using System;

namespace UkTransmitter.Core.Contracts
{

    /// <summary>
    /// Интерфейс описывает абстракцию над данными пользователей в БД
    /// </summary>
    public interface IUsersRepository<TModel, TId> : IDisposable
        where TModel : class
    {

        /// <summary>
        /// Метод получения модели из БД по Id
        /// </summary>
        /// <param name="id">Идентификатор модели в БД</param>
        /// <returns>Модель данных</returns>
        TModel GetUserById(TId id);

        /// <summary>
        /// Метод проверяет соответствие передаваемой модели с моделью в контексте БД
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        bool FindUserByModel(TModel userModel);

    }
}