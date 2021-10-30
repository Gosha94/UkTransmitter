using System.Threading.Tasks;
using UkSender.FrontEnd.Workers;
using UkTransmitter.Core.Contracts;
using UkTransmitter.Core.ModuleContracts;
using UkTransmitter.Core.CommonModels.DTOs;

namespace UkTransmitter.FileModule.Service
{

    /// <summary>
    /// Служба по работе с файловой системой
    /// </summary>
    public sealed class FileService : IFileService
    {

        #region Private Fields

        private LegacyWordSaver _legacyWordSaver;
        private DataForFillTemplateDto _dataForFillTemplateDtoStub;

        #endregion

        #region Public Properties

        public IAttachmentConfiguration AttachmentConfiguration { get; private set; }
        public ITemplateConfiguration TemplateConfiguration { get; private set; }
        public ILogService LogService { get; private set; }

        #endregion

        #region Constructor

        public FileService
            (
                IAttachmentConfiguration attachConfigFromDi,
                ITemplateConfiguration templateConfigurationFromDi,
                ILogService logServiceFromDi
            )
        {

            #region Dependency Injection

            this.AttachmentConfiguration = attachConfigFromDi;

            this.TemplateConfiguration = templateConfigurationFromDi;

            this.LogService = logServiceFromDi;

            #endregion

            this._dataForFillTemplateDtoStub = new DataForFillTemplateDto()
            {
                PathToNewAttachmentFile = this.AttachmentConfiguration.PathToAttachmentsCatalog,
                ReceivedFromUserMeteringDataArray = new string[] {"1_2_3","4_5_6","7_8_9","10_11_12"}
            };

            this._legacyWordSaver = new LegacyWordSaver(this._dataForFillTemplateDtoStub, this.TemplateConfiguration, this.AttachmentConfiguration);

            #region Subscribe On File Events

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
            this.LogService.WriteIntoLogAsync($"Попытка повторно сохранить файл с показаниями за текущий месяц! Имя файла: {_dataForFillTemplateDtoStub.CurrentDate.Month}{_dataForFillTemplateDtoStub.CurrentDate.Year}");
        }

        /// <summary>
        /// Асинхронный метод-обработчик события создания директории
        /// </summary>
        private void DirectoryWasCreatedHandler()
        {
            this.LogService.WriteIntoLogAsync($"Первая передача показаний в текущем месяце, директория создана: {_dataForFillTemplateDtoStub.CurrentDate.Month}{_dataForFillTemplateDtoStub.CurrentDate.Year}");
        }

        #endregion

    }
}