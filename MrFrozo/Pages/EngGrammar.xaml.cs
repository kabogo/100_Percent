using MrFrozo.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace MrFrozo
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class EngGrammar : Page
    {
        List<Picture> picList = new List<Picture>();
        List<Picture> oldList = new List<Picture>();
        string answer1, answer2, answer3, answer4, answer5, answer6, answer7, answer8, answer9, answer10;
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public EngGrammar()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
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
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void LoadQuestions()
        {
            //Will be loaded dynamically from the database
            //There will be three sets of qns for each difficulty level
        }

        private void pageRoot_Loaded(object sender, RoutedEventArgs e)
        {
            Random random=new Random();
            Random rnd = new Random();
            var app = MrFrozo.App.Current as App;

            using (var db = new SQLite.SQLiteConnection(app.DBLocation))
            {
                picList = db.Table<Picture>().Select(x => x).ToList();
            }

            var randomList = picList.OrderBy(pic => random.Next()).Select(x => x).ToList();
            var newList = randomList.Take(10).ToList();
            oldList = newList;

            img1.Source = new BitmapImage(new Uri(newList[0].ImageSource,UriKind.RelativeOrAbsolute));
            answer1 = newList[0].ImageName;

            img2.Source = new BitmapImage(new Uri(newList[1].ImageSource, UriKind.RelativeOrAbsolute));
            answer2 = newList[1].ImageName;

            img3.Source = new BitmapImage(new Uri(newList[2].ImageSource, UriKind.RelativeOrAbsolute));
            answer3 = newList[2].ImageName;

            img4.Source = new BitmapImage(new Uri(newList[3].ImageSource, UriKind.RelativeOrAbsolute));
            answer4 = newList[3].ImageName;

            img5.Source = new BitmapImage(new Uri(newList[4].ImageSource, UriKind.RelativeOrAbsolute));
            answer5 = newList[4].ImageName;

            img6.Source = new BitmapImage(new Uri(newList[5].ImageSource, UriKind.RelativeOrAbsolute));
            answer6 = newList[5].ImageName;

            img7.Source = new BitmapImage(new Uri(newList[6].ImageSource, UriKind.RelativeOrAbsolute));
            answer7 = newList[6].ImageName;

            img8.Source = new BitmapImage(new Uri(newList[7].ImageSource, UriKind.RelativeOrAbsolute));
            answer8 = newList[7].ImageName;

            img9.Source = new BitmapImage(new Uri(newList[8].ImageSource, UriKind.RelativeOrAbsolute));
            answer9 = newList[8].ImageName;

            img10.Source = new BitmapImage(new Uri(newList[9].ImageSource, UriKind.RelativeOrAbsolute));
            answer10 = newList[9].ImageName;
            
            var orderList = newList.OrderBy(xItem => random.Next()).Select(x => x).ToList();

            foreach (var item in orderList)
            {
                lstAnswers.Items.Add(item.ImageName);
            }
        }

        private void img1_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt1.Text = listViewItem.ToString();
        }

        private void txt1_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt1.Text = listViewItem.ToString();
        }

        private void img2_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt2.Text = listViewItem.ToString();
        }

        private void txt2_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt2.Text = listViewItem.ToString();
        }

        private void img3_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt3.Text = listViewItem.ToString();
        }

        private void txt3_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt3.Text = listViewItem.ToString();
        }

        private void img4_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt4.Text = listViewItem.ToString();
        }

        private void txt4_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt4.Text = listViewItem.ToString();
        }

        private void img5_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt5.Text = listViewItem.ToString();
        }

        private void txt5_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt5.Text = listViewItem.ToString();
        }

        private void img6_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt6.Text = listViewItem.ToString();
        }

        private void txt6_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt6.Text = listViewItem.ToString();
        }

        private void img7_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt7.Text = listViewItem.ToString();
        }

        private void txt7_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt7.Text = listViewItem.ToString();
        }

        private void img8_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt8.Text = listViewItem.ToString();
        }

        private void txt8_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt8.Text = listViewItem.ToString();
        }

        private void img9_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt9.Text = listViewItem.ToString();
        }

        private void txt9_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt9.Text = listViewItem.ToString();
        }

        private void img10_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt10.Text = listViewItem.ToString();
        }

        private void txt10_Drop(object sender, DragEventArgs e)
        {
            object listView;
            object listViewItem;

            e.Data.Properties.TryGetValue("listView", out listView);

            if (listView == sender) return;

            e.Data.Properties.TryGetValue("item", out listViewItem);

            if (listViewItem == null) return;

            this.txt10.Text = listViewItem.ToString();
        }

        private void lstAnswers_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var item = e.Items.FirstOrDefault();

            if (item == null) return;

            e.Data.Properties.Add("item", item);
            e.Data.Properties.Add("listView", sender);
        }

        private async void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txt1.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txt1.BorderBrush = new SolidColorBrush(Colors.Red);
                txt1.BorderThickness = new Thickness(3);
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txt2.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txt2.BorderBrush = new SolidColorBrush(Colors.Red);
                txt2.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txt3.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txt3.BorderBrush = new SolidColorBrush(Colors.Red);
                txt3.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txt4.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txt4.BorderBrush = new SolidColorBrush(Colors.Red);
                txt4.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txt5.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txt5.BorderBrush = new SolidColorBrush(Colors.Red);
                txt5.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txt6.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txt6.BorderBrush = new SolidColorBrush(Colors.Red);
                txt6.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txt7.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txt7.BorderBrush = new SolidColorBrush(Colors.Red);
                txt7.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txt8.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txt8.BorderBrush = new SolidColorBrush(Colors.Red);
                txt8.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txt9.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txt9.BorderBrush = new SolidColorBrush(Colors.Red);
                txt9.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txt10.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txt10.BorderBrush = new SolidColorBrush(Colors.Red);
                txt10.BorderThickness = new Thickness(3);
                return;
            }

            if (this.txt1.Text!=answer1)
            {
                MessageDialog msg = new MessageDialog("This Answer is wrong");
                await msg.ShowAsync();
                txt1.BorderBrush = new SolidColorBrush(Colors.Red);
                txt1.BorderThickness = new Thickness(3);
                return;
            }
            if (this.txt2.Text!=answer2)
            {
                MessageDialog msg = new MessageDialog("This Answer is wrong");
                await msg.ShowAsync();
                txt2.BorderBrush = new SolidColorBrush(Colors.Red);
                txt2.BorderThickness = new Thickness(3);
                return;
            }

            if (this.txt3.Text!=answer3)
            {
                MessageDialog msg = new MessageDialog("This Answer is wrong");
                await msg.ShowAsync();
                txt3.BorderBrush = new SolidColorBrush(Colors.Red);
                txt3.BorderThickness = new Thickness(3);
                return;
            }

            if (this.txt4.Text!=answer4)
            {
                MessageDialog msg = new MessageDialog("This Answer is wrong");
                await msg.ShowAsync();
                txt4.BorderBrush = new SolidColorBrush(Colors.Red);
                txt4.BorderThickness = new Thickness(3);
                return;
            }

            if (this.txt5.Text!=answer5)
            {
                MessageDialog msg = new MessageDialog("This Answer is wrong");
                await msg.ShowAsync();
                txt5.BorderBrush = new SolidColorBrush(Colors.Red);
                txt5.BorderThickness = new Thickness(3);
                return;
            }

            if (this.txt6.Text!=answer6)
            {
                MessageDialog msg = new MessageDialog("This Answer is wrong");
                await msg.ShowAsync();
                txt6.BorderBrush = new SolidColorBrush(Colors.Red);
                txt6.BorderThickness = new Thickness(3);
                return;
            }

            if (this.txt7.Text!=answer7)
            {
                MessageDialog msg = new MessageDialog("This Answer is wrong");
                await msg.ShowAsync();
                txt7.BorderBrush = new SolidColorBrush(Colors.Red);
                txt7.BorderThickness = new Thickness(3);
                return;
            }

            if (this.txt8.Text!=answer8)
            {
                MessageDialog msg = new MessageDialog("This Answer is wrong");
                await msg.ShowAsync();
                txt8.BorderBrush = new SolidColorBrush(Colors.Red);
                txt8.BorderThickness = new Thickness(3);
                return;
            }

            if (this.txt9.Text!=answer9)
            {
                MessageDialog msg = new MessageDialog("This Answer is wrong");
                await msg.ShowAsync();
                txt9.BorderBrush = new SolidColorBrush(Colors.Red);
                txt9.BorderThickness = new Thickness(3);
                return;
            }

            if (this.txt10.Text!=answer10)
            {
                MessageDialog msg = new MessageDialog("This Answer is wrong");
                await msg.ShowAsync();
                txt10.BorderBrush = new SolidColorBrush(Colors.Red);
                txt10.BorderThickness = new Thickness(3);
                return;
            }

            MessageDialog message = new MessageDialog("All answers are correct", "Congratulations");
            await message.ShowAsync();

            this.Frame.Navigate(typeof(WelcomePage));
        }

        private void txt1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txt1.Text))
            {
                txt1.BorderBrush = new SolidColorBrush(Colors.Blue);
                txt1.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txt1.Text))
            {
                txt1.BorderBrush = new SolidColorBrush(Colors.Red);
                txt1.BorderThickness = new Thickness(3);
            }
        }

        private void txt2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txt2.Text))
            {
                txt2.BorderBrush = new SolidColorBrush(Colors.Blue);
                txt2.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txt2.Text))
            {
                txt2.BorderBrush = new SolidColorBrush(Colors.Red);
                txt2.BorderThickness = new Thickness(3);
            }
        }

        private void txt3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txt3.Text))
            {
                txt3.BorderBrush = new SolidColorBrush(Colors.Blue);
                txt3.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txt3.Text))
            {
                txt3.BorderBrush = new SolidColorBrush(Colors.Red);
                txt3.BorderThickness = new Thickness(3);
            }
        }

        private void txt4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txt4.Text))
            {
                txt4.BorderBrush = new SolidColorBrush(Colors.Blue);
                txt4.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txt4.Text))
            {
                txt4.BorderBrush = new SolidColorBrush(Colors.Red);
                txt4.BorderThickness = new Thickness(3);
            }
        }

        private void txt5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txt5.Text))
            {
                txt5.BorderBrush = new SolidColorBrush(Colors.Blue);
                txt5.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txt5.Text))
            {
                txt5.BorderBrush = new SolidColorBrush(Colors.Red);
                txt5.BorderThickness = new Thickness(3);
            }
        }

        private void txt6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txt6.Text))
            {
                txt6.BorderBrush = new SolidColorBrush(Colors.Blue);
                txt6.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txt6.Text))
            {
                txt6.BorderBrush = new SolidColorBrush(Colors.Red);
                txt6.BorderThickness = new Thickness(3);
            }
        }

        private void txt7_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txt7.Text))
            {
                txt7.BorderBrush = new SolidColorBrush(Colors.Blue);
                txt7.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txt7.Text))
            {
                txt7.BorderBrush = new SolidColorBrush(Colors.Red);
                txt7.BorderThickness = new Thickness(3);
            }
        }

        private void txt8_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txt8.Text))
            {
                txt8.BorderBrush = new SolidColorBrush(Colors.Blue);
                txt8.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txt8.Text))
            {
                txt8.BorderBrush = new SolidColorBrush(Colors.Red);
                txt8.BorderThickness = new Thickness(3);
            }
        }

        private void txt9_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txt9.Text))
            {
                txt9.BorderBrush = new SolidColorBrush(Colors.Blue);
                txt9.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txt9.Text))
            {
                txt9.BorderBrush = new SolidColorBrush(Colors.Red);
                txt9.BorderThickness = new Thickness(3);
            }
        }

        private void txt10_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txt10.Text))
            {
                txt10.BorderBrush = new SolidColorBrush(Colors.Blue);
                txt10.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txt10.Text))
            {
                txt10.BorderBrush = new SolidColorBrush(Colors.Red);
                txt10.BorderThickness = new Thickness(3);
            }
        }
    }
}
