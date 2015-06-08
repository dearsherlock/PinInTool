using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchConvertFile
{
    public class PinInService
    {
        public async Task<string> GetRightPinIn(string data) {
            PinInDao dao = new PinInDao();
            if (data.Length > 1)
            {
                string result = await dao.QueryByKey(data);

                if (String.IsNullOrEmpty(result))
                {
                    char[] eachWords = data.ToArray();
                    StringBuilder sb = new StringBuilder();

                    foreach (char eachWord in eachWords)
                    {
                        string resultEach = await dao.QueryByKey(eachWord.ToString());
                        sb.Append(eachWord+resultEach);
                    }
                    return sb.ToString();
                    //return ReplaceOriginalWord(data, sb.ToString());

                }
                else {
                    return result;
                    //return ReplaceOriginalWord(data, result); 
                }
            }
            else {
                string result=await dao.QueryByKey(data);

                return data+result;
                //return ReplaceOriginalWord(data,result);
            }
            return "";

        }
        public async Task<string> GetPurePinIn(string data)
        {
            PinInDao dao = new PinInDao();
            if (data.Length > 1)
            {
                string result = await dao.QueryByKey(data);

                if (String.IsNullOrEmpty(result))
                {
                    char[] eachWords = data.ToArray();
                    StringBuilder sb = new StringBuilder();

                    foreach (char eachWord in eachWords)
                    {
                        string resultEach = await dao.QueryByKey(eachWord.ToString());
                        sb.Append(resultEach);
                    }
                    return sb.ToString();
                    //return ReplaceOriginalWord(data, sb.ToString());

                }
                else
                {
                    char[] eachWords = data.ToArray();
                    

                    foreach (char eachWord in eachWords)
                    {
                        result = result.Replace(eachWord+"","");
                     
                    }
                    return result;
                    //return ReplaceOriginalWord(data, result); 
                }
            }
            else
            {
                string result = await dao.QueryByKey(data);

                return  result;
                //return ReplaceOriginalWord(data,result);
            }
            return "";

        }
        private string ReplaceOriginalWord(string original,string pinIn) {
            char[] data = original.ToArray();
            
            foreach (char value in data) {
                pinIn = pinIn.Replace(value+"","");

            }
            return pinIn;
        }
        public async Task<string> GetJokePinIn(string original,string joke) {
            char[] originalString = original.ToArray();
            char[] jokeString = joke.ToArray();
            string jokeTranslate = "";
            jokeTranslate = await GetRightPinIn(joke);
            var jokeTranslateSplit = jokeTranslate.Split(jokeString, StringSplitOptions.RemoveEmptyEntries);
            int loop = 0;
            StringBuilder sbResult = new StringBuilder();
            foreach (var it in jokeTranslateSplit)
            {

                if (originalString.Length < jokeString.Length && originalString.Length <= loop)
                {
                    //攔截original>joke
                    sbResult.Append(it);

                }
                else {
                    sbResult.Append(originalString[loop] + it);

                }
                
                loop++;
            }

            //for (int i = 0; i < jokeString.Length; i++)
            //{
            //    if (originalString.Length< jokeString.Length &&  originalString.Length==i)
            //    {
            //        string leftString = await GetPurePinIn(joke.Substring(i));
            //        jokeTranslate = jokeTranslate.Substring(0, jokeTranslate.IndexOf(jokeString[i]))+ leftString;
                   

            //        break;
            //    }
            //    jokeTranslate = jokeTranslate.Replace(jokeString[i], originalString[i]);
            //}
            if (originalString.Length > jokeString.Length)
            {
                sbResult.Append(original.Substring(jokeString.Length));
            //    jokeTranslate = jokeTranslate + original.Substring(jokeString.Length);
            }

            return sbResult.ToString();

        }
    }
}
