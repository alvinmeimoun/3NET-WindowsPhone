using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Newtonsoft.Json;
using RadioPlayerLib.Exceptions;
using RadioPlayerLib.Resources;
using RadioPlayerLib.Services;

namespace RadioPlayerLib.ViewModel
{
    public class FrequenciesViewModel : ViewModelBase
    {
        public string NearestLoadErrorMessage { get; set; }

        public FrequencyViewModel NearestFrequency { get; set; }

        public List<FrequencyViewModel> Frequencies { get; set; } 

        public bool DisplayNearestLoadErrorMessage { 
            get
            {
                return !string.IsNullOrEmpty(NearestLoadErrorMessage);
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

        private async void LoadData()
        {
            //Reinit
            NearestFrequency = new FrequencyViewModel
            {
                City = "",
                Frequency = ""
            };
            NearestLoadErrorMessage = ViewMessages.Loading_Position;

            //Loading
            IStorageService storageService = SimpleIoc.Default.GetInstance<IStorageService>();
            var freqJsonStr = storageService.ReadFileFromProjectToString(@"Resources/frequencies.json");
            Frequencies = JsonConvert.DeserializeObject<List<FrequencyViewModel>>(freqJsonStr);

            ILocationService locationService = SimpleIoc.Default.GetInstance<ILocationService>();
            try
            {
                var currentPt = await locationService.getCurrentLocation();

                int R = 6371; //radius de la terre
    
                double shortestDistance = -1;
                FrequencyViewModel nearestFreq = null;
    
                for(int i = 0; i < Frequencies.Count; i++){
                    FrequencyViewModel model = Frequencies[i];
                        double latDistance = (model.Latitude - currentPt.Latitude) * Math.PI / 180.0;
                        double lngDistance = (model.Longitude - currentPt.Longitude) * Math.PI / 180.0;

                        double a = Math.Sin(latDistance / 2) * Math.Sin(latDistance / 2)
                            + Math.Cos(currentPt.Latitude * Math.PI / 180.0) * Math.Cos(model.Latitude * Math.PI / 180.0)
                        * Math.Sin(lngDistance / 2) * Math.Sin(lngDistance / 2);
                        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                        double distance = R * c * 1000;

            
                        if(shortestDistance == -1 || shortestDistance > distance){
                            shortestDistance = distance;
                            nearestFreq = model;
                        }

                }

                NearestFrequency = nearestFreq;
                RaisePropertyChanged("NearestFrequency");
                NearestLoadErrorMessage = "";
                RaisePropertyChanged("NearestLoadErrorMessage");
            }
            catch (LocationDisabledException lde)
            {
                NearestLoadErrorMessage = ViewMessages.Position_Disabled;
                RaisePropertyChanged("NearestLoadErrorMessage");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                NearestLoadErrorMessage = ViewMessages.Loading_Position_Error;
                RaisePropertyChanged("NearestLoadErrorMessage");
            }
        }
    }
}
