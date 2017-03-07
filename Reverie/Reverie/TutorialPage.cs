using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
	public class TutorialPage : CarouselPage
	{
		List<ContentPage> tutorialPages = new List<ContentPage> (0);
		Image tutorialImage;
		ViewController localViewController;
		StackLayout stackLayout;
		Button startButton;

		//array of stirngs containing embedded image sources
		static readonly string[] imageSource = { "Reverie.Images.Logo.png",
												"Reverie.Images.Logo.png", 
												"Reverie.Images.Logo.png" };

		public TutorialPage(ViewController viewController)
		{
			//assign to local view controller for reset button event handler
			localViewController = viewController;

			//create 3 tutorial pages
			for (int i = 0; i < 3; i++)
			{
				//create new image from embedded sources
				tutorialImage = new Image
				{
					WidthRequest = App.screenWidth,
					HeightRequest = App.screenHeight,
					Source = ImageSource.FromResource(imageSource[i])
				};


				//add button to the last tutorial page
				if (i == 3)
				{
					startButton = new Button
					{
						Text = "Start",
						VerticalOptions = LayoutOptions.End,
						HorizontalOptions = LayoutOptions.Center
					};
					startButton.Clicked += OnStartButtonClicked;

					stackLayout = new StackLayout
					{
						Orientation = StackOrientation.Vertical,

						Children = {

							tutorialImage,
							startButton
						}
					};

					//display tutorial image in a new content page
					tutorialPages.Add(new ContentPage
					{
						Content = stackLayout
					});

				}//ends if block

				else //for other pages in tutorial
				{
					//display tutorial image in a new content page
					tutorialPages.Add(new ContentPage
					{
						Content = tutorialImage
					});
				}

			}

			//add tutorial pages to carousel page
			Children.Add(tutorialPages[0]);
			Children.Add(tutorialPages[1]);
			Children.Add(tutorialPages[2]);

		}//end constructor

		void OnStartButtonClicked(object sender, EventArgs args)
		{
			//go to purpose page
			localViewController.gotoPurposePage();
		}

	}
}
