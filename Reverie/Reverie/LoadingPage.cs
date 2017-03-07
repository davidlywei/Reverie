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
		ViewController viewController;
        App app;

		//public LoadingPage(ViewController viewController)
        public LoadingPage(ViewController v)
		{
            // Create Reverie Label
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

            // Create Reverie Logo
			logoImage = new Image
			{
				Source = "Reverie.Images.Logo.png", // 288x292 pixels
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 288
				//HeightRequest = 292
			};

            // Create Progress Bar
			progressBar = new ProgressBar
			{
				Progress = 0,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center
			};

			//assign to local view controller for reset button event handler
			viewController = v;

            // Set progressbar loading to percentage in ViewController
            progressBar.BindingContext = viewController;
            progressBar.SetBinding(ProgressBar.ProgressProperty, "Percentage");
            progressBar.PropertyChanged += changeProgressBar;

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

        // Change bar handler
		public void changeProgressBar(object sender, EventArgs evnt)
		{
			if (progressBar.Progress >= 1)
			{
                //go to tutorial page or go to purpose page
				viewController.gotoFirstPage();
			}
		}
	}
}
