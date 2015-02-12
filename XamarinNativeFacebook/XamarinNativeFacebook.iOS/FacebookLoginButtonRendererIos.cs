using MonoTouch.FacebookConnect;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinNativeFacebook;
using XamarinNativeFacebook.iOS;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(FacebookLoginButtonRendererIos))]
namespace XamarinNativeFacebook.iOS
{
    public class FacebookLoginButtonRendererIos : ButtonRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                UIButton button = Control;

                button.TouchUpInside += delegate
                {
                    HandleFacebookLoginClicked();
                };
            }
        }

        private void HandleFacebookLoginClicked()
        {
            if (FBSession.ActiveSession.IsOpen)
            {
                App.PostSuccessFacebookAction(FBSession.ActiveSession.AccessTokenData.AccessToken);
            }
            else
            {
                FBSession.ActiveSession.Open(FBSessionLoginBehavior.UseSystemAccountIfPresent, (aSession, status, error) =>
                {
                    if (error == null)
                    {
                        App.PostSuccessFacebookAction(aSession.AccessTokenData.AccessToken);
                    }
                });
            }

        }
    }
}