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
    public class ResortRestaurantsActivity : ListActivity
    {
        List<restaurant> RestaurantList = new List<restaurant>();
        string park;
        string resortpermalink;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            park = Intent.GetStringExtra("park") ?? "Data not available";
            string json = Intent.GetStringExtra("restaurants") ?? "Data not available";
            resortpermalink = Intent.GetStringExtra("permalink") ?? "Data not available";
            ParseAndDisplay(json);
        }

        private void ParseAndDisplay(string json)
        {
            this.Title = park;

            RestaurantList = JsonConvert.DeserializeObject<List<restaurant>>(json);
            List<string> RestaurantNames = new List<string>();
            foreach (restaurant r in RestaurantList)
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
            intent.PutExtra("permalink", RestaurantList[position].permalink);
            intent.PutExtra("park", "walt-disney-world");
            StartActivity(intent);
        }
    }
}