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
    public class resort
    {
        public string name { get; set; }
        public string permalink { get; set; }

        public restaurant[] dinings;
    }

    public class restaurant
    {
        public string name { get; set; }
        public string permalink { get; set; }
    }
}