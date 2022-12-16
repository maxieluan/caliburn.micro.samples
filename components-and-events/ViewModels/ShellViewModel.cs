using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ui.Events;
using ui.Models;

namespace ui.ViewModels
{
    public class ShellViewModel: Conductor<IScreen>.Collection.AllActive
    {
        private readonly IEventAggregator eventAggregator;
        public Screen LogViewModel { get; set; }

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            // Use all active to use constom controls, while also loads viewmodels
            LogViewModel = new LogsViewModel(eventAggregator);

            ActivateItemAsync(LogViewModel);
        }

        public Task PrintSomething()
        {
            Debug.WriteLine("Click");
            return  eventAggregator.PublishOnUIThreadAsync(new LogEvent(new LogModel { Message = "Hello World", Time = DateTime.Now }));
        }
    }
}
