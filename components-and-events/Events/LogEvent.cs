using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ui.Models;

namespace ui.Events
{
    public class LogEvent
    {
        public LogEvent(LogModel log)
        {
            LogModel = log;
        }

        public LogModel LogModel { get; set; }
    }
}
