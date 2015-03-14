using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace MrFrozo
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

            this.DBLocation = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "frozodb.sqlite");

            try
            {
                using (var db = new SQLite.SQLiteConnection(this.DBLocation))
                {
                    db.CreateTable<Picture>();
                }

                SaveImages();
            }
            catch (Exception) { }


#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        public string DBLocation { get; set; }

        public void SaveImages()
        {
            using (var db = new SQLite.SQLiteConnection(this.DBLocation))
            {
                db.Insert(new Picture
                    {
                        ImageSource = "ms-appx:///Animals/cat.jpg",
                        ImageName="Cat"
                    });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/chick.jpg",
                    ImageName = "Chick"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/cow.jpg",
                    ImageName = "Cow"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/dog.jpg",
                    ImageName = "Dog"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/elephant.jpg",
                    ImageName = "Elephant"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/fox.jpg",
                    ImageName = "Fox"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/girrafe.jpg",
                    ImageName = "Giraffe"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/goat.jpg",
                    ImageName = "Goat"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/cock.jpg",
                    ImageName = "Cock"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/hyena.jpg",
                    ImageName = "Hyena"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/leopard.jpg",
                    ImageName = "Leopard"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/lion.jpg",
                    ImageName = "Lion"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/pig.jpg",
                    ImageName = "Pig"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/rhino.jpg",
                    ImageName = "Rhino"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/sheep.jpg",
                    ImageName = "Sheep"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/squirrel.jpg",
                    ImageName = "Squirrel"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/tiger.jpg",
                    ImageName = "Tiger"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Animals/zebra.jpg",
                    ImageName = "Zebra"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///People/boy.jpg",
                    ImageName = "Boy"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///People/girl.jpg",
                    ImageName = "Girl"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Signs/bicycle sign.jpg",
                    ImageName = "Bicycle sign"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Signs/bumps ahead.jpg",
                    ImageName = "Bumps ahead"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Signs/children crossing sign.jpg",
                    ImageName = "Children Crossing"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Signs/pedestrian crossing ahead.jpg",
                    ImageName = "Pedestrian Crossing"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Signs/railway Station.jpg",
                    ImageName = "Railway Station"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Vehicles/bicycle.jpg",
                    ImageName = "Bicycle"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Vehicles/bike.jpg",
                    ImageName = "Motor Bike"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Vehicles/bus.jpg",
                    ImageName = "Bus"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Vehicles/car.jpg",
                    ImageName = "Car"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Vehicles/plane.jpg",
                    ImageName = "Plane"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Vehicles/ship.jpg",
                    ImageName = "Ship"
                });

                db.Insert(new Picture
                {
                    ImageSource = "ms-appx:///Vehicles/train.jpg",
                    ImageName = "Train"
                });
            }
            
        }
    }
}
