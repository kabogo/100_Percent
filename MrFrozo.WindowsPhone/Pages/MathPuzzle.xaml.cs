using MrFrozo.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MrFrozo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MathPuzzle : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public MathPuzzle()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btn2.Content == null)
            {
                btn2.Content = btn1.Content;
                btn1.Content = null;
            }

            else if ((string)btn4.Content == null)
            {
                btn4.Content = btn1.Content;
                btn1.Content = null;
            }

            CheckWin();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btn1.Content == null)
            {
                btn1.Content = btn2.Content;
                btn2.Content = null;
            }

            else if ((string)btn3.Content == null)
            {
                btn3.Content = btn2.Content;
                btn2.Content = null;
            }

            else if ((string)btn5.Content == null)
            {
                btn5.Content = btn2.Content;
                btn2.Content = null;
            }

            CheckWin();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btn2.Content == null)
            {
                btn2.Content = btn3.Content;
                btn3.Content = null;
            }

            else if ((string)btn6.Content == null)
            {
                btn6.Content = btn3.Content;
                btn3.Content = null;
            }

            CheckWin();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btn1.Content == null)
            {
                btn1.Content = btn4.Content;
                btn4.Content = null;
            }

            else if ((string)btn5.Content == null)
            {
                btn5.Content = btn4.Content;
                btn4.Content = null;
            }

            else if ((string)btn7.Content == null)
            {
                btn7.Content = btn4.Content;
                btn4.Content = null;
            }

            CheckWin();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btn2.Content == null)
            {
                btn2.Content = btn5.Content;
                btn5.Content = null;
            }

            else if ((string)btn4.Content == null)
            {
                btn4.Content = btn5.Content;
                btn5.Content = null;
            }

            else if ((string)btn6.Content == null)
            {
                btn6.Content = btn5.Content;
                btn5.Content = null;
            }

            else if ((string)btn8.Content == null)
            {
                btn8.Content = btn5.Content;
                btn5.Content = null;
            }

            CheckWin();
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btn3.Content == null)
            {
                btn3.Content = btn6.Content;
                btn6.Content = null;
            }

            else if ((string)btn5.Content == null)
            {
                btn5.Content = btn6.Content;
                btn6.Content = null;
            }

            else if ((string)btn9.Content == null)
            {
                btn9.Content = btn6.Content;
                btn6.Content = null;
            }

            CheckWin();
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btn4.Content == null)
            {
                btn4.Content = btn7.Content;
                btn7.Content = null;
            }

            else if ((string)btn8.Content == null)
            {
                btn8.Content = btn7.Content;
                btn7.Content = null;
            }

            CheckWin();
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btn5.Content == null)
            {
                btn5.Content = btn8.Content;
                btn8.Content = null;
            }

            else if ((string)btn7.Content == null)
            {
                btn7.Content = btn8.Content;
                btn8.Content = null;
            }

            else if ((string)btn9.Content == null)
            {
                btn9.Content = btn8.Content;
                btn8.Content = null;
            }

            CheckWin();
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btn6.Content == null)
            {
                btn6.Content = btn9.Content;
                btn9.Content = null;
            }

            else if ((string)btn8.Content == null)
            {
                btn8.Content = btn9.Content;
                btn9.Content = null;
            }

            CheckWin();
        }
        public async void CheckWin()
        {
            if ((string)btn1.Content == "1" && (string)btn2.Content == "2" && (string)btn3.Content == "3" && (string)btn4.Content == "4"
                && (string)btn5.Content == "5" && (string)btn6.Content == "6" && (string)btn7.Content == "7" && (string)btn8.Content == "8" && (string)btn9.Content == null)
            {
                btn1.IsEnabled = false;
                btn2.IsEnabled = false;
                btn3.IsEnabled = false;
                btn4.IsEnabled = false;
                btn5.IsEnabled = false;
                btn6.IsEnabled = false;
                btn7.IsEnabled = false;
                btn8.IsEnabled = false;
                btn9.IsEnabled = false;

                MessageDialog msg = new MessageDialog("Congratulations! You win");
                await msg.ShowAsync();

                btn1.IsEnabled = true;
                btn2.IsEnabled = true;
                btn3.IsEnabled = true;
                btn4.IsEnabled = true;
                btn5.IsEnabled = true;
                btn6.IsEnabled = true;
                btn7.IsEnabled = true;
                btn8.IsEnabled = true;
                btn9.IsEnabled = true;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string[] str = { "1", "2", "3", "4", "5", "6", "7", "8" };
            List<string> buttonNumbers = new List<string>();
            buttonNumbers.AddRange(str);
            Random rnd = new Random();
            var numbers = buttonNumbers.OrderBy(num => rnd.Next()).Select(x => x).ToList();

            btn1.Content = numbers[0];
            btn2.Content = numbers[1];
            btn3.Content = numbers[2];
            btn4.Content = numbers[3];
            btn5.Content = numbers[4];
            btn6.Content = numbers[5];
            btn7.Content = numbers[6];
            btn8.Content = numbers[7];
        }
    }
}
