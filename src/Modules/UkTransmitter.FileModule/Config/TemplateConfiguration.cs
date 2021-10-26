using UkTransmitter.Core.Contracts;

namespace UkTransmitter.FileModule.Config
{

    /// <summary>
    /// Класс-конфигурация 
    /// </summary>
    internal sealed class TemplateConfiguration : ITemplateConfiguration
    {

        private readonly string _templateFileName = "AttachmentTemplate.dot";

        public string TemplateFileName { get => this._templateFileName; }

    }
}