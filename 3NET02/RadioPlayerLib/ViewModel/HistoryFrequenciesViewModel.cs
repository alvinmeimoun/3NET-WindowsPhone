using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace RadioPlayerLib.ViewModel
{
    public class HistoryFrequenciesViewModel : ViewModelBase
    {
        public List<FrequencyHistoryViewModel> Frequencies { get; set; }

        public HistoryFrequenciesViewModel()
        {
            Frequencies = new List<FrequencyHistoryViewModel>();
        }
    }
}
