using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using RadioPlayerLib.Resources;

namespace RadioPlayerLib.ViewModel
{
    public class FrequencyViewModel : ViewModelBase
    {
        public bool ListLoading { get; set; }

        public string NearestLoadErrorMessage { get; set; }

        public bool DisplayNearestLoadErrorMessage { 
            get
            {
                return NearestLoadErrorMessage != null && NearestLoadErrorMessage.Length > 0;
            } 
        }

        public FrequencyViewModel()
        {
            if (!IsInDesignMode)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            ListLoading = true;

            NearestLoadErrorMessage = ViewMessages.Loading_Position;
        }
    }
}
