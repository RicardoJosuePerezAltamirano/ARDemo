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
    public class NotificationHelper:ContextWrapper
    {
        public static string channelID = "channelID";
    public static string channelName = "Channel Name";
        private NotificationManager mManager;
        Context Contextn;
        public NotificationHelper(Context context):base(context)
        {
            if(Build.VERSION.SdkInt>=Android.OS.BuildVersionCodes.O)
            {
                createChannel();
            }
            this.Contextn = context;
        }
        private void createChannel()
        {
            NotificationChannel channel = new NotificationChannel(channelID, channelName, Android.App.NotificationImportance.High);
            GetManager().CreateNotificationChannel(channel);


        }
        public NotificationManager GetManager()
        {
            if(mManager==null)
            {
                mManager = (NotificationManager)GetSystemService(Context.NotificationService);
            }
            return mManager;
        }
        public NotificationCompat.Builder getChannelNotification()
        {
            return new NotificationCompat.Builder(Contextn, channelID)
                .SetContentTitle("sincronizacion de precios")
                .SetContentText("inicia la sincronizacion de precios")
                .SetSmallIcon(AppAlerts.Droid.Resource.Drawable.abc_ic_voice_search_api_material);
        }
    }
}