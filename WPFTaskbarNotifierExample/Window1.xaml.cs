using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPFTaskbarNotifier;

namespace WPFTaskbarNotifierExample
{
    /// <summary>
    /// An example window that adds content to the TaskbarNotifier and changes
    /// its settings.
    /// </summary>
    public partial class Window1 : System.Windows.Window
    {
        private bool reallyCloseWindow = false;

        public Window1()
        {
            this.taskbarNotifier = new ExampleTaskbarNotifier();

            InitializeComponent();

            this.taskbarNotifier.Show();
            this.Hide();
        }

        private ExampleTaskbarNotifier taskbarNotifier;
        public ExampleTaskbarNotifier TaskbarNotifier
        {
            get { return this.taskbarNotifier; }
        }

        //public ObservableCollection<NotificationItem> NotifyContent { get; } = new ObservableCollection<NotificationItem>();

        //public void OnNewNotifications(IEnumerable<NotificationItem> notifications)
        //{
        //    //throw new NotImplementedException();

        //    foreach (var notification in notifications)
        //    {
        //        Console.WriteLine($"New Notification; Jumlah = {notification.Jumlah}");
        //        NotifyContent.Add(notification);
        //    }

        //    //Notify();
        //}

        protected override void OnClosing(System.ComponentModel.CancelEventArgs args)
        {
            // In WPF it is a challenge to hide the window's close box in the title bar.
            // When the user clicks this, we don't want to exit the app, but rather just
            // put it back into hiding.  Unfortunately, this is a challenge too.
            // The follow code works around the issue.

            if (!this.reallyCloseWindow)
            {
                // Don't close, just Hide.
                args.Cancel = true;
                // Trying to hide
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate(object o)
                {
                    this.Hide();
                    return null;
                }, null);
            }
            else
            {
                // Actually closing window.

                this.NotifyIcon.Visibility = Visibility.Collapsed;

                // Close the taskbar notifier too.
                if (this.taskbarNotifier != null)
                    this.taskbarNotifier.Close();
            }
        }

        private void NotifyIcon_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                // Open the TaskbarNotifier
                this.taskbarNotifier.Notify();
            }
        }

        private void NotifyIconOpen_Click(object sender, RoutedEventArgs e)
        {
            // Open the TaskbarNotifier
            this.taskbarNotifier.Notify();
        }

        private void NotifyIconConfigure_Click(object sender, RoutedEventArgs e)
        {
            // Show this window
            this.Show();
            this.Activate();          
        }

        private void NotifyIconExit_Click(object sender, RoutedEventArgs e)
        {
            // Close this window.
            this.reallyCloseWindow = true;
            this.Close();
        }
    }
}