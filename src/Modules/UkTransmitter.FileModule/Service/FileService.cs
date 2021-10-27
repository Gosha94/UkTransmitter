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
        public ILogService LogService { get; private set; }

        #endregion

        #region Constructor

        public FileService(IAttachmentConfiguration attachConfigFromDi, ILogService logServiceFromDi)
        {

            #region Dependency Injection

            this.AttachmentConfiguration = attachConfigFromDi;
            this.LogService = logServiceFromDi;

            #endregion

            this._dataForFillTemplateDto = new DataForFillTemplateDto()
            {
                PathNewAttachmentFile = this.AttachmentConfiguration.PathToAttachmentsCatalog,
                ReceivedFromUserMeteringDataArray = new string[] {"1_2_3","4_5_6","7_8_9","10_11_12"}
            };

            this._legacyWordSaver = new LegacyWordSaver(this._dataForFillTemplateDto, , this.AttachmentConfiguration);

        }

        public void AttachmentExistHandler()
        {
            
        }

        public void DirectoryWasCreatedHandler()
        {
            
        }

        #endregion

        #region Public API

        #endregion

        #region Private Methods

        #endregion

    }
}