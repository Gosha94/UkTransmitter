namespace UkSender.DAL.DataAccess
{
    public static class DbLoader
    {
        
        #region Свойство строки подключения

        //private static string _postgreConnectionString;
        //public static string PostgreConnectionString
        //{
        //    get => _postgreConnectionString;
        //    set { _postgreConnectionString = value; }
        //}

        #endregion

        #region Публичные Задачи        

        //public static ConnectionStringModel GetConnectStringFromDb(string connectName)
        //    => Task<ConnectionStringModel>.Run( GetConnectStringFromDbTask(connectName) );

        //public static List<UserAuthorizeModel> GetAllUserDataFromPostgre()

        #endregion

        #region GET методы для выборки из БД

        /// <summary>
        /// Метод получения данных авторизации пользователей из БД
        /// </summary>
        /// <returns></returns>
        //public static List<ReadableUserAuthorizeModel> GetAllUserDataFromDb()
        //{
        //    try
        //    {
        //        using (MeteringDataContext db = new MeteringDataContext())
        //        {
        //            //db.Database.Connection.Open();

        //            var result = db.UsersAuthorizeData.ToList();

        //            if (result is null)
        //            {
        //                return new List<ReadableUserAuthorizeModel>();
        //            }
        //            else
        //            { return result; }
        //        }
        //    }
        //    catch (EntityCommandExecutionException)
        //    {
        //        //LogWriter.LogWrite("Ошибка выполнения запроса в MSSQL, просьба проверить поля таблиц, сущности в коде.", "log.txt");
        //        return new List<ReadableUserAuthorizeModel>()
        //        {
        //            new ReadableUserAuthorizeModel()
        //            {
        //                Id    = 0,
        //                Login = "Error",
        //                Pwd   = "Error"
        //            }
        //        };
        //    }
        //}

        //public static ReadableEmailModel GetEmailDataFromDb()
        //{
        //    try
        //    {
        //        using (MeteringDataContext context = new MeteringDataContext())
        //        {
        //            var emailData = context.EmailData.First();
        //            //LogWriter.LogWrite(" Данные для отправки email получены из БД.", "log.txt");
        //            return emailData;
        //        }
        //    }
        //    catch (EntityCommandExecutionException)
        //    {
        //        //LogWriter.LogWrite("Структура модели БД изменена, просьба проверить поля таблиц, сущности в коде.", "log.txt");

        //        return new ReadableEmailModel()
        //        {
        //            Id = 1,
        //            FromAddress = "BqY4pvpeQHV5t0ozfiD+6WxOrRtncZrEYoW7jIZ5cWRfDQlVxj1FhcgrB5hVx6f6cL6Ga6jH4ro3dlfvBcVD",
        //            FromName = "S0zv+oV4Lhp1W+jbgQ1dOxe5DHm7wSFnCmhzl341vSpWhNRtKFSQ7zSS3OA4W84=",
        //            Lg = "kfKmThCSHb9y/oaDg/q86HOwCjZLpLC7IuX5pZKhaQ==",
        //            Pw = "AVyctX7ODC9WCr6c+WuyTyGJx+hs4VQXT+VyUSRSpXRfxdkuS4y1m17thJ7tF/o=",
        //            SecondToAddress = "RgJTCAno+9NTrVtF+1gRQURubefPy//U6Wrqm4nLJNARdYo+JRm6HfB3Giacy2M=",
        //            SubjectPiece = "03MOKF3k8sDey17gww30bPGZ95rGjcvL+FX3nbLKZa7zKje8s7hcAuNwgkxDtp4=",
        //            ToAddress = "RN0Fj8sg4TDC15X5OX3rdX+WFfYnYzLjoBDtDxz1MZdVFZnFSV72cuiFK8fCenI="
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        //LogWriter.LogWrite("Неизвестная ошибка при получении учетных данных Email из БД!", "log.txt");

        //        return new ReadableEmailModel()
        //        {
        //            Id = 1,
        //            FromAddress = "BqY4pvpeQHV5t0ozfiD+6WxOrRtncZrEYoW7jIZ5cWRfDQlVxj1FhcgrB5hVx6f6cL6Ga6jH4ro3dlfvBcVD",
        //            FromName = "S0zv+oV4Lhp1W+jbgQ1dOxe5DHm7wSFnCmhzl341vSpWhNRtKFSQ7zSS3OA4W84=",
        //            Lg = "kfKmThCSHb9y/oaDg/q86HOwCjZLpLC7IuX5pZKhaQ==",
        //            Pw = "AVyctX7ODC9WCr6c+WuyTyGJx+hs4VQXT+VyUSRSpXRfxdkuS4y1m17thJ7tF/o=",
        //            SecondToAddress = "RgJTCAno+9NTrVtF+1gRQURubefPy//U6Wrqm4nLJNARdYo+JRm6HfB3Giacy2M=",
        //            SubjectPiece = "03MOKF3k8sDey17gww30bPGZ95rGjcvL+FX3nbLKZa7zKje8s7hcAuNwgkxDtp4=",
        //            ToAddress = "RN0Fj8sg4TDC15X5OX3rdX+WFfYnYzLjoBDtDxz1MZdVFZnFSV72cuiFK8fCenI="
        //        };
        //    }
        //}

        //public static List<WriteableMeteringDataModel> GetMeteringDataForGraph()
        //{
        //    try
        //    {
        //        using (MeteringDataContext selectCont = new MeteringDataContext())
        //        {
        //            var result = selectCont
        //                            .MeteringData
        //                            .ToList();
        //            //LogWriter.LogWrite("Показания счетчиков для графиков получены из БД.", "log.txt");
        //            return result;
        //        }
        //    }

        //    catch (NotSupportedException)
        //    {
        //        List<WriteableMeteringDataModel> errorData = new List<WriteableMeteringDataModel>()
        //        {
        //            new WriteableMeteringDataModel()
        //            {
        //                 MeteringDeviceType = 10,
        //                 Value = "-999",
        //                 CombineDtm = DateTime.MinValue,
        //                 SendDtm = DateTime.MinValue
        //            }
        //        };
        //       // LogWriter.LogWrite("Проблема с БД показаний счетчиков, проверьте структуру таблицы.", "log.txt");
        //        return errorData;
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public static WriteableMeteringDataModel GetLastSendDataToUkFromDbase()
        //{
        //    try
        //    {
        //        using (MeteringDataContext lastSendContext = new MeteringDataContext())
        //        {
        //            var maxDtm = lastSendContext
        //                            .MeteringData
        //                            .Max(x => x.SendDtm);
        //            //LogWriter.LogWrite("Дата сдачи показаний счетчиков считана из БД.", "log.txt");
        //            return new WriteableMeteringDataModel()
        //            {
        //                MeteringDeviceType = 100,
        //                Value = "999",
        //                SendDtm = DateTime.MinValue,
        //                CombineDtm = DateTime.MinValue
        //            };
        //        }

        //    }
        //    catch (EntityCommandExecutionException)
        //    {
        //        //LogWriter.LogWrite("Проблема получения из БД даты сдачи показаний, проверьте структуру таблицы.", "log.txt");
        //        return new WriteableMeteringDataModel()
        //        {
        //            MeteringDeviceType = 100,
        //            Value = "999",
        //            SendDtm = DateTime.MinValue,
        //            CombineDtm = DateTime.MinValue
        //        };
        //    }
        //}

        #endregion

        #region Insert методы

        //public static bool InsertMeteringDataToDbase(List<WriteableMeteringDataModel> meteringData)
        //{
        //    try
        //    {
        //        using (MeteringDataContext insertCont = new MeteringDataContext())
        //        {
        //            // Заполняем DbSet
        //            meteringData.ForEach(x => insertCont.MeteringData.Add(x));
        //            // Сохраняем изменения
        //            insertCont.SaveChanges();
        //            //LogWriter.LogWrite("Показания счетчиков успешно записаны в БД.", "log.txt");
        //            return true;
        //        }

        //    }
        //    catch (EntityCommandExecutionException)
        //    {
        //        //LogWriter.LogWrite("Проблема с БД показаний счетчиков, данные не добавлены.", "log.txt");
        //        return false;
        //    }
        //}

        #endregion

    }
}