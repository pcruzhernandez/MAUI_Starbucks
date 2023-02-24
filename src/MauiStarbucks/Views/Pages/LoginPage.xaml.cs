namespace MauiStarbucks.Views.Pages;

public partial class LoginPage : ContentPage
{
    readonly ILoginRepository _loginRepository = new LoginService();
    
    public LoginPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        string userName = Username.Text;
        string password = Password.Text;

        if(userName == null || password == null)
        {
            await DisplayAlert("Warning", "Rellene usuario y password", "Ok");
            return;
        }
        else
        {
            UserInfo userInfo = await _loginRepository.Login(userName, password);
            if (userInfo != null)
            {
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Warning", "Usuario o password incorrectos", "Ok");
            }
        }


        
    }
}