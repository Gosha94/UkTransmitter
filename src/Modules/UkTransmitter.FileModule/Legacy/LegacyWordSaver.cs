using System;
using System.IO;
using System.Reflection;
using UkTransmitter.Core.Contracts;
using UkTransmitter.FileModule.Models;
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

            CreateWordDirectory();
            FillingTemplateFromDto();
            SaveDoc(pathNewFile, month);
            ExitWord();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод создает директорию, если она отсутствует
        /// </summary>
        /// <param name="isDirNotCreated"></param>
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
        private void FillingTemplateFromDto()
        {
            var pathNewFile         = this._dataForFillTemplateDto.PathNewAttachmentFile;
            var month               = this._dataForFillTemplateDto.CurrentDate.Month;
            var year                = this._dataForFillTemplateDto.CurrentDate.Year;
            var meteringDataArr     = this._dataForFillTemplateDto.ReceivedFromUserMeteringDataArray;

            // Создаём объект документа
            _wordDocument = null;

            // Создаем объект Word - равносильно запуску Word
            _wordApp = new Word.Application();
            
            // Делаем его невидимым
            _wordApp.Visible = false;

            // Путь до шаблона документа
            string source = CombinePathToWordTemplate() + this._templateConfig.TemplateFileName;

            // Открываем шаблон как новый документ
            _wordDocument = _wordApp.Documents.Open(source);
            _wordDocument.Activate();

            // Добавляем информацию
            // wBookmarks содержит все закладки
            _wordBookmarks = _wordDocument.Bookmarks;

            int i = 0;

            foreach (Word.Bookmark mark in _wordBookmarks)
            {
                _wordRange = mark.Range;
                _wordRange.Text = meteringDataArr[i];
                i++;
            }

            _find = _wordApp.Selection.Find;
            _find.Text = this._templateConfig.TemplateDateTagName;
            _find.Replacement.Text = DateTime.Today.ToString("d");
            _find.Execute
                (
                FindText: Type.Missing,
                MatchCase: false,
                MatchWholeWord: false,
                MatchWildcards: false,
                MatchSoundsLike: _missingObj,
                MatchAllWordForms: false,
                Forward: true,
                Wrap: Word.WdFindWrap.wdFindContinue,
                Format: false,
                ReplaceWith: _missingObj,
                Replace: Word.WdReplace.wdReplaceAll
                );
        }

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
        private void SaveDoc(string path, int combinedMonthYearDate)
        {
            if ( File.Exists(path + combinedMonthYearDate + this._attachConfig.AttachmentExtension) )
            {
                this.IsFileExist = true;
                // TODO Залогировать это сообщение - MessageBox.Show("Файл с показаниями за текущий месяц уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.AttachmentAlredyExistEvent?.Invoke();
            }
            else
            {
                IsFileExist = false;
                Object pathToSaveObj = path + combinedMonthYearDate;
                _wordDocument.SaveAs
                    (
                    ref pathToSaveObj,
                    Word.WdSaveFormat.wdFormatDocument,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj,
                    ref _missingObj
                    );
            }
        }

        private void ExitWord()
        {

            _wordApp.ActiveDocument.Close();
            Object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
            Object originalFormat = Word.WdOriginalFormat.wdWordDocument;
            Object routeDocument = Type.Missing;
            _wordApp.Quit(ref saveChanges,
                         ref originalFormat,
                         ref routeDocument);
            _wordApp = null;

        }

        #endregion

    }
}