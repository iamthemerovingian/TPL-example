using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MyLogin
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginButton.IsEnabled = false;

            var task = Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Login Succesful!!";
            });


            task.ContinueWith((t) => 
            {
                try
                {
                    Dispatcher.Invoke(() =>
                    {
                        LoginButton.Content = task.Result;
                        LoginButton.IsEnabled = true;
                    });
                }
                catch (Exception ex)
                {
                    
                }
            });
        }
    }
}
