using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
	public class TutorialPage : ContentPage
	{
		List<ContentPage> tutorialPages = new List<ContentPage> (0);
		Image tutorialImage;
		ViewController localViewController;
		StackLayout stackLayout;
		Button startButton;
        bool gotoMenu;

		public TutorialPage(ViewController viewController, String imageSource, bool isLast, bool gm)
		{
            gotoMenu = gm;

			//assign to local view controller for reset button event handler
			localViewController = viewController;

            //create new image from embedded sources
			tutorialImage = new Image
			{
				WidthRequest = 250,
				HeightRequest = 500,
				Source = ImageSource.FromResource(imageSource)
			};

            Button btn;
            //add button to the last tutorial page
            if (isLast)
            {
                btn = new Button
                {
                    Text = "Start",
                    VerticalOptions = LayoutOptions.End,
                    HorizontalOptions = LayoutOptions.Center
                };
                btn.Clicked += OnStartButtonClicked;

            }
            else
            {
                btn = new Button
                {
                    Text = "Next",
                    VerticalOptions = LayoutOptions.End,
                    HorizontalOptions = LayoutOptions.Center
                };
                btn.Clicked += OnNextButtonClicked;
            }

            StackLayout btnLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                Children = { btn }
            };

            stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,

                Children = {
                    tutorialImage,
                    btnLayout
                }
            };

            Content = stackLayout;

		}//end constructor

		void OnStartButtonClicked(object sender, EventArgs args)
		{
            if (gotoMenu)
            {
                localViewController.popTutorials();
            }
            else
            {
                //go to purpose page
                localViewController.gotoPurposePage();
            }
		}

        void OnNextButtonClicked(object sender, EventArgs args)
		{
			//go to purpose page
			localViewController.gotoNextTutorialPage(gotoMenu);
		}
	}
}
