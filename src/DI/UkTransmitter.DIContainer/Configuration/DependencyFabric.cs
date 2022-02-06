using Services.UkTransmitter.LogService;
using Services.UkTransmitter.FileService;
using Services.UkTransmitter.AuthService;
using Services.UkTransmitter.EmailService;
using Services.UkTransmitter.SpeechService;
using UkTransmitter.Core.Contracts.Services;
using Autofac;

namespace UkTransmitter.DIContainer.Configuration
{

    /// <summary>
    /// Класс-контейнер для внедрения зависимостей (замены интерфейсов конкретными классами)
    /// </summary>
    public sealed class DependencyFabric
    {
        
        private ContainerBuilder _dependencyContainerBuilder;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DependencyFabric()
        {
            this._dependencyContainerBuilder = new ContainerBuilder();
        }

        #region Scopes Registrator

        /// <summary>
        /// Метод для регистрации всех зависимостей проекта
        /// </summary>
        public void RegisterAllScopesInApp()
        {
            _dependencyContainerBuilder.RegisterType<CustomAuthService>().As<IAuthService>();
            _dependencyContainerBuilder.RegisterType<CustomEmailService>().As<IEmailService>();
            _dependencyContainerBuilder.RegisterType<CustomFileService>().As<IFileService>();
            _dependencyContainerBuilder.RegisterType<CustomNLogService>().As<ILogService>();
            _dependencyContainerBuilder.RegisterType<SpeechService>().As<ISpeechService>();
        }

        #endregion

        #region Instanse Resolvers

        /// <summary>
        /// Метод получения экземпляра службы аутентификации
        /// </summary>
        /// <returns></returns>
        //public IAuthService GetAuthService()
        //    => this._dependencyContainerBuilder.Resolve<IAuthService>();


        /// <summary>
        /// Метод получения экземпляра почтовой службы
        /// </summary>
        /// <returns></returns>
        //public IEmailService GetEmailService()
        //    => this._dependencyContainerBuilder.Resolve<IEmailService>();

        /// <summary>
        /// Метод получения экземпляра файловой службы
        /// </summary>
        /// <returns></returns>
        //public IFileService GetFileService()
        //    => this._dependencyContainerBuilder.Resolve<IFileService>();


        /// <summary>
        /// Метод получения экземпляра службы логирования
        /// </summary>
        /// <returns></returns>
        //public ILogService GetLogService()
        //    => this._dependencyContainerBuilder.Resolve<ILogService>();


        /// <summary>
        /// Метод получения экземпляра голосовой службы
        /// </summary>
        /// <returns></returns>
        //public ISpeechService GetSpeechService()
        //    => this._dependencyContainerBuilder.Resolve<ISpeechService>();

        #endregion

    }
}
