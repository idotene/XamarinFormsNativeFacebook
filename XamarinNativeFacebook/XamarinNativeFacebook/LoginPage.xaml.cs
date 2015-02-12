namespace XamarinNativeFacebook
{
    public partial class LoginPage
    {
        public LoginPage()
        {
            InitializeComponent();

            App.PostSuccessFacebookAction = async token =>
            {
               //you can use this token to authenticate to the server here
               //call your FacebookLoginService.LoginToServer(token)
               //I'll just navigate to a screen that displays the token:
                await Navigation.PushAsync(new DiplayTokenPage(token));

            };
        }
    }
}
