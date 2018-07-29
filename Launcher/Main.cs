using Launcher.BL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Main : Form
    {
        private readonly UpdateManager updateManager;
        public Main()
        {
            InitializeComponent();
            updateManager = new UpdateManager("http://sakurajd.ru");
            updateManager.Run();
            updateManager._checker.CheckProgress += _checker_CheckProgress;
            
        }

        private void _checker_CheckProgress(object sender, Data.CheckerEventArgs e)
        {
            prgCheck.Invoke(new MethodInvoker(delegate {
                prgCheck.Maximum = e.FileCount;
                prgCheck.Value = e.Progress;
            }));
        }
    }
}
