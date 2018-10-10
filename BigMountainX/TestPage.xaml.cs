using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BigMountainX
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage : Page
    {
        CommandDispatcher _dispatcher;

        public TestPage()
        {
            this.InitializeComponent();
            this.Loaded += TestPage_Loaded;
            _dispatcher = new CommandDispatcher();
            _dispatcher.DoSomething += testpage_commands;
        }

        void TestPage_Loaded(object sender, RoutedEventArgs args)
        {
            this.DataContext = _dispatcher;
        }

        void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        async void testpage_commands(string command)
        {
            if (command.ToLower() == "exit program")
            {
                MessageDialog md = new MessageDialog("Closing BigMountainX.");
                await md.ShowAsync();
                Application.Current.Exit();
            }
        }

    }
}
