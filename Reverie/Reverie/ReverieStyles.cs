using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class ReverieStyles
    {
		//create colors from rgb values
		static readonly Color backgroundGreen = Color.FromRgb(182, 215, 168);
		static readonly Color themeGreen = Color.FromRgb(147, 196, 125);
		static readonly Color accentGreen = Color.FromRgb(56, 118, 29);
		//static readonly Color orange = Color.FromRgb(246, 178, 107);

        public static Style BUTTON_STYLE = new Style(typeof(Button))
        {
            Setters =
            {
                new Setter
                {
                    Property = Button.BackgroundColorProperty,
                    Value = themeGreen
                },
                new Setter
                {
                    Property = Button.TextColorProperty,
                    Value = Color.Black
                },
                new Setter
                {
                    Property = Button.TextProperty,
                    Value = FontAttributes.Bold
                },
                new Setter
                {
                    Property = Button.FontSizeProperty,
                    Value = Device.GetNamedSize(NamedSize.Large, typeof(Button))
                }
            }
        };

        public static Style VIEW_STYLE = new Style(typeof(View))
        {
            Setters =
            {
                new Setter
                {
                    Property = ContentPage.BackgroundColorProperty,
                    Value = backgroundGreen
                }
            }
        };

        public static Style TEXT_STYLE = new Style(typeof(Label))
        {
            Setters =
            {
                new Setter
                {
                    Property = Label.TextProperty,
                    Value = FontAttributes.Bold
                },

                new Setter
                {
                    Property = Label.TextColorProperty,
                    Value = Color.Black
                },

                new Setter
                {
                    Property = Label.FontSizeProperty,
                    Value = Device.OnPlatform(iOS: Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                                              Android: Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                                              WinPhone: Device.GetNamedSize(NamedSize.Micro, typeof(Label)))
                }
             }
        };

        public static Style ENTRY_STYLE = new Style(typeof(Entry))
        {
            Setters =
            {
                new Setter
                {
                    Property = Entry.TextProperty,
                    Value = FontAttributes.Bold
                },
                new Setter
                {
                    Property = Entry.TextColorProperty,
                    Value = Color.Black
                },
                new Setter
                {
                    Property = Entry.FontSizeProperty,
                    Value = Device.OnPlatform(iOS: Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                                              Android: Device.GetNamedSize(NamedSize.Medium, typeof(Entry)),
                                              WinPhone: Device.GetNamedSize(NamedSize.Micro, typeof(Entry)))
                },
                new Setter
                {
                    Property = Entry.PlaceholderColorProperty,
                    Value = accentGreen
                },
                new Setter
                {
                    Property = Entry.BackgroundColorProperty,
					Value = Color.White
                }
             }
        };

		public static Style FRAME_STYLE = new Style(typeof(Frame))
		{
			Setters =
			{
				new Setter
				{
					Property = Frame.BackgroundColorProperty,
					Value = themeGreen,
				},

				new Setter
				{
					Property = Frame.OutlineColorProperty,
					Value = accentGreen
				},

				new Setter
				{
					Property = Frame.HasShadowProperty,
					Value = false
				}
			}
        };

        public static Style PAGE_STYLE = new Style(typeof(ContentPage))
        {
            Setters =
            {
                new Setter
                {
                    Property = ContentPage.BackgroundColorProperty,
                    Value = Color.Black
                }
            }
        };

        public static Style NPAGE_STYLE = new Style(typeof(NavigationPage))
        {
            Setters =
            {
                new Setter
                {
                    Property = NavigationPage.BackgroundColorProperty,
                    Value = Color.Black
                },
                new Setter
                {
                    Property = NavigationPage.BarBackgroundColorProperty,
                    Value = Color.Black
                },
                new Setter // Doesn't do anything
                {
                    Property = NavigationPage.HasBackButtonProperty,
                    Value = false //Boolean.FalseString
                },
                new Setter // Doesn't do anything
                {
                    Property = NavigationPage.HasNavigationBarProperty,
                    Value = false //Boolean.FalseString
                }
             }
        };

        public static List<Style> STYLES = new List<Style>() {  BUTTON_STYLE,
                                                                VIEW_STYLE,
                                                                PAGE_STYLE,
                                                                NPAGE_STYLE,
                                                                TEXT_STYLE,
                                                                ENTRY_STYLE,
                                                                FRAME_STYLE};


    }
}
