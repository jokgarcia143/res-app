using Plugin.LocalNotification;
using RealEstateApp.Services;

namespace RealEstateApp.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

   async void BtnRegister_Clicked(System.Object sender, System.EventArgs e)
    {
	    var response = await ApiService.RegisterUser(EntFullName.Text,EntEmail.Text,EntPassword.Text,EntPhone.Text);
		if(response)
		{
			await DisplayAlert("", "Your account has been created", "Alright");
			await Navigation.PushModalAsync(new LoginPage());
		}
		else
		{
			await DisplayAlert("", "Oops something went wrong", "Cancel");
        }
    }

    async void TapLogin_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
    }

    private void BtnNotify_Clicked(object sender, EventArgs e)
    {
        //Add Your Logic here

        var request = new NotificationRequest
        {
            NotificationId = 12345,
            Title = "Welcome! to .NET MAUI",
            Subtitle = "Training",
            Description = "Enjoy! Coding",
            BadgeNumber = 33, //Android Version
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(5),
                NotifyRepeatInterval = TimeSpan.FromDays(1)
            }
            //Android = new AndroidOptions
            //{
            //  LED/Hardware
            //}

        };

        //var n = LocalNotificationCenter.Current.AreNotificationsEnabled();
        //LocalNotificationCenter.Current.RequestNotificationPermission();
        LocalNotificationCenter.Current.Show(request);
    }
}
