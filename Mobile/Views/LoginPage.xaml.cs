namespace AppMobile.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        // Vérification des identifiants
        if (email == "admin" && password == "admin")
        {
            await DisplayAlert("Success", "Login successful!", "OK");
            // Rediriger vers la page suivante
            await Navigation.PushAsync(new ParcsPage());
        }
        else
        {
            await DisplayAlert("Error", "Invalid email or password.", "OK");
        }
    }

}
