using System;
using System.Collections.Generic;
using System.IO;

namespace Random_Code
{
    public class RandomWord
    {
        public static String RandomWordGenerator(int NumberOfResults = 1)
        {
            var OnlineWord = WebRequest(URl + NumberOfResults);
            var CharList = new List<char> { '"', '[', ']' };
            if (NumberOfResults > 1)
            {
                var ListofWords = CharRemoval(OnlineWord, CharList).Replace(",", "^");
                List<String> WordList = new List<string>();
                foreach (var _Words in ListofWords.Split('^'))
                {
                    if (!WordList.Contains(_Words))
                        WordList.Add(_Words);
                }
                return WordList[_Random.Next(0, WordList.Count)];
            }
            return CharRemoval(OnlineWord, CharList);
        }

        private static String CharRemoval(String _String, List<Char> ListofChat)
        {
            foreach (char C in ListofChat)
            {
                _String = _String.Replace(C.ToString(), String.Empty);
            }
            return _String;
        }

        private static String WebRequest(String UniformResourceLocators)
        {
            var httpRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(UniformResourceLocators);
            var httpResponse = (System.Net.HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }
        private static readonly Random _Random = new Random();
        private static readonly String URl = "https://random-word-api.herokuapp.com/word?number=";
    }
}
