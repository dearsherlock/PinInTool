using PinInWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PinInWeb.Controllers
{
    public class PinInController : ApiController
    {
        private PinInDataService _service;

        public PinInController()
        {
            _service = new PinInDataService();
        }

        public async Task<string> GetJokePinIn(string original, string joke)
        {
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
                else
                {
                    sbResult.Append(originalString[loop] + it);

                }

                loop++;
            }

            
            if (originalString.Length > jokeString.Length)
            {
                sbResult.Append(original.Substring(jokeString.Length));
            }

            return sbResult.ToString();

        }
        private async Task<string> GetRightPinIn(string data)
        {
            //PinInDao dao = new PinInDao();
            if (data.Length > 1)
            {
                string result = await _service.QueryByKey(data);

                if (String.IsNullOrEmpty(result))
                {
                    char[] eachWords = data.ToArray();
                    StringBuilder sb = new StringBuilder();

                    foreach (char eachWord in eachWords)
                    {
                        string resultEach = await _service.QueryByKey(eachWord.ToString());
                        sb.Append(eachWord + resultEach);
                    }
                    return sb.ToString();
                    //return ReplaceOriginalWord(data, sb.ToString());

                }
                else
                {
                    return result;
                    //return ReplaceOriginalWord(data, result); 
                }
            }
            else
            {
                string result = await _service.QueryByKey(data);

                return data + result;
                //return ReplaceOriginalWord(data,result);
            }
            return "";

        }
        private async Task<string> GetPurePinIn(string data)
        {
            //PinInDao dao = new PinInDao();
            if (data.Length > 1)
            {
                string result = await _service.QueryByKey(data);

                if (String.IsNullOrEmpty(result))
                {
                    char[] eachWords = data.ToArray();
                    StringBuilder sb = new StringBuilder();

                    foreach (char eachWord in eachWords)
                    {
                        string resultEach = await _service.QueryByKey(eachWord.ToString());
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
                        result = result.Replace(eachWord + "", "");

                    }
                    return result;
                    //return ReplaceOriginalWord(data, result); 
                }
            }
            else
            {
                string result = await _service.QueryByKey(data);

                return result;
                //return ReplaceOriginalWord(data,result);
            }
            return "";

        }
        private string ReplaceOriginalWord(string original, string pinIn)
        {
            char[] data = original.ToArray();

            foreach (char value in data)
            {
                pinIn = pinIn.Replace(value + "", "");

            }
            return pinIn;
        }

    }
}
