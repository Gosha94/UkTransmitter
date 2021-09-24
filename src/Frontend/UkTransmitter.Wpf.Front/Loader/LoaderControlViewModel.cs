using System.Threading.Tasks;
using UkTransmitter.Wpf.FrontEnd.Infrastructure;

namespace UkTransmitter.Wpf.FrontEnd.Loader
{
    /// <summary>
    /// Модель представления Загрузчика
    /// </summary>
    internal sealed class LoaderControlViewModel : BaseViewModel
    {
        private bool _isLoadingState;

        /// <summary>
        /// Свойство, указывает на необходимость показа Загрузчика
        /// </summary>
        public bool IsLoadingState
        {
            get => this._isLoadingState;
            
            set
            {
                this._isLoadingState = value;

                if (value)
                {
                    StartLoaderProgressAsync();
                }
                
                OnPropertyChanged(nameof(IsLoadingState));
            }
        }


        private int _loadingValue;

        /// <summary>
        /// Свойство, для отображения прогресса Загрузчика
        /// </summary>
        public int LoadingValue
        {
            get => this._loadingValue;

            set
            {
                if (value >= 100)
                {
                    value = 0;
                }
                this._loadingValue = value;
                OnPropertyChanged(nameof(LoadingValue));
            }

        }

        /// <summary>
        /// Асинхронный метод увеличивает прогресс Лоадера на + 1 ед.
        /// </summary>
        private async void StartLoaderProgressAsync()
        {
            await IncreaseLoaderValue();
        }

        /// <summary>
        /// Асинхронная задача инкремента значения Лоадера
        /// </summary>
        /// <returns></returns>
        private async Task IncreaseLoaderValue()
        {
            await Task.Run(async () =>
            {
                while (this.IsLoadingState)
                {                    
                    this.LoadingValue++;
                    await Task.Delay(50);
                }
            });
        }
    }
}
