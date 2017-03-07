using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    public static class ReverieUtils
    {
        public static Color PAGE_BACKGROUND_COLOR = Color.Black;
        public static Color FRAME_GRAY = Color.Gray;

        // JSON Tags
        public const String JSON_TAG_TITLE  = "QuestionTitle";
        public const String JSON_TAG_ENABLE = "QuestionEnabled";
        public const String JSON_TAG_ID     = "QuestionID";
        public const String JSON_TAG_QLIST  = "QuestionList"; 
        public static char[] DELIMITERS = { '{', '\"', ':', ',', '[', ']', '}' };
        public static String WHITESPACE_REGEX = "\\s\\s+|\\r|\\n|\\r\\n|: ";

        // Types of Questions
        public const String QUESTION_TEXT = "Text";

        public const double QUESTIONNAIRE_PERCENT = 0.4;
        public const double QUESTIONMENU_PERCENT  = 0.6;

        public const double LAYOUT_SPACING = 0;
        public static Thickness QUESTION_LAYOUT_THICKNESS = new Thickness(10, 10, 10, 10);
        public const int QUESTION_LAYOUT_RATIO = 8;

        public const int BUTTON_PADDING = 6;
        public const int LAYOUT_PADDING = 6;

        public const String EMBEDED_IMG_LOCATION = "Reverie.Images.";
        public const String MENU_ICON = EMBEDED_IMG_LOCATION + "menuIcon.png";
        public const String DONE_ICON = EMBEDED_IMG_LOCATION + "doneIcon.png";
        public const String BACK_ICON = EMBEDED_IMG_LOCATION + "backIcon.png";
        public const String UP_ICON   = EMBEDED_IMG_LOCATION + "upIcon.png";
        public const String DOWN_ICON = EMBEDED_IMG_LOCATION + "downIcon.png";
        
    }
}
