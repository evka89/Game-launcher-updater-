using Launcher.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.BL.Services
{
    public class UpdateChecker
    {
        public delegate void ChekerEventHandler(object sender, CheckerEventArgs e);

        public event ChekerEventHandler SwithState;
        public event ChekerEventHandler FoundBrokenFile;
        public event ChekerEventHandler CheckProgress;

        private string updateFilePath;

        private List<UpdateFileInfo> _filesForCheck { get; set; }

        public UpdateChecker(string updateFilePath)
        {
            _filesForCheck = new List<UpdateFileInfo>();
            this.updateFilePath = updateFilePath;
        }
        public async void CheckForUpdatesAsync()
        {
            Task _checkTask = new Task(CheckForUpdates);
            _checkTask.Start();
            await _checkTask;
        }
        internal void CheckForUpdates()
        {
            Func<UpdateFileInfo, bool> AddToBroken = delegate (UpdateFileInfo data)
            {
                OnFoundBrokenFile(new CheckerEventArgs { file = data });
                return true;
            };

            OnSwithState(new CheckerEventArgs { State = true });

            _filesForCheck = GetUpdateFiles();
            if (_filesForCheck == null)
            {
                return;
            }

            int fileCount = _filesForCheck.Count();
            int currentProgress = 0;
            foreach(var file in _filesForCheck)
            {
                if (File.Exists(".\\" + file.LocalFilePath)) {
                    if (CheckFileMd5(file))
                    {
                        AddToBroken(file);
                    }
                }else{
                    AddToBroken(file);
                }
                currentProgress++;
                OnCheckProgress(new CheckerEventArgs { FileCount = fileCount, Progress = currentProgress });
            }

            OnSwithState(new CheckerEventArgs { State = false });
        }

        private bool CheckFileMd5(UpdateFileInfo file)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(".\\" + file.LocalFilePath))
                {
                    string filehash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                    if(filehash == file.FileMD5Hash)
                    {
                        return true;
                    }else{
                        return false;
                    }
                }
            }
        }

        private List<UpdateFileInfo> GetUpdateFiles()
        {
            using(var request = new xNet.HttpRequest())
            {
                try
                {
                    string content = request.Get(String.Format("{0}/updateInfo.json",updateFilePath)).ToString();
                    return JsonConvert.DeserializeObject<List<UpdateFileInfo>>(content);
                }
                catch (Exception e)
                {
                    HandleError(0, e);
                    return null;
                }
            }
        }
        protected void HandleError(int code, Exception ex = null)
        {

        }
        protected virtual void OnSwithState(CheckerEventArgs e)
        {
            ChekerEventHandler handler = SwithState;
            if(handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void OnFoundBrokenFile(CheckerEventArgs e)
        {
            ChekerEventHandler handler = FoundBrokenFile;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void OnCheckProgress(CheckerEventArgs e)
        {
            ChekerEventHandler handler = CheckProgress;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
