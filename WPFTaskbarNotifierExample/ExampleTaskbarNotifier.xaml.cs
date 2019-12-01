using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using WPFTaskbarNotifier;

namespace WPFTaskbarNotifierExample
{
    public partial class ExampleTaskbarNotifier : INotificationHandler
    {
        public ExampleTaskbarNotifier()
        {
            InitializeComponent();
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            this.ForceHidden();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost/Client-side/auth/special_login?identity=m.taftazani123@gmail.com&password=nagaapi1");
        }

        public ObservableCollection<NotificationItem> NotifyContent { get; } = new ObservableCollection<NotificationItem>();

        public void OnNewNotifications(IEnumerable<NotificationItem> notifications)
        {
            //throw new NotImplementedException();

            foreach (var notification in notifications) 
            {
                NotifyContent.Add(notification);
            }

            Notify();
        }
    }
}