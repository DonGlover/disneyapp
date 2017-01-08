using System;
using System.Collections.Generic;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;

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
    public class RestaurantActivity : Activity
    {
        async protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.restaurantdetail);
            FetchAsync FA = new FetchAsync();
            string park = Intent.GetStringExtra("park") ?? "Data not available";
            string permalink = Intent.GetStringExtra("permalink") ?? "Data not available";
            string url = "http://touringplans.com/" + park + "/dining/" + permalink + ".json";
            JsonValue json = await FA.CallWebService(url);
            ParseAndDisplay(json);
        }
        
        private void ParseAndDisplay(JsonValue json)
        {
            restaurantDetail SelectedRestaurant = JsonConvert.DeserializeObject<restaurantDetail>(json.ToString());
            this.Title = SelectedRestaurant.name;
            TextView tvType = (TextView)FindViewById(Resource.Id.diningtype);
            tvType.Text = SelectedRestaurant.category_code.Replace("_", " "); 
            TextView tvCost = (TextView)FindViewById(Resource.Id.diningcosttype);
            tvCost.Text = SelectedRestaurant.cost_code;
            TextView tvCuisine = (TextView)FindViewById(Resource.Id.diningcuisine);
            tvCuisine.Text = SelectedRestaurant.cuisine;
            TextView tvPhone = (TextView)FindViewById(Resource.Id.diningphone);
            tvPhone.Text = SelectedRestaurant.phone_number;
            TextView tvPrice = (TextView)FindViewById(Resource.Id.diningentreeprice);
            tvPrice.Text = SelectedRestaurant.entree_range;
            TextView tvSpecialties = (TextView)FindViewById(Resource.Id.diningspecialties);
            tvSpecialties.Text = SelectedRestaurant.house_specialties;

        }
    }
}