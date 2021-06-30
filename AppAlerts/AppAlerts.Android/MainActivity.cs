using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Android.Content;
using Android.Util;
using Java.Util;

namespace AppAlerts.Droid
{
    [Activity(Label = "AppAlerts", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Intent intent = new Intent(AlarmClock.ActionSetAlarm);
            //intent.PutExtra(AlarmClock.ExtraHour, 12);
            //intent.PutExtra(AlarmClock.ExtraMinutes, 20);

            //intent.PutExtra(AlarmClock.ExtraMessage, "inicio de sincronizacion de precios");
            //if(intent.ResolveActivity(PackageManager)!=null)
            //{
            //    StartActivity(intent);
            //}
            //else
            //{
            //    Toast.MakeText(this, "no soportado", ToastLength.Long).Show();
            //}
            //-----------------full
            //AlarmManager alarmManager = (AlarmManager)GetSystemService(Context.AlarmService);
            //Intent intent = new Intent(this, Java.Lang.Class.FromType(typeof(AlertReceiver)));
            //PendingIntent pendingIntent = PendingIntent.GetBroadcast(this, 1, intent, 0);
            //TimeSpan ts = new TimeSpan(14, 11, 0);
            //long mil = long.Parse(ts.TotalMilliseconds.ToString());

            //Calendar calendar = Calendar.GetInstance(Locale.Default);
            
            //calendar.Set(Java.Util.CalendarField.HourOfDay, 14);
            //calendar.Set(Java.Util.CalendarField.Minute, 18);
            //calendar.Set(Java.Util.CalendarField.Second, 30);


            //alarmManager.Set(AlarmType.RtcWakeup,calendar.Get(CalendarField.Millisecond), pendingIntent);




            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}