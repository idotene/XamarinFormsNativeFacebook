using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MonoTouch.FacebookConnect;
using UIKit;

namespace XamarinNativeFacebook.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private UIWindow _window;
        private const string FacebookAppId = "{YOUR FB APP ID HERE}";
        private const string FacebookAppName = "{YOUR FB APP NAME HERE}";

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
           Xamarin.Forms.Forms.Init();
           _window = new UIWindow(UIScreen.MainScreen.Bounds);

           FBSettings.DefaultAppID = FacebookAppId;
           FBSettings.DefaultDisplayName = FacebookAppName;


            return base.FinishedLaunching(app, options);
        }


        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            base.OpenUrl(application, url, sourceApplication, annotation);
            return FBSession.ActiveSession.HandleOpenURL(url);
        }

        public override void OnActivated(UIApplication application)
        {
            base.OnActivated(application);
            // We need to properly handle activation of the application with regards to SSO
            // (e.g., returning from iOS 6.0 authorization dialog or from fast app switching).
            FBSession.ActiveSession.HandleDidBecomeActive();
        }
    }
}
