using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPFTaskbarNotifier
{
    public class NotificationService
    {
        public static double count = 0;

        public async Task RunAsync(INotificationHandler handler, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                // get notifications
                var notifications = await GetNotificationsAsync();

                foreach (var data in notifications) {
                    if (count != Convert.ToDouble(data.Jumlah))
                    {
                        // notify handler
                        handler.OnNewNotifications(notifications);

                        // wait for 10 seconds
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        count = Convert.ToDouble(data.Jumlah);
                    }
                    else 
                    {
                        count = Convert.ToDouble(data.Jumlah);
                    } 
                }
            }
        }
        
        private RestApiSetup api = new RestApiSetup();

        private Task<IEnumerable<NotificationItem>> GetNotificationsAsync()
        {
            // get from server
            return api.LoadDataAsync(@"http://localhost/Client-side/pengajuan/");
        }

        //private Task<IEnumerable<NotificationItem>> GetCountAsync()
        //{
        //    return api.CountDataAsync(@"http://localhost/Client-side/pengajuan/count");
        //}
    }
}
