using System.Json;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

using disneyapp.models;
using Newtonsoft.Json;


namespace disneyapp
{
    [Activity(Label = "Hotel Detail")]
    public class HotelActivity : Activity
    {
        async protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.hoteldetail);
            FetchAsync FA = new FetchAsync();
            // string location = Intent.GetStringExtra("location") ?? "Data not available";
            string location = "walt-disney-world";
            string permalink = Intent.GetStringExtra("permalink") ?? "Data not available";
            string url = "http://touringplans.com/" + location + "/hotels/" + permalink + ".json";
            JsonValue json = await FA.CallWebService(url);
            ParseAndDisplay(json);
        }
        private void ParseAndDisplay(JsonValue json)
        {
            hotelDetail SelectedHotel = JsonConvert.DeserializeObject<hotelDetail>(json.ToString());
            TextView tvName = (TextView)FindViewById(Resource.Id.hotelname);
            tvName.Text = SelectedHotel.name;
            TextView tvAddr1 = (TextView)FindViewById(Resource.Id.hotelAddress1);
            tvAddr1.Text = SelectedHotel.address;
            TextView tvAddr2 = (TextView)FindViewById(Resource.Id.hotelAddress2);
            tvAddr2.Text = SelectedHotel.city + ", " + SelectedHotel.state_code + " " + SelectedHotel.zip_code;
            TextView tvPhone = (TextView)FindViewById(Resource.Id.hotelphone);
            tvPhone.Text = SelectedHotel.phone_number;
            TextView tvTheme = (TextView)FindViewById(Resource.Id.hoteltheme);
            tvTheme.Text = SelectedHotel.theme;
            TextView tvCost = (TextView)FindViewById(Resource.Id.hotelcost);
            tvCost.Text = SelectedHotel.cost_range;
        }
    }
}