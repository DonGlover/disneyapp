using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace disneyapp
{
    [Activity(Label = "Disney World Parks")]
    public class ParksActivity : ListActivity
    {
        private ArrayAdapter<String> listAdapter;
        private string requestType;
        String[] parks = new String[] { "Magic Kingdom", "Epcot", "Hollywood Studios", "Animal Kingdom", "Typhoon Lagoon", "Blizzard Beach" };
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //SetContentView (Resource.Layout.);
            requestType = Intent.GetStringExtra("requestKey") ?? "Data not available";
            listAdapter = new ArrayAdapter<string>(this, Resource.Layout.parksrow, parks);
            ListAdapter = listAdapter;

        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            String ParkToCall = "";
            Type activityType = null;
            base.OnListItemClick(l, v, position, id);
            switch (position)
            {
                case 0: 
                    ParkToCall = "magic-kingdom";
                    break;
                case 1:
                    ParkToCall = "epcot";
                    break;
                case 2: 
                    ParkToCall = "hollywood-studios";
                    break;
                case 3: 
                    ParkToCall = "animal-kingdom";
                    break;
                case 4:
                    ParkToCall = "typhoon-lagoon";
                    break;
                case 5:
                    ParkToCall = "blizzard-beach";
                    break;
            }
            if(requestType== "attraction")
                activityType = typeof(AttractionsActivity);
            else if(requestType == "dining")
                activityType = typeof(RestaurantsActivity);

            var intent = new Intent(this, activityType);
            intent.PutExtra("park", ParkToCall);
            StartActivity(intent);
        }
    }
}