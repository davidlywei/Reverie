using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
	public class LoadingPage : ContentPage
	{
		Label label; //label displaying app name
		Image logoImage; //diplaying logo
		ProgressBar progressBar; //progress indication bar 
		ViewController localViewController;

		public LoadingPage(ViewController viewController)
		{
			//assign to local view controller for reset button event handler
			localViewController = viewController;

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
				Progress = 0,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center
			};
			// Set the binding context: target is progressBar; source is contentpage.
			//progressBar.BindingContext = ?;
			// Bind the properties: target is Progress; source is ?.
			//progressBar.SetBinding(ProgressBar.ProgressProperty, "?");

			StackLayout stackLayout = new StackLayout
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

			Content = stackLayout;
		}

		public void changeProgressBar(double d)
		{
			if (progressBar.Progress < .8)
			{
				//(percentage, time in ms, easing style)
				progressBar.ProgressTo(d, 500, Easing.Linear);
			}
			else //when progress bar reaches 0.8
			{
				//go to tutorial page or go to purpose page
				localViewController.gotoPurposePage();
			}
		}
	}
}
