using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using System;
using System.Collections.Generic;

namespace disneyapp
{
    [Activity(Label = "Explore Disney World", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        private ArrayAdapter<String> listAdapter;
        String[] parkActivities = new String[] { "Attractions", "In Park Dining", "Resort Dining", "Hotels" };
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            //SetContentView (Resource.Layout.Main);
            listAdapter = new ArrayAdapter<string>(this, Resource.Layout.mainrow, parkActivities);
            ListAdapter = listAdapter;
        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            Type ActivityToCall = null;
            string requestType = "";
            base.OnListItemClick(l, v, position, id);
            switch (position) {
                case 0: //attractions                    
                    ActivityToCall = typeof(ParksActivity);
                    requestType = "attraction";
                    break;
                case 1: // dining
                    ActivityToCall = typeof(ParksActivity);
                    requestType = "dining";
                    break;
                case 2: // resort dining
                    ActivityToCall = typeof(Resort_Dining_Activity);
                    break;
                case 3: //hotels
                    ActivityToCall = typeof(Hotels_Activity);
                    break;
            }
            var intent = new Intent(this, ActivityToCall);
            intent.PutExtra("requestKey", requestType);
            StartActivity(intent);

        }
     }
}

