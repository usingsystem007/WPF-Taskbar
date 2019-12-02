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
using Hardcodet.Wpf.TaskbarNotification;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;

namespace WPFTaskbarNotifierExample
{
    public partial class ExampleTaskbarNotifier : INotificationHandler
    {
        private string Text;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem exitMenu;
        private System.Windows.Forms.MenuItem openMenu;
        private System.Windows.Forms.MenuItem separMenu;
        private System.ComponentModel.IContainer components;

        public ExampleTaskbarNotifier()
        {
            this.Topmost = true;

            this.components = new System.ComponentModel.Container();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.exitMenu = new System.Windows.Forms.MenuItem();
            this.openMenu = new System.Windows.Forms.MenuItem();
            this.separMenu = new System.Windows.Forms.MenuItem();

            // Initialize contextMenu1
            this.contextMenu1.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[] { this.exitMenu, this.separMenu, this.openMenu});

            // Initialize exitMenu
            this.exitMenu.Index = 2;
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);

            // Initialize openMenu
            this.openMenu.Index = 0;
            this.openMenu.Text = "Open";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            //this.openMenu.MenuItems.Add(new ToolStripSeparator());

            // Initialize separatorMenu
            this.separMenu.Index = 1;
            this.separMenu.Text = "-";

            // Create the NotifyIcon.
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);

            // The Icon property sets the icon that will appear
            // in the systray for this application.
            notifyIcon1.Icon = new Icon("../../Resources/amcc.ico");

            // The ContextMenu property sets the menu that will
            // appear when the systray icon is right clicked.
            notifyIcon1.ContextMenu = this.contextMenu1;

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            notifyIcon1.Text = "KRT Systems";
            notifyIcon1.Visible = true;

            InitializeComponent();
        }

        private void openMenu_Click(object Sender, EventArgs e)
        {
            this.Show();
        }

        private void exitMenu_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application.
            this.Close();
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