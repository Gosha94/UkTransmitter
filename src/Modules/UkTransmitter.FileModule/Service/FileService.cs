using System.Threading.Tasks;
using UkSender.FrontEnd.Workers;
using UkTransmitter.Core.Contracts;
using UkTransmitter.Core.ModuleContracts;
using UkTransmitter.FileModule.Models;

namespace UkTransmitter.FileModule.Service
{

    /// <summary>
    /// Служба по работе с файловой системой
    /// </summary>
    public sealed class FileService : IFileService
    {

        #region Private Fields

        private LegacyWordSaver _legacyWordSaver;
        private DataForFillTemplateDto _dataForFillTemplateDto;

        #endregion

        #region Public Properties

        public IAttachmentConfiguration AttachmentConfiguration { get; private set; }
        public ITemplateConfiguration TemplateConfiguration { get; private set; }
        public ILogService LogService { get; private set; }

        #endregion

        #region Constructor

        public FileService(IAttachmentConfiguration attachConfigFromDi, ITemplateConfiguration templateConfigurationFromDi, ILogService logServiceFromDi)
        {

            #region Dependency Injection

            this.AttachmentConfiguration = attachConfigFromDi;

            this.TemplateConfiguration = templateConfigurationFromDi;

            this.LogService = logServiceFromDi;

            #endregion

            this._dataForFillTemplateDto = new DataForFillTemplateDto()
            {
                PathNewAttachmentFile = this.AttachmentConfiguration.PathToAttachmentsCatalog,
                ReceivedFromUserMeteringDataArray = new string[] {"1_2_3","4_5_6","7_8_9","10_11_12"}
            };

            this._legacyWordSaver = new LegacyWordSaver(this._dataForFillTemplateDto, this.TemplateConfiguration, this.AttachmentConfiguration);

            #region Subscribe On File Events

            this._legacyWordSaver.AttachmentAlredyExistEvent += AttachmentExistHandler;
            this._legacyWordSaver.DirectoryWasCreatedEvent += DirectoryWasCreatedHandler;

            #endregion

        }

        #endregion

        #region Public API

        /// <summary>
        /// Метод создает файл вложения на диске
        /// </summary>
        public bool CreateAttachment()
            => this._legacyWordSaver.CreateAttachmentWithMeteringData();

        /// <summary>
        /// Метод асинхронно создает файл вложения на диске
        /// </summary>
        public async Task<bool> CreateAttachmentAsync()
            => await Task.Run( () => this.CreateAttachment() );

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод-обработчик события существования вложения
        /// </summary>
        private void AttachmentExistHandler()
        {
            this.LogService.WriteIntoLog($"Попытка повторно сохранить файл с показаниями за текущий месяц! Имя файла: {_dataForFillTemplateDto.CurrentDate.Month}{_dataForFillTemplateDto.CurrentDate.Year}");
        }

        /// <summary>
        /// Метод-обработчик события создания директории
        /// </summary>
        private void DirectoryWasCreatedHandler()
        {
            this.LogService.WriteIntoLog($"Первая передача показаний в текущем месяце, директория создана: {_dataForFillTemplateDto.CurrentDate.Month}{_dataForFillTemplateDto.CurrentDate.Year}");
        }

        #endregion

    }
}