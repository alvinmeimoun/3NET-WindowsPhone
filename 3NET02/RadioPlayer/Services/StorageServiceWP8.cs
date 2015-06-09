using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RadioPlayerLib.Services;

namespace RadioPlayer.Services
{
    public class StorageServiceWP8 : IStorageService
    {
        public string ReadFileFromProjectToString(string filePath)
        {
            var resourceStream = Application.GetResourceStream(new Uri(filePath, UriKind.Relative));
            if (resourceStream != null)
            {
                Stream myFileStream = resourceStream.Stream;
                if (myFileStream.CanRead)
                {
                    StreamReader myStreamReader = new StreamReader(myFileStream);

                    return myStreamReader.ReadToEnd();
                }
            }
            return "";
        }

        public T ObjectFromLocalStorage<T>(string key)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
            {
                return (T) IsolatedStorageSettings.ApplicationSettings[key];
            }
            else
            {
                return default(T);
            }
        }

        public void SaveToLocalStorage(string key, object data)
        {
            IsolatedStorageSettings.ApplicationSettings[key] = data;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }
    }
}
