using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace disneyapp.models
{
    public class hotelDetail
    {
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state_code { get; set; }
        public string zip_code { get; set; }
        public string phone_number { get; set; }
        public string url { get; set; }
        public bool off_site { get; set; }
        public bool water_sports { get; set; }
        public bool marina { get; set; }
        public bool beach { get; set; }
        public bool tennis { get; set; }
        public bool biking { get; set; }
        public bool suites { get; set; }
        public bool concierge_floor { get; set; }
        public bool room_service { get; set; }
        public bool wired_internet { get; set; }
        public bool wireless_internet { get; set; }
        public string num_rooms { get; set; }
        public string theme { get; set; }
        public string cost_range { get; set; }
        public bool shuttle_to_parks { get; set; }
        public string cost_estimate { get; set; }
        public string lodging_area_code { get; set; }
        public string category_code { get; set; }
    }
}