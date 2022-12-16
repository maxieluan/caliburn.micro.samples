using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ui.Models;

namespace ui.Converters
{
    public class LogEntryCollectionToTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // print debug message
            Debug.WriteLine("LogEntryCollectionToTextConverter.Convert()");

            ObservableCollection<LogModel> logEntries = values[0] as ObservableCollection<LogModel>;

            if (logEntries != null && logEntries.Count > 0)
            {
                string text = string.Empty;
                DateTime start = DateTime.Now;
                foreach (LogModel logEntry in logEntries)
                {
                    text += logEntry.ToString() + Environment.NewLine;
                }

                DateTime end = DateTime.Now;

                return text + "~~~" + TimePassedInMiliseconds(start, end);
            }

            else
                return String.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public int TimePassedInMiliseconds(DateTime start, DateTime end)
        {
            return end.Millisecond - start.Millisecond;
        }
    }
}
