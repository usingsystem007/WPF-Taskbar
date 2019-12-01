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
        public async Task RunAsync(INotificationHandler handler, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                // get notifications
                var notifications = await GetNotificationsAsync();

                // notify handler
                handler.OnNewNotifications(notifications);

                // wait for 10 seconds
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
        
        private RestApiSetup api = new RestApiSetup();

        private Task<IEnumerable<NotificationItem>> GetNotificationsAsync()
        {
            // get from server
            //throw new NotImplementedException();
            return api.LoadDataAsync(@"http://localhost/Client-side/pengajuan/");
        }

        private Task<IEnumerable<NotificationItem>> GetCountAsync()
        {
            return api.CountDataAsync(@"http://localhost/Client-side/pengajuan/count");
        }
    }
}
