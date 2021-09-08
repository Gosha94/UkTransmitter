using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace UkTransmitter.Wpf.FrontEnd.Infrastructure
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {

        #region Private Members

        /// <summary>
        /// Единственный статичный экземпляр конвертера значения
        /// </summary>
        private static T _converter = null;

        #endregion

        #region Constructor

        public BaseValueConverter()
        {

        }

        #endregion

        #region Markup Extension Methods

        /// <summary>
        /// Управляет статичным экземпляром конвертера значения
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            //if (_converter == null)
            //    _converter = new T();
            // Синглтон, ай яй яй
            return _converter ?? (_converter = new T());
        }

        #endregion

        #region Value Converter Implemented Methods

        /// <summary>
        /// Преобразовывает один тип передаваемого значения в другой
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Конвертирует значение обратно в исходный тип
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
