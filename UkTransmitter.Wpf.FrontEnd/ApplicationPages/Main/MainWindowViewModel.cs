using System.Diagnostics;
using System.Windows.Input;
using System.Collections.Generic;
using UkTransmitter.Wpf.FrontEnd.Loader;
using UkTransmitter.Wpf.FrontEnd.Infrastructure;
using UkTransmitter.Wpf.FrontEnd.PageManager.Enum;
using UkTransmitter.Wpf.FrontEnd.PageManager.PageFabric;
using System.Windows;

namespace UkTransmitter.Wpf.FrontEnd.ApplicationPages.Main
{

    /// <summary>
    /// Модель представления для Главной страницы
    /// </summary>
    internal sealed class MainWindowViewModel : BaseViewModel
    {

        #region Private Fields

        private ICustomViewModel _currentPageViewModel;
        private Dictionary<ApplicationPage, ICustomViewModel> _pageViewModelsDict;
        private ViewAndVmResolver _viewAndVmResolver;
        private bool _contentIsBusy;
        
        #endregion

        #region Public Properties

        public Dictionary<ApplicationPage, ICustomViewModel> PageViewModelsDict
        {
            get
            {
                if (this._pageViewModelsDict == null)
                {
                    this._pageViewModelsDict = new Dictionary<ApplicationPage, ICustomViewModel>();
                }
                return this._pageViewModelsDict;
            }

            private set
            {
                this._pageViewModelsDict = value;
            }
        }

        public ICustomViewModel CurrentPageViewModel
        {
            get => this._currentPageViewModel;
            set
            {
                if (this._currentPageViewModel != value)
                {
                    this._currentPageViewModel = value;
                    OnPropertyChanged(nameof(CurrentPageViewModel));
                }
            }
        }

        public LoaderControlViewModel Loader { get; set; }

        public bool ContentIsBusy
        {
            get => this._contentIsBusy;
            set
            {
                if (value)
                {
                    _contentIsBusy = value;
                }
            }
        }

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {

            // TODO доделать лоадер через подписку на событие из Loader.IsLoadingState
            this.Loader = new LoaderControlViewModel();
            this.Loader.IsLoadingState = false;
            this._viewAndVmResolver = new ViewAndVmResolver();
            
            // Заглушка
            ChangeContentState(true);

            // Loading All Application View Models From Application Container
            this.PageViewModelsDict = this._viewAndVmResolver.GetViewModelResolve();

            // Set Start page as Auth Page
            ChangeViewModel(0);

        }

        #endregion

        #region Commands

        /// <summary>
        /// Команда меняет статус Лоадера 
        /// </summary>
        public ICommand ChangeLoaderState
        {
            get
            {
                return new RelayCommand
                    (
                        executingObj =>
                        {
                            this.Loader.IsLoadingState = this.Loader.IsLoadingState ? false : true;
                        },
                        canExec => AlwaysReturnedTrueAction()
                    );
            }
        }

        /// <summary>
        /// Команда перехода на страницу Отправить данные в УК
        /// </summary>
        public ICommand GoToSendDataCommand
        {
            get
                => new RelayCommand
                    (
                        executingObj =>
                        {
                            
                            Debug.WriteLine($"Going To {executingObj}...");
                            
                            // Set Page as Send Data Page
                            ChangeViewModel(1);
                        },
                        canExec => AlwaysReturnedTrueAction()
                    );
        }

        /// <summary>
        /// Команда перехода на страницу Графики показаний
        /// </summary>
        public ICommand GoToGraphsCommand
        {
            get
            {
                return new RelayCommand
                    (
                        executingObj =>
                        {
                            Debug.WriteLine($"Going To {executingObj}...");

                            // Set Page as Graphs Page
                            ChangeViewModel(2);
                        },
                        canExec => AlwaysReturnedTrueAction()
                    );
            }
        }

        public ICommand CloseApplicationCommand
        {
            get
                => new RelayCommand
                    (
                        executingObj =>
                        {
                            Debug.WriteLine($"Exit from Application...");
                            Application.Current.Shutdown();
                        },
                        canExec => AlwaysReturnedTrueAction()
                    );
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Метод меняет состояние IsEnabled элементов формы в зависимости от активности Лоадера
        /// </summary>
        private void ChangeContentState(bool state)
        {
            ContentIsBusy = state;
        }
        /// <summary>
        /// Метод для разрешения работы Команд, без ограничивающей логики
        /// </summary>
        /// <returns>Always true</returns>
        private bool AlwaysReturnedTrueAction() => true;

        /// <summary>
        /// Команда смены Модели представления в зависимости от выбранной страницы (Навигация)
        /// </summary>
        /// <param name="pageIdChangeTo"></param>
        private void ChangeViewModel(int pageIdChangeTo)
        {
            ApplicationPage pageKey;

            switch (pageIdChangeTo)
            {
                case 0:
                    pageKey = ApplicationPage.Auth;
                    break;
                case 1:
                    pageKey = ApplicationPage.SendData;
                    break;
                case 2:
                    pageKey = ApplicationPage.Graph;
                    break;
                default:
                    pageKey = ApplicationPage.Auth;
                    break;
            }

            this.CurrentPageViewModel = PageViewModelsDict[pageKey];
        }

        #endregion

    }
}