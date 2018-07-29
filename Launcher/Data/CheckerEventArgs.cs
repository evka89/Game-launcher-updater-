using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Launcher.Data
{
    public class CheckerEventArgs : EventArgs
    {
        public bool State { get; set; }
        public UpdateFileInfo file { get; set; }
        public int FileCount { get; set; }
        public int Progress { get; set; }
    }
}
