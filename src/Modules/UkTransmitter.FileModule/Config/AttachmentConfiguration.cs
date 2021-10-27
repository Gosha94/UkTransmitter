using System;
using UkTransmitter.Core.Contracts;

namespace UkTransmitter.FileModule.Config
{

    /// <summary>
    /// Класс-конфигурация файла для отправки в УК
    /// </summary>
    internal sealed class AttachmentConfiguration : IAttachmentConfiguration
    {

        private string _applicationStartDirectory;

        private readonly string _mainCatalogName = "MeteringData\\";
        private readonly string _attachCatalogName = "Attachments\\";
        private readonly string _attachExtension = ".doc";

        #region Public Properties

        public string PathToMainCatalog { get; private set; }

        public string PathToAttachmentsCatalog { get; private set; }

        public string AttachmentExtension { get => this._attachExtension; }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public AttachmentConfiguration()
        {
            SetPathsFromStaticConfig();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод настройки конфигурации
        /// </summary>
        private void SetPathsFromStaticConfig()
        {

            this._applicationStartDirectory = AppDomain.CurrentDomain.BaseDirectory;

            this.PathToMainCatalog = this._applicationStartDirectory + this._mainCatalogName;
            this.PathToAttachmentsCatalog = this.PathToMainCatalog + this._attachCatalogName;

        }

        #endregion

    }
}