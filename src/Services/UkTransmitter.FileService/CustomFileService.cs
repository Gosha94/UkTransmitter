using System.Threading.Tasks;
using UkTransmitter.Core.Contracts;
using UkTransmitter.FileService.Legacy;
using UkTransmitter.Core.Contracts.Services;

namespace Services.UkTransmitter.FileService
{

    /// <summary>
    /// Служба по работе с файловой системой
    /// </summary>
    public sealed class CustomFileService : IFileService
    {

        #region Private Fields

        private LegacyWordSaver _legacyWordSaver;

        #endregion

        #region Public Properties

        public IAttachmentConfiguration AttachmentConfiguration { get; private set; }
        public ITemplateConfiguration TemplateConfiguration { get; private set; }
        public IDtoForFillAttachment DtoForFillAttachment { get; private set; }
        public ILogService LogService { get; private set; }

        #endregion

        #region Constructor

        public CustomFileService
            (
                IAttachmentConfiguration attachConfigFromDi,
                ITemplateConfiguration templateConfigurationFromDi,
                IDtoForFillAttachment dtoForFillAttachmentFromDi,
                ILogService logServiceFromDi
            )
        {

            #region Dependency Injection

            AttachmentConfiguration = attachConfigFromDi;

            TemplateConfiguration = templateConfigurationFromDi;

            DtoForFillAttachment = dtoForFillAttachmentFromDi;

            LogService = logServiceFromDi;

            #endregion

            _legacyWordSaver = new LegacyWordSaver(DtoForFillAttachment, TemplateConfiguration, AttachmentConfiguration);

            #region Subscribe On Legacy Word Saver Events

            _legacyWordSaver.AttachmentAlredyExistEvent += AttachmentExistHandler;
            _legacyWordSaver.DirectoryWasCreatedEvent += DirectoryWasCreatedHandler;

            #endregion

        }

        #endregion

        #region Public API
        
        public string CreateAttachment()
            => this._legacyWordSaver.CreateAttachmentWithMeteringData();
        
        public async Task<string> CreateAttachmentAsync()
            => await Task.Run( () => CreateAttachment() );

        #endregion

        #region Private Methods

        /// <summary>
        /// Асинхронный метод-обработчик события существования вложения
        /// </summary>
        private void AttachmentExistHandler()
        {
            LogService.WriteLogAsync($"Попытка повторно сохранить файл с показаниями за текущий месяц! Имя файла: {DtoForFillAttachment.CurrentDate.Month}{DtoForFillAttachment.CurrentDate.Year}");
        }

        /// <summary>
        /// Асинхронный метод-обработчик события создания директории
        /// </summary>
        private void DirectoryWasCreatedHandler()
        {
            LogService.WriteLog($"Первая передача показаний в текущем месяце, директория создана: {DtoForFillAttachment.CurrentDate.Month}{DtoForFillAttachment.CurrentDate.Year}");
        }

        #endregion

    }
}