using PropertyChanged;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UkTransmitter.Wpf.FrontEnd.Infrastructure
{
    /// <summary>
    /// Базовый класс для всех дочерних моделей представления (ViewModels)
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    internal class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие, реагирующее на изменение свойства в дочерних классах (ViewModels)
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод для расширения логики из дочерних классов
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
