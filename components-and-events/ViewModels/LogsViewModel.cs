using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ui.Events;
using ui.Models;

namespace ui.ViewModels
{
    public class LogsViewModel:Screen, IHandle<LogEvent>
    {
        private readonly IEventAggregator eventAggregator;

        private string test = "Hello World";
        public string Test {
            get => test;
            set
            {
                test = value;
                Debug.WriteLine(value);
                NotifyOfPropertyChange(() => Test);
            }
        }

        private ObservableCollection<LogModel> _logs = new ObservableCollection<LogModel>();

        public LogsViewModel(IEventAggregator eventAggregator)
        {
            for (int i = 0; i < 100; i++)
            {
                _logs.Add(new LogModel { Message = "Hello World", Time = DateTime.Now });
            }

            this.eventAggregator = eventAggregator;

            this.eventAggregator.SubscribeOnUIThread(this);
        }

        public ObservableCollection<LogModel> Logs
        {
            get { return _logs; }
            set
            {
                _logs = value;
            }
        }

        public Task HandleAsync(LogEvent message, CancellationToken cancellationToken)
        {
            Debug.WriteLine(message.LogModel.Message);

            _logs.Add(message.LogModel);
            if (Logs.Count > 100)
            {
                Logs.RemoveAt(0);
            }

            NotifyOfPropertyChange(() => Logs);
            return Task.CompletedTask;
        }
    }
}
