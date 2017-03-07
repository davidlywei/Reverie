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
		Password passwordGen;
		ViewController localViewController;
		//String input = "Password";


		public PasswordPage(ViewController viewController)
		{
			passwordGen = DependencyService.Get<Password>();	
				
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
				Text = genPassword(),
				//Text = passwordGen.GetHash(input),
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
				Padding = new Thickness(5, Device.OnPlatform(20, 5, 5), 5, 5),
				VerticalOptions = LayoutOptions.CenterAndExpand,
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

        private String genPassword()
        {
            // Get password, and Special chars, and convert them to Char arrays
            char[] password = passwordGen.GetHash(localViewController.getResponse()).ToCharArray();
            char[] specialChars = localViewController.getSpecialChars();

            if (specialChars.Length != 0)
            {
                // Set the location of the character to be turned into a special char 
                // to value based on the ASCII value of first char
                int spcCharLoc = ((int)password[0]) % ReverieUtils.PASSWORD_LENGTH;
                
                // Set the chosen special char based on the ASCII value of second char
                int spcCharIdx = ((int)password[1]) % specialChars.Length;

                // Make substitution
                password[spcCharLoc] = specialChars[spcCharIdx];
            }

            // return string
            return new String(password);
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
