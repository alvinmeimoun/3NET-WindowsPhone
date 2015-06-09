using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioPlayerLib.Services
{
    public interface IStorageService
    {
        string ReadFileFromProjectToString(string filePath);

        T ObjectFromLocalStorage<T>(string key);
        void SaveToLocalStorage(string key, Object data);
    }
}
