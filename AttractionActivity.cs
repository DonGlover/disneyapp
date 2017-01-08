using System.Json;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

using disneyapp.models;
using Newtonsoft.Json;

namespace disneyapp
{
    [Activity(Label = "")]
    public class AttractionActivity : Activity
    {
        async protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView (Resource.Layout.attractiondetail);
            
            FetchAsync FA = new FetchAsync();
            string park = Intent.GetStringExtra("park") ?? "Data not available";
            string permalink = Intent.GetStringExtra("permalink") ?? "Data not available";
            string url = "http://touringplans.com/" + park + "/attractions/" + permalink + ".json";
            JsonValue json = await FA.CallWebService(url);
            ParseAndDisplay(json);
        }
        private void ParseAndDisplay(JsonValue json)
        {
            attractionDetail SelectedAttraction = JsonConvert.DeserializeObject<attractionDetail>(json.ToString());
            this.Title = SelectedAttraction.name;
            TextView tvScope = (TextView)FindViewById(Resource.Id.scope);
            tvScope.Text = SelectedAttraction.scope_and_scale_code.Replace("_", " ");
            TextView tvOpened = (TextView)FindViewById(Resource.Id.opened);
            tvOpened.Text = SelectedAttraction.opened_on;
            TextView tvDesc = (TextView)FindViewById(Resource.Id.description);
            tvDesc.Text = SelectedAttraction.what_it_is;
            TextView tvWhenToGo = (TextView)FindViewById(Resource.Id.whentogo);
            tvWhenToGo.Text = SelectedAttraction.when_to_go;
            TextView tvDuration = (TextView)FindViewById(Resource.Id.duration);
            if (SelectedAttraction.duration != null && SelectedAttraction.duration != "")
                tvDuration.Text = SelectedAttraction.duration + " minutes.";
            TextView tvWaitTime = (TextView)FindViewById(Resource.Id.waittime);
            if (SelectedAttraction.average_wait_per_hundred != null && SelectedAttraction.average_wait_per_hundred !="")
            {
                tvWaitTime.Text = SelectedAttraction.average_wait_per_hundred + " minutes.";
            }
            if (SelectedAttraction.average_wait_assumes != null && SelectedAttraction.average_wait_assumes != "")
            {
                tvWaitTime.Text += " Assumes: " + SelectedAttraction.average_wait_assumes;
            }
                
        }
    }
    
}