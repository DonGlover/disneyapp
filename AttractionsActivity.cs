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
    [Activity(Label = "Park Attractions")]
    public class AttractionsActivity : ListActivity
    {
        string park;
        List<attractions> AttractionsList = new List<attractions>();
        public List<attractions> Attractions { get; private set; }
        async protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FetchAsync FA = new FetchAsync();
            park = Intent.GetStringExtra("park") ?? "Data not available";
            string url = "http://touringplans.com/"+ park + "/attractions.json";
            JsonValue json = await FA.CallWebService(url);
            ParseAndDisplay(json);
        }

        private void ParseAndDisplay(JsonValue json)
        {
            AttractionsList = JsonConvert.DeserializeObject<List<attractions>>(json.ToString());
            List<string> AttractionNames = new List<string>();
            foreach (attractions a in AttractionsList)
                AttractionNames.Add(a.name);
            ArrayAdapter<string> listAdapter = new ArrayAdapter<string>(this, Resource.Layout.parksrow, AttractionNames);
            ListAdapter = listAdapter;
        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
         
            var intent = new Intent(this, typeof(AttractionActivity));
            intent.PutExtra("permalink", AttractionsList[position].permalink);
            intent.PutExtra("park", park);
            StartActivity(intent);
        }
    }
}