using UkTransmitter.Core.Contracts;
using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.FileModule.Service
{

    /// <summary>
    /// Служба по работе с файловой системой
    /// </summary>
    public sealed class FileService : IFileService
    {

        public IAttachmentConfiguration AttachmentConfiguration { get; private set; }
        public ILogService LogService { get; private set; }


        #region Constructor

        public FileService(IAttachmentConfiguration attachConfigFromDi, ILogService logServiceFromDi)
        {
            this.AttachmentConfiguration = attachConfigFromDi;
            this.LogService = logServiceFromDi;
        }

        #endregion

        #region Public API

        #endregion

        #region Private Methods

        #endregion

    }
}