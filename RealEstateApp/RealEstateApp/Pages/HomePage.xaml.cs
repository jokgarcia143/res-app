using Plugin.LocalNotification;
using RealEstateApp.Models;
using RealEstateApp.Services;

namespace RealEstateApp.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		LblUserName.Text = "Hi " + Preferences.Get("username", string.Empty);
		GetCategories();
		GetTrendingProperties();

	}

    private async void GetTrendingProperties()
    {
		var properties = await ApiService.GetTrendingProperties();
		CvTopPicks.ItemsSource = properties;
    }

    private async void GetCategories()
    {
	 	var categories = await ApiService.GetCategories();
		CvCategories.ItemsSource = categories;
    }

    void CvCategories_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
		var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
		if (currentSelection == null) return;
		Navigation.PushAsync(new PropertiesListPage(currentSelection.Id, currentSelection.Name));
		((CollectionView)sender).SelectedItem = null;
    }

    void CvTopPicks_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as TrendingProperty;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new PropertyDetailPage(currentSelection.Id));
        ((CollectionView)sender).SelectedItem = null;
    }

    void TapSearch_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Navigation.PushModalAsync(new SearchPage());
    }

    private void BtnNotify_Clicked(object sender, EventArgs e)
    {
        var request = new NotificationRequest
        {
            NotificationId = 12345,
            Title = "Welcome! to RES",
            Subtitle = "Training",
            Description = "Invest Now!",
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
