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
using AppAlerts.Droid;
using Java.Lang;
using Java.Util;


[assembly: Xamarin.Forms.Dependency(typeof(AlarmGenerator))]
namespace AppAlerts.Droid
{
    
    public class AlarmGenerator : IAlarmGenerator
    {
        public void Generate(int hora,int minuto)
        {
            if(DateTime.Now.DayOfWeek== DayOfWeek.Friday)
            {
                AlarmManager alarmManager = (AlarmManager)Android.App.Application.Context.GetSystemService(Context.AlarmService);
                Intent intent = new Intent(Android.App.Application.Context, Java.Lang.Class.FromType(typeof(AlertReceiver)));
                PendingIntent pendingIntent = PendingIntent.GetBroadcast(Android.App.Application.Context, 1, intent, 0);
                //TimeSpan ts = new TimeSpan(hora, minuto, 0);
                //TimeSpan ts2=new TimeSpan()
                //System.Diagnostics.Debug.WriteLine($"segundos del time span {ts}");
                //System.Diagnostics.Debug.WriteLine($"segundos de la hora actual {DateTime.Now.Second}");
                //var response =   DateTime.Now.Second- ts.Seconds;
                //long mil = long.Parse(response.ToString());//ts.TotalMilliseconds.ToString()

                Calendar calendar = Calendar.Instance;
                calendar.TimeInMillis = JavaSystem.CurrentTimeMillis();
                //calendar.TimeInMillis = DateTime.Now.Millisecond;
                calendar.Set(Java.Util.CalendarField.HourOfDay, hora);
                calendar.Set(Java.Util.CalendarField.Minute, minuto);
                //calendar.Add(CalendarField.Second, response);


                System.Diagnostics.Debug.WriteLine(calendar.Time.ToString());
                System.Diagnostics.Debug.WriteLine(calendar.TimeInMillis);
                System.Diagnostics.Debug.WriteLine(calendar.CalendarType);
                System.Diagnostics.Debug.WriteLine(calendar.TimeZone);
                System.Diagnostics.Debug.WriteLine(calendar.Get(CalendarField.Millisecond).ToString() + " milisegundos");
                //System.Diagnostics.Debug.WriteLine(response+" segundos");

                alarmManager.SetExactAndAllowWhileIdle(AlarmType.RtcWakeup, /*mil*/ /*180000*/calendar.TimeInMillis, pendingIntent);
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context, "aun no es dia para alarmas", ToastLength.Long);
            }
            
        }
    }
}