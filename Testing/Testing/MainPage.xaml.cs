using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace Testing;

public partial class MainPage : ContentPage
{
	int count = 0;

    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


    public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private async void OnToastClicked(object sender, EventArgs e)
	{
		CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

		string text = "This is a Toast";
		ToastDuration duration = ToastDuration.Short;
		double fontSize = 14;

		var toast = Toast.Make(text, duration, fontSize);

		await toast.Show(cancellationTokenSource.Token);

	}

	private async void OnSnackBarClicked(object sender, EventArgs e)
	{
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = Colors.Red,
            TextColor = Colors.Green,
            ActionButtonTextColor = Colors.Yellow,
            CornerRadius = new CornerRadius(10),
            Font = Microsoft.Maui.Font.SystemFontOfSize(14),
            ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14),
            CharacterSpacing = 0.5
        };

        string text = "This is a Snackbar";
        string actionButtonText = "Click Here to Dismiss";
        Action action = async () => await DisplayAlert("Snackbar ActionButton Tapped", "The user has tapped the Snackbar ActionButton", "OK");
        TimeSpan duration = TimeSpan.FromSeconds(3);

        var snackbar = Snackbar.Make(text, action, actionButtonText, duration, snackbarOptions);

        await snackbar.Show(cancellationTokenSource.Token);
    }
}



