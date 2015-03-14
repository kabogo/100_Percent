using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
//using System.Threading;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MrFrozo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MathAdditionPage : Page
    {
        int one, two, three, four, five, six, seven, eight, nine, ten, value, page = 1;

        public MathAdditionPage()
        {
            this.InitializeComponent();
        }

        private async void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtAnswer1.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txtAnswer1.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAnswer3.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtAnswer2.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txtAnswer2.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAnswer3.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtAnswer3.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txtAnswer3.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAnswer3.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtAnswer4.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txtAnswer4.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAnswer3.BorderThickness = new Thickness(3);
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtAnswer5.Text))
            {
                MessageDialog msg = new MessageDialog("Must fill in this answer");
                await msg.ShowAsync();
                txtAnswer5.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAnswer3.BorderThickness = new Thickness(3);
                return;
            }
            int count = 5;
            int num1 = Convert.ToInt32(this.txtNum1.Text);
            int num2 = Convert.ToInt32(this.txtNum2.Text);
            int num3 = Convert.ToInt32(this.txtNum3.Text);
            int num4 = Convert.ToInt32(this.txtNum4.Text);
            int num5 = Convert.ToInt32(this.txtNum5.Text);
            int num6 = Convert.ToInt32(this.txtNum6.Text);
            int num7 = Convert.ToInt32(this.txtNum7.Text);
            int num8 = Convert.ToInt32(this.txtNum8.Text);
            int num9 = Convert.ToInt32(this.txtNum9.Text);
            int num10 = Convert.ToInt32(this.txtNum10.Text);

            int proposedAnswer1 = Convert.ToInt32(this.txtAnswer1.Text);
            int proposedAnswer2 = Convert.ToInt32(this.txtAnswer2.Text);
            int proposedAnswer3 = Convert.ToInt32(this.txtAnswer3.Text);
            int proposedAnswer4 = Convert.ToInt32(this.txtAnswer4.Text);
            int proposedAnswer5 = Convert.ToInt32(this.txtAnswer5.Text);

            int answer1 = num1 + num2;
            int answer2 = num3 + num4;
            int answer3 = num5 + num6;
            int answer4 = num7 + num8;
            int answer5 = num9 + num10;

            //if (proposedAnswer1 != answer1)
            //{
            //    this.txtAnswer1.BorderBrush = new SolidColorBrush(Colors.Red);
            //    MessageDialog msg = new MessageDialog("Sorry. Answer is wrong. Try Again");
            //    await msg.ShowAsync();
            //    return;
            //}

            value = VerifyAnswer(proposedAnswer1, answer1, ref count, txtAnswer1);
            value = VerifyAnswer(proposedAnswer2, answer2, ref count, txtAnswer2);
            value = VerifyAnswer(proposedAnswer3, answer3, ref count, txtAnswer3);
            value = VerifyAnswer(proposedAnswer4, answer4, ref count, txtAnswer4);
            value = VerifyAnswer(proposedAnswer5, answer5, ref count, txtAnswer5);

            if (value == 0)
            {
                MessageDialog msg = new MessageDialog("Congratulations! Answer is correct");
                await msg.ShowAsync();
                PopulateQuestion();

                txtAnswer1.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtAnswer2.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtAnswer3.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtAnswer4.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtAnswer5.BorderBrush = new SolidColorBrush(Colors.Blue);
                page++;

                if(page > 3)
                {
                    MessageDialog message = new MessageDialog("OBJECTIVE COMPLETE");
                    await message.ShowAsync();
                    this.Frame.Navigate(typeof(WelcomePage));
                }
                
                else
                {
                    tbkPage.Text = "Page " + page.ToString() + " of 3";
                }
            }
            else
            {
                MessageDialog msg = new MessageDialog("You have failed " + count.ToString() + " questions.");
                await msg.ShowAsync();

                //PopulateQuestion();
            }
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateQuestion();
        }

        private void PopulateQuestion()
        {
            Random rand = new Random();
            one = rand.Next(400);
            two = rand.Next(400);
            three = rand.Next(400);
            four = rand.Next(400);
            five = rand.Next(400);
            six = rand.Next(400);
            seven = rand.Next(400);
            eight = rand.Next(400);
            nine = rand.Next(400);
            ten = rand.Next(400);
            
            this.txtNum1.Text = one.ToString();
            this.txtNum2.Text = two.ToString();
            this.txtNum3.Text = three.ToString();
            this.txtNum4.Text = four.ToString();
            this.txtNum5.Text = five.ToString();
            this.txtNum6.Text = six.ToString();
            this.txtNum7.Text = seven.ToString();
            this.txtNum8.Text = eight.ToString();
            this.txtNum9.Text = nine.ToString();
            this.txtNum10.Text = ten.ToString();

            this.txtAnswer1.Text = "";
            this.txtAnswer2.Text = "";
            this.txtAnswer3.Text = "";
            this.txtAnswer4.Text = "";
            this.txtAnswer5.Text = "";

            this.txtAnswer1.Focus(FocusState.Keyboard);
        }

        private int VerifyAnswer(int proposedAnswer,int answer,ref int count,TextBox txt)
        {
            if(proposedAnswer!=answer)
            {
                txt.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            else if(proposedAnswer==answer)
            {
                txt.BorderBrush = new SolidColorBrush(Colors.Green);
                count--;
            }

            return count;
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (((uint)e.Key >= (uint)Windows.System.VirtualKey.Number0 && (uint)e.Key <= (uint)Windows.System.VirtualKey.Number9) || ((uint)e.Key >= (uint)Windows.System.VirtualKey.NumberPad0 && (uint)e.Key <= (uint)Windows.System.VirtualKey.NumberPad9))
                e.Handled = false;

            else e.Handled = true;
        }

        private void txtAnswer1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(this.txtAnswer1.Text))
            {
                txtAnswer1.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtAnswer1.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txtAnswer1.Text))
            {
                txtAnswer1.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAnswer1.BorderThickness = new Thickness(3);
            }
        }

        private void txtAnswer2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtAnswer2.Text))
            {
                txtAnswer2.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtAnswer2.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txtAnswer1.Text))
            {
                txtAnswer2.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAnswer2.BorderThickness = new Thickness(3);
            }
        }

        private void txtAnswer3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtAnswer3.Text))
            {
                txtAnswer3.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtAnswer3.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txtAnswer3.Text))
            {
                txtAnswer3.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAnswer3.BorderThickness = new Thickness(3);
            }
        }

        private void txtAnswer4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtAnswer4.Text))
            {
                txtAnswer4.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtAnswer4.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txtAnswer1.Text))
            {
                txtAnswer4.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAnswer4.BorderThickness = new Thickness(3);
            }
        }

        private void txtAnswer5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtAnswer5.Text))
            {
                txtAnswer5.BorderBrush = new SolidColorBrush(Colors.Blue);
                txtAnswer5.BorderThickness = new Thickness(2);
            }

            else if (string.IsNullOrWhiteSpace(this.txtAnswer1.Text))
            {
                txtAnswer5.BorderBrush = new SolidColorBrush(Colors.Red);
                txtAnswer5.BorderThickness = new Thickness(3);
            }
        }
    }
}
