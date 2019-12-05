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
                var hitung = await GetCountAsync();

                foreach (var data in hitung) {
                    if (count != Convert.ToDouble(data.Jumlah))
                    {
                        // get notifications
                        var notification = await GetNotificationsAsync();

                        // notify handler
                        handler.OnNewNotifications(notification);

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

        private Task<IEnumerable<NotificationItem>> GetCountAsync()
        {
            // get count from server
            return api.CountDataAsync(@"http://localhost/Client-side/pengajuan/count/");
        }
    }
}
