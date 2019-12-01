using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using WPFTaskbarNotifier;

namespace WPFTaskbarNotifierExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {
        private CancellationTokenSource _cts;
        private NotificationService _service;
        private Task _runningTask;

        public App()
        {
            _service = new NotificationService();
        }

        public async void Start(object sender, StartupEventArgs e)
        {
            _cts = new CancellationTokenSource();
            var window = new ExampleTaskbarNotifier();
            _runningTask = _service.RunAsync(window, _cts.Token);

            // show window
            window.Show();

            //return Task.CompletedTask;
        }

        public async void Stop(object sender, ExitEventArgs e)
        {
            if (_cts == null)
            {
                return;
            }

            if (_runningTask == null || _runningTask.IsCompleted)
            {
                _cts.Dispose();
            }

            try
            {
                _cts.Cancel();
            }
            finally
            {
                await _runningTask;
                _cts.Dispose();
            }
        }
    }
}