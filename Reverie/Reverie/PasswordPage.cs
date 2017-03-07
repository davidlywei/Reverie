using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
	public class PasswordPage
	{

		Label label; //label displaying app name
		Image logoImage; //diplaying logo
		Button resetButton; //reset password button
		StackLayout stackLayout; //stacklayout for page

		public PasswordPage()
		{
			logoImage = new Image
			{
				Source = "Reverie.Images.Logo.png", // 288x292 pixels
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 288
				//HeightRequest = 292
			};

			label = new Label
			{
				//Text = Password.GetHash(),
				//Text = Password.password,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Transparent,
				TextColor = ReverieStyles.accentGreen,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				FontAttributes = FontAttributes.Bold
			};

			resetButton = new Button
			{
				Text = "RESET PASSWORD",
				//BackgroundColor = ReverieStyles.orange,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center
			};
			resetButton.Clicked += OnResetButtonClicked;

			stackLayout = new StackLayout
			{
				Orientation = StackOrientation.Vertical,

				Children = {
              
					//logo image
					logoImage,

					 //password label
					label,

					//reset button
					resetButton

				}
			};
		}

		//event handler for reset button
		void OnResetButtonClicked (object sender, EventArgs args)
		{
			//reset password value

			//loads navigation page

		}
	}
}
