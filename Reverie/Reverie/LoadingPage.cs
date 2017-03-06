using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
	public class LoadingPage
	{
		Label label; //label displaying app name
		Image logoImage; //diplaying logo
		ProgressBar progressBar; //progress indication bar 

		public LoadingPage()
		{
			label = new Label
			{
				Text = "Reverie",
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Transparent,
				TextColor = ReverieStyles.accentGreen,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold
			};

			logoImage = new Image
			{
				Source = "Reverie.Images.Logo.png", // 288x292 pixels
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 288
				//HeightRequest = 292
			};

			progressBar = new ProgressBar
			{
				Progress = 0.2,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center
			};
			// Set the binding context: target is progressBar; source is contentpage.
			//progressBar.BindingContext = ?;
			// Bind the properties: target is Progress; source is ?.
			//progressBar.SetBinding(ProgressBar.ProgressProperty, "?");
		}

		public StackLayout getLayout()
		{
			StackLayout stackLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = {
                    //text label
					label,
               
					//logo image
					logoImage,

					//progress bar
					progressBar
				}
			};

			return stackLayout;
		}
	}
}
