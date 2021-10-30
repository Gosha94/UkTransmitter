using System.Threading.Tasks;
using UkTransmitter.Core.Contracts;
using UkTransmitter.FileModule.Legacy;
using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.FileModule.Service
{

    /// <summary>
    /// Служба по работе с файловой системой
    /// </summary>
    public sealed class FileService : IFileService
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

        public FileService
            (
                IAttachmentConfiguration attachConfigFromDi,
                ITemplateConfiguration templateConfigurationFromDi,
                IDtoForFillAttachment dtoForFillAttachmentFromDi,
                ILogService logServiceFromDi
            )
        {

            #region Dependency Injection

            this.AttachmentConfiguration = attachConfigFromDi;

            this.TemplateConfiguration = templateConfigurationFromDi;

            this.DtoForFillAttachment = dtoForFillAttachmentFromDi;

            this.LogService = logServiceFromDi;

            #endregion

            this._legacyWordSaver = new LegacyWordSaver(this.DtoForFillAttachment, this.TemplateConfiguration, this.AttachmentConfiguration);

            #region Subscribe On Legacy Word Saver Events

            this._legacyWordSaver.AttachmentAlredyExistEvent += AttachmentExistHandler;
            this._legacyWordSaver.DirectoryWasCreatedEvent += DirectoryWasCreatedHandler;

            #endregion

        }

        #endregion

        #region Public API
        
        public bool CreateAttachment()
            => this._legacyWordSaver.CreateAttachmentWithMeteringData();
        
        public async Task<bool> CreateAttachmentAsync()
            => await Task.Run( () => this._legacyWordSaver.CreateAttachmentWithMeteringData() );

        #endregion

        #region Private Methods

        /// <summary>
        /// Асинхронный метод-обработчик события существования вложения
        /// </summary>
        private void AttachmentExistHandler()
        {
            this.LogService.WriteIntoLogAsync($"Попытка повторно сохранить файл с показаниями за текущий месяц! Имя файла: {DtoForFillAttachment.CurrentDate.Month}{DtoForFillAttachment.CurrentDate.Year}");
        }

        /// <summary>
        /// Асинхронный метод-обработчик события создания директории
        /// </summary>
        private void DirectoryWasCreatedHandler()
        {
            this.LogService.WriteIntoLogAsync($"Первая передача показаний в текущем месяце, директория создана: {DtoForFillAttachment.CurrentDate.Month}{DtoForFillAttachment.CurrentDate.Year}");
        }

        #endregion

    }
}