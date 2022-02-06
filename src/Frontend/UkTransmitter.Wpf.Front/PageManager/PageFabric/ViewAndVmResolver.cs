using System.Collections.Generic;
using UkTransmitter.DIContainer.Configuration;
using UkTransmitter.Wpf.FrontEnd.Infrastructure;
using UkTransmitter.Wpf.FrontEnd.PageManager.Enum;
using UkTransmitter.Wpf.FrontEnd.ApplicationPages.Auth;
using UkTransmitter.Wpf.FrontEnd.ApplicationPages.Graph;
using UkTransmitter.Wpf.FrontEnd.ApplicationPages.SendData;

namespace UkTransmitter.Wpf.FrontEnd.PageManager.PageFabric
{

    /// <summary>
    /// Класс-фабрика для сопоставления View и View Model, аналог Service Locator
    /// </summary>
    internal class ViewAndVmResolver
    {

        private DependencyFabric _dependencyFabric;

        #region Constructor

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ViewAndVmResolver()
        {
            _dependencyFabric = new DependencyFabric();
            _dependencyFabric.RegisterAllScopesInApp();
        }

        #endregion

        #region Public API

        public Dictionary<ApplicationPage, ICustomViewModel> GetViewModelResolve()
        {
            var preparedVmDictionary = new Dictionary<ApplicationPage, ICustomViewModel>();

            preparedVmDictionary.Add(ApplicationPage.Auth, new AuthPageViewModel());
            preparedVmDictionary.Add(ApplicationPage.SendData, new SendDataPageViewModel());
            preparedVmDictionary.Add(ApplicationPage.Graph, new GraphPageViewModel());

            var resultDict = preparedVmDictionary;

            return resultDict;
        }

        #endregion

    }
}
