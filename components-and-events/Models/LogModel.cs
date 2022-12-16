using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ui.Models
{
    public class LogModel
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return "Message: " + Message + " Time: " + Time;
        }
    }
}
