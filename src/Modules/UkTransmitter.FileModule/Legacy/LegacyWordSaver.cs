using System;
using System.IO;
using System.Reflection;
using UkTransmitter.FileModule.Models;
using Word = Microsoft.Office.Interop.Word;

namespace UkSender.FrontEnd.Workers
{

    /// <summary>
    /// Класс-сохранялка данных в шаблон Word
    /// </summary>
    internal sealed class LegacyWordSaver
    {

        private Word.Application _wordApp;        
        private Word.Document _wordDocument;
        private Word.Bookmarks _wordBookmarks;        
        private Word.Range _wordRange;
        private Word.Find _find;
        private Object _missingObj = Missing.Value;

        private FillTemplateDto _templateDto;

        internal bool IsFileExist { get; private set; }
        internal event Action FileWithCurrentMonthAlredyExist;

        internal LegacyWordSaver(FillTemplateDto fillTemplateDto)
        {




            if ( !Directory.Exists(fillTemplateDto.PathNewAttachmentFile) )
            {
                CreateWordDirectory(fillTemplateDto.PathNewAttachmentFile);
            }

            FillingTemplateDataFromForm(fillTemplateDto.PathNewAttachmentFile, fillTemplateDto.CurrentMonth, fillTemplateDto.ReceivedFromUserMeteringDataArray);
        }

        #region Private Methods

        private void CreateWordDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        private void FillingTemplateDataFromForm(string pathNewFile, int month, string[] meteringData)
        {
            // Создаём объект документа
            _wordDocument = null;

            // Создаем объект Word - равносильно запуску Word
            _wordApp = new Word.Application();
            // Делаем его невидимым
            _wordApp.Visible = false;

            // Путь до шаблона документа
            string source = CombinePathToWordTemplate() + "AttachmentTemplate.dot";
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
                _wordRange.Text = meteringData[i];
                i++;
            }

            _find = _wordApp.Selection.Find;
            _find.Text = "@@todayDate";
            _find.Replacement.Text = DateTime.Today.ToString("d");
            _find.Execute(FindText: Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false, MatchSoundsLike: _missingObj, MatchAllWordForms: false, Forward: true, Wrap: Word.WdFindWrap.wdFindContinue, Format: false, ReplaceWith: _missingObj, Replace: Word.WdReplace.wdReplaceAll);

            SaveDoc(pathNewFile, month);
            ExitWord();
        }

        private string CombinePathToWordTemplate()
        {
            string mainCatalog = AppDomain.CurrentDomain.BaseDirectory;
            return mainCatalog + "Templates\\";
        }

        private void SaveDoc(string path, int month)
        {
            if (File.Exists(path + month + ".doc"))
            {
                this.IsFileExist = true;
                this.FileWithCurrentMonthAlredyExist?.Invoke();
                //MessageBox.Show("Файл с показаниями за текущий месяц уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                IsFileExist = false;
                Object pathToSaveObj = path + month;
                _wordDocument.SaveAs(ref pathToSaveObj, Word.WdSaveFormat.wdFormatDocument, ref _missingObj, ref _missingObj, ref _missingObj, ref _missingObj, ref _missingObj, ref _missingObj, ref _missingObj, ref _missingObj, ref _missingObj, ref _missingObj, ref _missingObj, ref _missingObj, ref _missingObj, ref _missingObj);
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
 