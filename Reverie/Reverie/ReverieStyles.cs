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
        public static Style BUTTON_STYLE = new Style(typeof(Button))
        {
            Setters =
            {
                new Setter
                {
                    Property = Button.BackgroundColorProperty,
                    Value = Color.White
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

        public static Style PAGE_STYLE = new Style(typeof(ViewController))
        {
            Setters =
            {
                new Setter
                {
                    Property = ContentPage.BackgroundColorProperty,
                    Value = Device.OnPlatform(  iOS: Color.Black,
                                                Android: Color.Black,
                                                WinPhone: Color.White)
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
                    Value = Device.OnPlatform(  iOS: Color.White,
                                                Android: Color.White,
                                                WinPhone: Color.Black)
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
                    Value = Color.Black
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
                    Value = Device.OnPlatform(  iOS: ReverieUtils.FRAME_GRAY,
                                                Android: ReverieUtils.FRAME_GRAY,
                                                WinPhone: ReverieUtils.FRAME_GRAY)
                }
            }
        };

        public static List<Style> STYLES = new List<Style>() {  BUTTON_STYLE,
                                                                PAGE_STYLE,
                                                                TEXT_STYLE,
                                                                ENTRY_STYLE,
                                                                FRAME_STYLE};


    }
}
