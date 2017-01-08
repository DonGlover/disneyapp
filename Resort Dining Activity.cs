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
    [Activity(Label = "Resorts")]
    public class Resort_Dining_Activity : ListActivity
    {
        string location;
        List<resort> ResortList = new List<resort>();
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
            ResortList = JsonConvert.DeserializeObject<List<resort>>(json.ToString());
            List<string> ResortNames = new List<string>();
            foreach (resort r in ResortList)
                ResortNames.Add(r.name);
            ArrayAdapter<string> listAdapter = new ArrayAdapter<string>(this, Resource.Layout.parksrow, ResortNames);
            ListAdapter = listAdapter;
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            var intent = new Intent(this, typeof(ResortRestaurantsActivity));
            intent.PutExtra("park", ResortList[position].name);
            JsonValue dinings = JsonConvert.SerializeObject(ResortList[position].dinings);
            intent.PutExtra("restaurants", (string) dinings);
            StartActivity(intent);
        }

    }
}