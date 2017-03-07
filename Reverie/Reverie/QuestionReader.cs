using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    public class QuestionReader
    {
        String file;

        public QuestionReader()
        {
            // Read JSON file from resources
            Assembly currAssem = typeof(QuestionReader).GetTypeInfo().Assembly;

            Stream stream = currAssem.GetManifestResourceStream("Reverie.resources.Questions.json");

            using (var reader = new StreamReader(stream))
            {
                file = reader.ReadToEnd();
            }
        }

        // Split json into multiple questions
        public String[] getQuestions()
        {
            Regex removeWhitespace = new Regex(ReverieUtils.WHITESPACE_REGEX);
            file = removeWhitespace.Replace(file, "");

            Regex separateQuestions = new Regex(ReverieUtils.JSON_TAG_TITLE);
            file = separateQuestions.Replace(file, ";" + ReverieUtils.JSON_TAG_TITLE);

            String[] questions = file.Split(';');

            return questions;
        }
    }
}
