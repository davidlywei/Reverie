using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
	public class PasswordPage : ContentPage
	{

		Label passwordLabel; //label displaying app name
		Label textLabel;
		Button resetButton; //reset password button
		StackLayout stackLayout; //stacklayout for page
		Password passwordInterface;
		ViewController localViewController;

		public PasswordPage(ViewController viewController)
		{
			//assign to local view controller for reset button event handler
			localViewController = viewController; 

			textLabel = new Label
			{
				Text = "Here is your password:",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.White,
				TextColor = ReverieStyles.accentGreen,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold
			};

			passwordLabel = new Label
			{
				//Text = passwordInterface.GetHash(viewController.getResponse()),
				Text = passwordInterface.GetHash("Password"),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.White,
				TextColor = ReverieStyles.accentGreen,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold
			};

			resetButton = new Button
			{
				Text = "RESET PASSWORD",
				FontSize = Device.OnPlatform(iOS: Device.GetNamedSize(NamedSize.Small, typeof(Label)),
											  Android: Device.GetNamedSize(NamedSize.Small, typeof(Label)),
											  WinPhone: Device.GetNamedSize(NamedSize.Micro, typeof(Label))),
				BackgroundColor = ReverieStyles.orange,
				BorderColor = Color.White,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center,
				IsEnabled = true
			};
			resetButton.Clicked += OnResetButtonClicked;

			stackLayout = new StackLayout
			{
				//Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5),

				Orientation = StackOrientation.Vertical,

				Children = {
              
					//simple text label
					textLabel,

					//password label
					passwordLabel,

					//reset button
					resetButton

				}
			};

			Content = stackLayout;
		}

		//event handler for reset button
		void OnResetButtonClicked(object sender, EventArgs args)
		{
			//reset password value
			passwordLabel.Text = "";

			//loads navigation page
			localViewController.gotoPurposePage();

		}
	}
}
