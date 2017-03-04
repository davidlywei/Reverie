using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reverie
{
    class QuestionText : Question
    {
        private String prompt;
        private Entry entry;
        private String placeholder;
        private const String TYPE = "Text";

        QuestionText(String p)
        {
            parseString(p);
        }

        private void parseString(String p)
        {
            
        }

        private void buildQuestionText(String p, String h)
        {
            prompt = p;
            placeholder = h;

            entry = new Entry()
            {
                Placeholder = placeholder,
            };
        }

        public StackLayout getLayout()
        {
            return new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children =  {
                                new Label () { Text = prompt},
                                entry
                            }
            };
        }

        public String getResponse()
        {
            return entry.Text;
        }

        public String toString()
        {
            /*
            byte[] json;

            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(QuestionText));

            serializer.WriteObject(stream, this);

            json = stream.ToArray();

            stream.Dispose();

            return Encoding.UTF8.GetString(json, 0, json.Length);
            */

            return " { 'Type': '" + TYPE + "', 'Prompt': '" + prompt + "', 'Placeholder': '" + placeholder + "'}";
        }
    }
}
