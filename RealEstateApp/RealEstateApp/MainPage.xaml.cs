namespace RealEstateApp;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
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

		//LocalNotificationCenter.Current.Clear();
		//count++;

		//if (count == 1)
		//	CounterBtn.Text = $"Clicked {count} time";
		//else
		//	CounterBtn.Text = $"Clicked {count} times";

		//SemanticScreenReader.Announce(CounterBtn.Text);

	}
}


