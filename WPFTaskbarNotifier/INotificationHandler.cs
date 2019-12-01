using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTaskbarNotifier
{
    public interface INotificationHandler
    {
        void OnNewNotifications(IEnumerable<NotificationItem> notifications);
    }
}
