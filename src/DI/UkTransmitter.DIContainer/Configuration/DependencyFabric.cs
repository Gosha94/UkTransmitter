using Castle.Windsor;
using Castle.MicroKernel.Registration;
using UkTransmitter.LogModule.Service;
using UkTransmitter.AuthModule.Service;
using UkTransmitter.FileModule.Service;
using UkTransmitter.SpeechModule.Service;
using UkTransmitter.EmailModule.Service;
using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.DIContainer.Configuration
{

    /// <summary>
    /// Класс-контейнер для внедрения зависимостей (замены интерфейсов конкретными классами)
    /// </summary>
    public sealed class DependencyFabric
    {
        private WindsorContainer _dependencyContainer;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DependencyFabric()
        {
            this._dependencyContainer = new WindsorContainer();
        }

        #region Scopes Registrator

        /// <summary>
        /// Метод для регистрации всех зависимостей проекта
        /// </summary>
        public void RegisterAllScopesInApp()
        {
            this._dependencyContainer.Register(Component.For<IAuthService>().ImplementedBy<AuthService>());
            this._dependencyContainer.Register(Component.For<IEmailService>().ImplementedBy<EmailService>());
            this._dependencyContainer.Register(Component.For<IFileService>().ImplementedBy<FileService>());
            this._dependencyContainer.Register(Component.For<ILogService>().ImplementedBy<CustomNLogService>());
            this._dependencyContainer.Register(Component.For<ISpeechService>().ImplementedBy<SpeechService>());
        }

        #endregion

        #region Instanse Resolvers

        /// <summary>
        /// Метод получения экземпляра службы аутентификации
        /// </summary>
        /// <returns></returns>
        public IAuthService GetAuthService()
            => this._dependencyContainer.Resolve<IAuthService>();


        /// <summary>
        /// Метод получения экземпляра почтовой службы
        /// </summary>
        /// <returns></returns>
        public IEmailService GetEmailService()
            => this._dependencyContainer.Resolve<IEmailService>();

        /// <summary>
        /// Метод получения экземпляра файловой службы
        /// </summary>
        /// <returns></returns>
        public IFileService GetFileService()
            => this._dependencyContainer.Resolve<IFileService>();


        /// <summary>
        /// Метод получения экземпляра службы логирования
        /// </summary>
        /// <returns></returns>
        public ILogService GetLogService()
            => this._dependencyContainer.Resolve<ILogService>();


        /// <summary>
        /// Метод получения экземпляра голосовой службы
        /// </summary>
        /// <returns></returns>
        public ISpeechService GetSpeechService()
            => this._dependencyContainer.Resolve<ISpeechService>();

        #endregion

    }
}
