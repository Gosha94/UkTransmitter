using System;
using System.IO;
using System.Reflection;
using System.Text;
using UkTransmitter.Core.CommonModels.DTOs;
using UkTransmitter.Core.Contracts;
using Word = Microsoft.Office.Interop.Word;

namespace UkSender.FrontEnd.Workers
{

    /// <summary>
    /// Класс-сохранялка данных в шаблон Word
    /// </summary>
    public sealed class LegacyWordSaver
    {

        #region Private Fields

        private Word.Application _wordApp;
        private Word.Document _wordDocument;
        private Word.Bookmarks _wordBookmarks;
        private Word.Range _wordRange;
        private Word.Find _find;
        private Object _missingObj = Missing.Value;

        private DataForFillTemplateDto _dataForFillTemplateDto;
        private ITemplateConfiguration _templateConfig;
        private IAttachmentConfiguration _attachConfig;

        #endregion

        #region Public Properties

        public bool IsFileExist { get; private set; }
        public event Action AttachmentAlredyExistEvent;
        public event Action DirectoryWasCreatedEvent;

        #endregion

        #region Constructor

        public LegacyWordSaver
            (
                DataForFillTemplateDto dataForFillTemplateDtofromOutside,
                ITemplateConfiguration templateConfigFromDi,
                IAttachmentConfiguration attachConfigFromDi
            )
        {

            #region Dependency Injection

            this._templateConfig = templateConfigFromDi;
            this._attachConfig = attachConfigFromDi;

            #endregion

            this._dataForFillTemplateDto = dataForFillTemplateDtofromOutside;
        }

        #endregion

        #region Public Api

        /// <summary>
        /// Метод создает вложение на диске ПК
        /// </summary>
        public bool CreateAttachmentWithMeteringData()
        {
            var isFileSaved = false;

            CreateWordDirectory();
            FillingTemplateFromDtoLegacy();
            var combinedMontYearFileName = CombineCurrentMonthAndYearForAttachmentFileName();
            SaveAttachmentLegacy
            (
                this._dataForFillTemplateDto.PathNewAttachmentFile,
                combinedMontYearFileName
            );
            ExitWordLegacy();
            
            isFileSaved = true;
            
            return isFileSaved;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод создает директорию, если она отсутствует
        /// </summary>
        private void CreateWordDirectory()
        {
            var pathForCreate = this._dataForFillTemplateDto.PathNewAttachmentFile;

            if ( CheckExistingDirectory() )
            {
                Directory.CreateDirectory(pathForCreate);
                DirectoryWasCreatedEvent?.Invoke();
            }
        }

        /// <summary>
        ///  Метод проверяет наличие созданной директории на диске
        /// </summary>
        private bool CheckExistingDirectory()
            => !Directory.Exists(this._dataForFillTemplateDto.PathNewAttachmentFile);

        /// <summary>
        /// Метод заполняет Шаблон Word данными из Dto объекта
        /// </summary>
        private void FillingTemplateFromDtoLegacy()
        {
            var pathNewFile         = this._dataForFillTemplateDto.PathNewAttachmentFile;
            var month               = this._dataForFillTemplateDto.CurrentDate.Month;
            var year                = this._dataForFillTemplateDto.CurrentDate.Year;
            var meteringDataArr     = this._dataForFillTemplateDto.ReceivedFromUserMeteringDataArray;

            // Создаём объект документа
            this._wordDocument = null;

            // Создаем объект Word - равносильно запуску Word
            this._wordApp = new Word.Application();

            // Делаем его невидимым
            this._wordApp.Visible = false;

            // Путь до шаблона документа
            string source = CombinePathToWordTemplate() + this._templateConfig.TemplateFileName;

            // Открываем шаблон как новый документ
            this._wordDocument = this._wordApp.Documents.Open(source);
            this._wordDocument.Activate();

            // Добавляем информацию
            // wBookmarks содержит все закладки
            this._wordBookmarks = this._wordDocument.Bookmarks;

            int i = 0;

            foreach (Word.Bookmark mark in this._wordBookmarks)
            {
                this._wordRange = mark.Range;
                this._wordRange.Text = meteringDataArr[i];
                i++;
            }

            this._find = _wordApp.Selection.Find;
            this._find.Text = this._templateConfig.TemplateDateTagName;
            this._find.Replacement.Text = DateTime.Today.ToString("d");
            this._find.Execute
                (
                    FindText: Type.Missing,
                    MatchCase: false,
                    MatchWholeWord: false,
                    MatchWildcards: false,
                    MatchSoundsLike: this._missingObj,
                    MatchAllWordForms: false,
                    Forward: true,
                    Wrap: Word.WdFindWrap.wdFindContinue,
                    Format: false,
                    ReplaceWith: this._missingObj,
                    Replace: Word.WdReplace.wdReplaceAll
                );
        }

        /// <summary>
        /// Метод формирует имя файла из текущих месяца и года (Пример: октябрь 2021 имеет вид 102021)
        /// </summary>
        /// <returns></returns>
        private string CombineCurrentMonthAndYearForAttachmentFileName()
            => new StringBuilder()
                .Append(this._dataForFillTemplateDto.CurrentDate.Month)
                .Append(this._dataForFillTemplateDto.CurrentDate.Year)
                .ToString();

        /// <summary>
        /// Метод комбинирует путь к каталогу с Шаблоном
        /// </summary>
        /// <returns>Путь к файлу Шаблона</returns>
        private string CombinePathToWordTemplate()
            => AppDomain.CurrentDomain.BaseDirectory + this._templateConfig.TemplateCatalogName;

        /// <summary>
        /// Метод сохраняет Документ Word по указанному пути
        /// </summary>
        /// <param name="path">Путь для сохранения файла Word</param>
        /// <param name="combinedMonthYearDate">Подготовленное имя файла Word, состоящее из месяца и года</param>
        private void SaveAttachmentLegacy(string path, string combinedMonthYearDate)
        {
            var monthYearDate = combinedMonthYearDate;
            var monthYearDateWithExtension = monthYearDate + this._attachConfig.AttachmentExtension;

            if ( File.Exists(path + monthYearDateWithExtension) )
            {
                this.IsFileExist = true;
                // TODO Залогировать это сообщение - MessageBox.Show("Файл с показаниями за текущий месяц уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.AttachmentAlredyExistEvent?.Invoke();
            }
            else
            {
                IsFileExist = false;
                Object pathToSaveObj = path + combinedMonthYearDate;
                this._wordDocument.SaveAs
                    (
                        ref pathToSaveObj,
                        Word.WdSaveFormat.wdFormatDocument,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj,
                        ref this._missingObj
                    );
            }
        }

        private void ExitWordLegacy()
        {

            this._wordApp.ActiveDocument.Close();
            Object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
            Object originalFormat = Word.WdOriginalFormat.wdWordDocument;
            Object routeDocument = Type.Missing;
            this._wordApp.Quit(ref saveChanges,
                         ref originalFormat,
                         ref routeDocument);
            this._wordApp = null;

        }

        #endregion

    }
}