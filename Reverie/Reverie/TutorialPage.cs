using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
	public class TutorialPage
	{
		//create carousel page
		CarouselPage carouselPage;
		List<ContentPage> tutorialPages = new List<ContentPage> (0);
		Image tutorialImage;

		//array of stirngs containing embedded image sources
		static readonly string[] imageSource = { "Reverie.Images.Logo.png",
												"Reverie.Images.Logo.png", 
												"Reverie.Images.Logo.png" };

		public TutorialPage()
		{
			//create 3 tutorial pages
			foreach (string s in imageSource)
			{
				//create new image from embedded sources
				tutorialImage = new Image
				{
					WidthRequest = App.screenWidth,
					HeightRequest = App.screenHeight,
					Source = ImageSource.FromResource(s)
				};

				//display tutorial image in a new content page
				tutorialPages.Add(new ContentPage
				{
					Content = tutorialImage
				});

			}

			//add tutorial pages to carousel page
			carouselPage = new CarouselPage
			{
				Children = {

					tutorialPages[0],
					tutorialPages[1],
					tutorialPages[2]
				}
			};

		}//end constructor

	}
}
