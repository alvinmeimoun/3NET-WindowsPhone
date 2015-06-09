using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace RadioPlayerLib.ViewModel
{
    public class FrequencyHistoryViewModel : ViewModelBase
    {
        [JsonProperty("frequency")]
        public string Frequency { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("find_date")]
        public DateTime FindDate { get; set; }
    }
}
