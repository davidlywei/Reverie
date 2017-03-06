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

        public QuestionText(String p, String h, BindableObject q)
        {
            prompt = p;
            placeholder = h;

            entry = new Entry()
            {
                Placeholder = placeholder,
            };

            entry.Completed += (o, s) => { q.updateString(); };
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

        public String getPrompt()
        {
            return prompt;
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

            return " { 'Type': '" + ReverieUtils.QUESTION_TEXT + "', 'Prompt': '" + prompt + "', 'Placeholder': '" + placeholder + "'}";
        }
    }
}
