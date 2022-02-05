using UkTransmitter.Core.Contracts;

namespace UkTransmitter.FileModule.Config
{
    
    public sealed class TemplateConfiguration : ITemplateConfiguration
    {

        private readonly string _templateFileName = "AttachmentTemplate.dot";
        private readonly string _templateCatalogName = "Templates\\";
        private readonly string _templateDateTagName = "@@todayDate";

        public string TemplateFileName { get => this._templateFileName; }

        public string TemplateCatalogName { get => this._templateCatalogName; }

        public string TemplateDateTagName { get => this._templateDateTagName; }

    }
}