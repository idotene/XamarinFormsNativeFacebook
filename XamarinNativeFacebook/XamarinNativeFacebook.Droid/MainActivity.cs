using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace XamarinNativeFacebook.Droid
{
    [Activity(Label = "XamarinNativeFacebook", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.FirstUser)
            {
                var token = data.GetStringExtra("facebookToken");
                App.PostSuccessFacebookAction(token);
            }

        }
    }
}

