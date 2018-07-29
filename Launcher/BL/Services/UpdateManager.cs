using Launcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Launcher.BL.Services
{
    public class UpdateManager
    {
        private Queue<UpdateFileInfo> fileQueue { get; set; }

        private bool CheckDone { get; set; }
        public readonly UpdateChecker _checker;
        private readonly UpdateDownloader _downloder;

        public UpdateManager(string updateURL)
        {
            CheckDone = true;
            fileQueue = new Queue<UpdateFileInfo>();
            _downloder = new UpdateDownloader();
            _checker = new UpdateChecker(updateURL);
            




        }
        public void Run()
        {
            _checker.CheckForUpdatesAsync();
            _checker.SwithState += _checker_SwithState;
            _checker.FoundBrokenFile += _checker_FoundBrokenFile;

            _downloder.StartDownloadTaskAsync(fileQueue);
            




        }

        private void _checker_SwithState(object sender, CheckerEventArgs e)
        {
            CheckDone = e.State;
        }

        private void _checker_FoundBrokenFile(object sender, CheckerEventArgs e)
        {
            fileQueue.Enqueue(e.file);
        }


    }
}
