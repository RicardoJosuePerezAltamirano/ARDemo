using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace AppAlerts.Droid
{
    [BroadcastReceiver(Enabled =true)]
    public class AlertReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {

            NotificationHelper notificationHelper = new NotificationHelper(context);
            NotificationCompat.Builder nb = notificationHelper.getChannelNotification();
            notificationHelper.GetManager().Notify(1, nb.Build());

        }
    }

}