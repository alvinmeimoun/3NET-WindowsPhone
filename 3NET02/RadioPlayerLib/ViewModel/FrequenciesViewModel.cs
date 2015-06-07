using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Newtonsoft.Json;
using RadioPlayerLib.Resources;
using RadioPlayerLib.Services;

namespace RadioPlayerLib.ViewModel
{
    public class FrequenciesViewModel : ViewModelBase
    {
        public bool ListLoading { get; set; }

        public string NearestLoadErrorMessage { get; set; }

        public List<FrequencyViewModel> Frequencies { get; set; } 

        public bool DisplayNearestLoadErrorMessage { 
            get
            {
                return NearestLoadErrorMessage != null && NearestLoadErrorMessage.Length > 0;
            } 
        }

        public FrequenciesViewModel()
        {
            Frequencies = new List<FrequencyViewModel>();

            if (!IsInDesignMode)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            ListLoading = true;

            NearestLoadErrorMessage = ViewMessages.Loading_Position;

            IStorageService storageService = SimpleIoc.Default.GetInstance<IStorageService>();
            var freqJsonStr = storageService.ReadFileFromProjectToString(@"Resources/frequencies.json");
            Frequencies = JsonConvert.DeserializeObject<List<FrequencyViewModel>>(freqJsonStr);
        }
    }
}
