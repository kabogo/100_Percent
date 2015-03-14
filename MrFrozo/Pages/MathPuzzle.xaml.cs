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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MrFrozo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MathPuzzle : Page
    {
        public MathPuzzle()
        {
            this.InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if((string)btn2.Content==null)
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
            if((string)btn1.Content=="1" && (string)btn2.Content=="2" && (string)btn3.Content=="3" && (string)btn4.Content=="4" 
                &&(string)btn5.Content=="5" &&(string)btn6.Content=="6" &&(string)btn7.Content=="7" &&(string)btn8.Content=="8" &&(string)btn9.Content==null)
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

            btn1.Content= numbers[0];
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
 