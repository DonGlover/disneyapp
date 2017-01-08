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
    class attractionDetail
    {
        public string name { get; set; }
        public string fastpass_boothpublic { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string short_name { get; set; }
        public bool open_emh_morning { get; set; }
        public bool open_emh_evening { get; set; }
        public bool single_rider { get; set; }
        public string time_zone { get; set; }
        public bool seasonal { get; set; }
        public bool open_very_merry { get; set; }
        public bool open_not_so_scary { get; set; }
        public string category_code { get; set; }
        public string duration { get; set; }
        public string scheduled_code { get; set; }
        public string what_it_is { get; set; }
        public string scope_and_scale_code { get; set; }
        public string when_to_go { get; set; }
        public string average_wait_per_hundred { get; set; }
        public string average_wait_assumes { get; set; }
        public string loading_speed { get; set; }
        public string probable_wait_time { get; set; }
        public string special_needs { get; set; }
        public string height_restriction { get; set; }
        public bool intense { get; set; }
        public string extinct_on { get; set; }
        public string opened_on { get; set; }
        public bool frightening { get; set; }
        public bool physical_considerations { get; set; }
        public bool handheld_captioning { get; set; }
        public bool video_captioning { get; set; }
        public bool reflective_captioning { get; set; }
        public bool assistive_listening { get; set; }
        public bool audio_description { get; set; }
        public string wheelchair_transfer_code { get; set; }
        public bool no_service_animals { get; set; }
        public bool sign_language { get; set; }
        public bool service_animal_check { get; set; }
        public bool not_to_be_missed { get; set; }
        public bool rider_swap { get; set; }
        public string ultimate_code { get; set; }
        public string ultimate_task { get; set; }
        public bool park_entrance { get; set; }
        public string relative_open { get; set; }
        public string relative_close { get; set; }
        public string close_at_dusk { get; set; }
        public string crowd_calendar_version { get; set; }
        public string match_name { get; set; }
        public string crazy_threshold { get; set; }
        public bool fastpass_only { get; set; }
        public string allow_showtimes_after_close { get; set; }
        public bool disconnected_fastpass_booth { get; set; }
        public string crowd_calendar_group { get; set; }
        public string arrive_before { get; set; }
        public string arrive_before_fp { get; set; }
        public bool allow_time_restriction { get; set; }
        public string relative_open_to_sunset { get; set; }
        public string relative_close_to_sunset { get; set; }
        public string closing_round_code { get; set; }
        public string walking_time_proxy_id { get; set; }
        public string flexible_duration { get; set; }
        public string operator_id { get; set; }
        public string operator_type { get; set; }

    }
}