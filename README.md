XamarinNativeFacebook
Integrate Facebook Native behaviour to Xamarin Forms.

This project demonstrates how to use the native Facebook sdk in order to have the known user expirience as in native applications. Using this guide, you will be able to use the system authentication like using the instaled Facebook app / system account, or finally as a fallbcak open a webview.

The existing solutions for xamarin like Xamarin.Auth, do not support in native login yet, only web view.

Steps to set up your project:

Installation:

1) For Android download from nuget/Components the Facebook Android SDK: http://components.xamarin.com/view/facebookandroid and place it in your droid project.

2) For iOS download from nuget/Components the Facebook iOS SDK: http://components.xamarin.com/view/facebookios and place it in your iOS project.

Set up components:

Shared code set up:

1) Add a FacebookLoginButton which inherits from Button, leave it without any implementation

2) Add that button to the login page

3)Add to App.cs the following property:

           public static Action<string> PostSuccessFacebookAction { get; set; } 
           
4) in the LoginPage.xaml.cs (or in the viewmodel class if you have one), add the navigation for this action:

            App.PostSuccessFacebookAction = async token =>
            {
               //you can use this token to authenticate to the server here
               //call your FacebookLoginService.LoginToServer(token)
               //I'll just navigate to a screen that displays the token:
                await Navigation.PushAsync(new DiplayTokenPage(token));

            };
Android: 1) Add to strings.xml file (found at Resources/Valus) The following lines {Your App Id Here} {Your App Name}

2) Add to Manifest.xml the following code:

3) Create activity class for facebook (I called it FacebookActivity)

4) Create a custom rendrer for the facebook Login button (I called it FacebookLoginButtonRendererAndroid)

5) Add to mainActivity class The OnActionResult method to handle response from the FacebookActivity

iPhone:

1) In AppDelegate class, register in method FinishedLaunching the following:

       FBSettings.DefaultAppID = FacebookAppId;
       FBSettings.DefaultDisplayName = FacebookAppName;
2) Override the following methods:

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
3) Create a custom rendrer for the facebook Login button (I called it FacebookLoginButtonRendererIos)
