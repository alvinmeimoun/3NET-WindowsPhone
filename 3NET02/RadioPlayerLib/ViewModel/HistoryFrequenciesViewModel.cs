using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Newtonsoft.Json;
using RadioPlayerLib.Services;

namespace RadioPlayerLib.ViewModel
{
    public class HistoryFrequenciesViewModel : ViewModelBase
    {
        public List<FrequencyHistoryViewModel> Frequencies { get; set; }

        public HistoryFrequenciesViewModel()
        {
            Frequencies = new List<FrequencyHistoryViewModel>();

            load();
        }

        private void load()
        {
            var storageService = SimpleIoc.Default.GetInstance<IStorageService>();
            var storedHistoryStr = storageService.ObjectFromLocalStorage<string>("FrequencyHistory");
            if (storedHistoryStr == null)
            {
                Frequencies = new List<FrequencyHistoryViewModel>();
            }
            else
            {
                Frequencies = JsonConvert.DeserializeObject<List<FrequencyHistoryViewModel>>(storedHistoryStr);
                Frequencies = Frequencies.OrderByDescending(f => f.FindDate).ToList();
            }
            RaisePropertyChanged("Frequencies");
        }
    }
}
