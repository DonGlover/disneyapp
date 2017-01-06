using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace disneyapp.models
{
    class restaurantDetail
    {
        public string name { get; set; }
        public string permalink { get; set; }
        public string category_code { get; set; }
        public string portion_size { get; set; }
        public string cost_code { get; set; }
        public string cuisine { get; set; }
        public string phone_number { get; set; }
        public string entree_range { get; set; }
        public string when_to_go { get; set; }
        public string parking { get; set; }
        public string bar { get; set; }
        public string wine_list { get; set; }
        public string dress { get; set; }
        public string awards { get; set; }
        public string breakfast_hours { get; set; }
        public string lunch_hours { get; set; }
        public string dinner_hours { get; set; }
        public string house_specialties { get; set; }
        public string counter_quality_rating { get; set; }
        public string counter_value_rating { get; set; }
        public string table_quality_rating { get; set; }
        public string table_value_rating { get; set; }
        public string overall_rating { get; set; }
        public string service_rating { get; set; }
        public string friendliness_rating { get; set; }
        public string thumbs_up { get; set; }
        public string adult_breakfast_menu_url { get; set; }
        public string adult_lunch_menu_url { get; set; }
        public string adult_dinner_menu_url { get; set; }
        public string child_breakfast_menu_url { get; set; }
        public string child_lunch_menu_url { get; set; }
        public string child_dinner_menu_url { get; set; }
        public string requires_credit_card { get; set; }
        public string requires_pre_payment { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string extinct_on { get; set; }
        public string opened_on { get; set; }
        public string disney_permalink { get; set; }
        public string code { get; set; }
        public string short_name { get; set; }
        public string accepts_tiw { get; set; }
        public string accepts_reservations { get; set; }
        public string kosher_available { get; set; }
        public string location_details { get; set; }
        public string operator_id { get; set; }
        public string operator_url { get; set; }
        public string operator_type { get; set; }
        public string walking_time_proxy_id { get; set; }
    }
}