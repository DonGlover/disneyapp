using System.Collections.Generic;
using System.Json;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

using disneyapp.models;
using Newtonsoft.Json;

namespace disneyapp
{
    [Activity(Label = "Hotels")]
    public class Hotels_Activity : ListActivity
    {
        string location;
        List<hotel> HotelList = new List<hotel>();
        public List<attractions> Attractions { get; private set; }
        async protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FetchAsync FA = new FetchAsync();
            //location = Intent.GetStringExtra("location") ?? "Data not available";
            location = "walt-disney-world";
            string url = "http://touringplans.com/" + location + "/resort-dining.json";
            JsonValue json = await FA.CallWebService(url);
            ParseAndDisplay(json);
        }

        private void ParseAndDisplay(JsonValue json)
        {
            HotelList = JsonConvert.DeserializeObject<List<hotel>>(json.ToString());
            List<string> HotelNames = new List<string>();
            foreach (hotel h in HotelList)
                HotelNames.Add(h.name);
            ArrayAdapter<string> listAdapter = new ArrayAdapter<string>(this, Resource.Layout.parksrow, HotelNames);
            ListAdapter = listAdapter;
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            var intent = new Intent(this, typeof(HotelActivity));
            intent.PutExtra("permalink", HotelList[position].permalink);
            intent.PutExtra("park", "walt-disney-world");
            StartActivity(intent);
        }
    }
}