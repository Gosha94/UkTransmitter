using System;
using System.Windows.Input;

namespace UkTransmitter.Wpf.FrontEnd.Infrastructure
{

    /// <summary>
    /// Класс умной команды с предпроверкой возможности выполнения
    /// </summary>
    public class RelayCommand : ICommand
    {
        
        /// <summary>
        /// Действие для выполнения во ViewModels
        /// </summary>
        private Action<object> _actionForExecute;

        /// <summary>
        /// Стандартный делегат bool, определяет возможность выполнения команды в зависимости от условий
        /// </summary>
        private Predicate<object> _canExecute;

        /// <summary>
        /// Событие запускается, когда значение <see cref="CanExecute(object)"/> меняется
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add     { CommandManager.RequerySuggested += value; }
            remove  { CommandManager.RequerySuggested -= value; }
        }

        #region Constructors

        /// <summary>
        /// Конструктор по умолчанию, для выполнения команд без проверки разрешения на выполнение
        /// </summary>
        /// <param name="inputActionForExecute">Ссылка на метод, который должен выполниться</param>
        public RelayCommand(Action<object> inputActionForExecute) : this(inputActionForExecute, null)
        { }

        /// <summary>
        /// Расширенный конструктор, принимает также метод проверки возможности выполнения команды
        /// </summary>
        /// <param name="inputActionForExecute">Ссылка на метод, который должен выполниться</param>
        /// <param name="canExecuteAction">Ссылка на метод проверки выполнения команды</param>
        public RelayCommand(Action<object> inputActionForExecute, Predicate<object> canExecuteAction)
        {
            this._actionForExecute = inputActionForExecute ?? throw new ArgumentNullException($"Error while execute action{nameof(_actionForExecute)}");

            this._canExecute = canExecuteAction;
        }

        #endregion

        /// <summary>
        /// Метод проверяет возможность выполнения команды
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
            => _canExecute == null ? true : _canExecute(parameter);

        /// <summary>
        /// Метод выполняет метод передаваемый в Relay команду
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
            => _actionForExecute(parameter);
    }
}
