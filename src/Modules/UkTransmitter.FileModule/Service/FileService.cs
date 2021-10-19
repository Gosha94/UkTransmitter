using UkTransmitter.Core.ModuleContracts;

namespace UkTransmitter.FileModule.Service
{
    /// <summary>
    /// Служба по работе с файловой системой
    /// </summary>
    public sealed class FileService : IFileService
    {
        public ILogService LogService { get; set; }

        #region Constructor
        
        public FileService()
        {

        }

        #endregion

        #region Public API

        #endregion

        #region Private Methods

        #endregion

    }
}
