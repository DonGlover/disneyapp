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
    [Activity(Label = "")]
    public class RestaurantsActivity : ListActivity
    {
        FetchAsync FA = new FetchAsync();
        string park;
        List<resort> ResortList = new List<resort>();
        public List<resort> Restaurants { get; private set; }
        async protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            park = Intent.GetStringExtra("park") ?? "Data not available";
            string url = "http://touringplans.com/" + park + "/dining.json";
            JsonValue json = await FA.CallWebService(url);
            ParseAndDisplay(json);
        }

        private void ParseAndDisplay(JsonValue json)
        {
            this.Title = park.Replace("-", " ").ToUpperInvariant();
            string JsonString = json.ToString();
            string js2 = JsonString.Substring(1, JsonString.Length - 2).Replace("], [", ",");
            ResortList = JsonConvert.DeserializeObject<List<resort>>(js2);
            List<string> RestaurantNames = new List<string>();
            foreach (resort r in ResortList)
            {
                RestaurantNames.Add(r.name);
            }
            ArrayAdapter<string> listAdapter = new ArrayAdapter<string>(this, Resource.Layout.parksrow, RestaurantNames);
            ListAdapter = listAdapter;
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            var intent = new Intent(this, typeof(RestaurantActivity));
            intent.PutExtra("permalink", ResortList[position].permalink);
            intent.PutExtra("park", park);
            StartActivity(intent);
        }
    }
}