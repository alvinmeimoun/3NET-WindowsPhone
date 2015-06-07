using System;
using System.Collections.Generic;
using System.IO;
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
    }
}
