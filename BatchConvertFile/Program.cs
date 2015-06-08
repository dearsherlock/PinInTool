using PinInPCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BatchConvertFile
{
    public class Program
    {
        static  void Main(string[] args)
        {
            Program p = new Program();
            p.ReadFile();
            //p.QueryData();
        }
        /*  實在千奇百怪,所以移除了
           public static Regex regex = new Regex(
          "c\\s\\[\\d{1,}\\]=\\\"(.){1,}\\\"",
        RegexOptions.None
        );*/
       public void QueryData() {
            PinInDao daao = new PinInDao();
            daao.QueryByKey("還了得");
            daao.QueryByKey("吃得住");
            daao.QueryByKey("莩");

            daao.QueryByValue("ㄏㄨㄤˊ");
            daao.QueryByValue("異");
            daao.QueryByValue("靡ㄇㄧˇ不ㄅㄨˋ有ㄧㄡˇ初ㄔㄨ，鮮ㄒㄧㄢˇ克ㄎㄜˋ有ㄧㄡˇ終ㄓㄨㄥ");


            Console.ReadKey();
        }

        void ReadFile() {

            try
            {
                using (StreamReader sr = new StreamReader("phonetic_data.js"))
                {
                    String line =  sr.ReadToEnd();
                    string[] tempArray = line.Split(';');
                    PinInDao dao = new PinInDao();
                    List<PinInData> infos = new List<PinInData>();
                    List<string> duplicateData = new List<string>();
                     Dictionary<string, string> PairData = new Dictionary<string, string>();
                    try
                    {
                        //for (int k=0;k<200 ;k++) {
                            for (int i = 0; i < tempArray.Length - 1; i = i + 2)
                            {
                           
                                if (
                                    tempArray[i].Split('=').Length > 2)
                                {
                                    //有兩個=,表示中文裡面輸入錯誤
                                    return;
                                }
                                string key_value = tempArray[i].Split('=')[1].Replace("\"", "");
                                string data_value = tempArray[i + 1].Split('=')[1].Replace("\"", "");
                                string rev = "";
                                if (PairData.TryGetValue( key_value, out rev))
                                {
                                    //duplicate
                                    duplicateData.Add(key_value);
                                    //Console.WriteLine("Duplicate value=" + key_value);
                                }
                                else
                                {
                                
                                PairData.Add( key_value, data_value);
                                infos.Add(new PinInData { PinInKey = key_value, PinInValue = data_value });
                                }


                                //   (regex.Matches(tempArray[i + 1])[0]).Groups[1].Value;

                                //  regex.Matches(tempArray[i+1])[0].Value;
                                // dao.InvertData(key_value, data_value);


                                // InsertData(key_value, data_value);


                            }
                        //}
                        
                        dao.InsertManyData(infos);
                        Console.ReadKey();
                    }
                    catch (Exception exe)
                    {

                        throw exe;
                    }
                   


                    //"c [0]=\"﹗\""
                    //    ResultBlock.Text = line;
                }
            }
            catch (Exception ex)
            {
                String exS = ex.ToString();
                // ResultBlock.Text = "Could not read the file";
            }



        }
        void InsertData(string key,string value) {
            Console.WriteLine(String.Format("{0}={1}",key,value));

        }
    }
}
