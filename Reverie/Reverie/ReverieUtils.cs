using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    static class ReverieUtils
    {
        public static Color PAGE_BACKGROUND_COLOR = Color.Black;
        public static Color FRAME_GRAY = Color.Gray;

        // JSON Tags
        public const String JSON_TAG_TITLE  = "QuestionTitle";
        public const String JSON_TAG_ENABLE = "QuestionEnabled";
        public const String JSON_TAG_ID     = "QuestionID";
        public const String JSON_TAG_QLIST  = "QuestionList"; 
        public static char[] DELIMITERS = { '{', '\"', ':', ',', '[', ']', '}' };

        // Types of Questions
        public const String QUESTION_TEXT = "Text";

        public const double QUESTIONNAIRE_PERCENT = .4;
        public const double QUESTIONMENU_PERCENT  = .2;
    }
}
