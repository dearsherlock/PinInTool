using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BatchConvertFile;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public async Task TestJokeServiceInOriginalLongThanJoke()
        {

            //PinInDao daao = new PinInDao();
            PinInService service = new PinInService();
            string result = await service.GetJokePinIn("是好人","哈哈");
            // await daao.QueryByKey("還了得");
            Assert.AreNotEqual(result, "");



        }
        [TestMethod]
        public async Task TestJokeServiceInJoke()
        {

            //PinInDao daao = new PinInDao();
            PinInService service = new PinInService();
            string result = await service.GetJokePinIn("好人", "哈哈");
            // await daao.QueryByKey("還了得");
            Assert.AreNotEqual(result, "");



        }
        [TestMethod]
        public async Task TestJokeServiceInOriginalShortThanJoke()
        {

            //PinInDao daao = new PinInDao();
            PinInService service = new PinInService();
            string result = await service.GetJokePinIn("好人", "哈哈哈哈哈去去去");
            // await daao.QueryByKey("還了得");
            Assert.AreNotEqual(result, "");



        }
        [TestMethod]
        public async Task TestQueryPinInDataLongWord()
        {
           
                //PinInDao daao = new PinInDao();
                PinInService service = new PinInService();
               string result= await service.GetRightPinIn("還了得");
                // await daao.QueryByKey("還了得");
                Assert.AreNotEqual(result,"");

           

        }
        [TestMethod]
        public async Task TestQueryPinInDataLongNotMatchWord()
        {

            //PinInDao daao = new PinInDao();
            PinInService service = new PinInService();
            string result = await service.GetRightPinIn("訓還氣了得");
            // await daao.QueryByKey("還了得");
            Assert.AreNotEqual(result, "");



        }
        [TestMethod]
        public async Task TestQueryPinInDataSingleWord()
        {

            //PinInDao daao = new PinInDao();
            PinInService service = new PinInService();
            string result = await service.GetRightPinIn("幹");
            // await daao.QueryByKey("還了得");
            Assert.AreNotEqual(result, "");



        }


        [TestMethod]
        public async Task TestQueryByKey_1()
        {
            try
            {
                PinInDao daao = new PinInDao();

                await daao.QueryByKey("還了得");
               

            }
            catch (Exception exception)
            {

                Assert.Fail();
            }
            
            
        }
        [TestMethod]
        public async Task TestQueryByKey_2()
        {
            try
            {
                PinInDao daao = new PinInDao();

                await daao.QueryByKey("吃得住");


            }
            catch (Exception exception)
            {

                Assert.Fail();
            }

            
        }
        [TestMethod]
        public async Task TestQueryByKey_3()
        {
            try
            {
                PinInDao daao = new PinInDao();

                await daao.QueryByKey("莩");


            }
            catch (Exception exception)
            {

                Assert.Fail();
            }

            //Program p = new Program();
            //p.QueryData();
        }

        [TestMethod]
        public async Task TestQueryByValue_1()
        {
            try
            {
                PinInDao daao = new PinInDao();

                daao.QueryByValue("ㄏㄨㄤˊ");
             

            }
            catch (Exception exception)
            {

                Assert.Fail();
            }
        }
        [TestMethod]
        public async Task TestQueryByValue_2()
        {
            try
            {
                PinInDao daao = new PinInDao();

                daao.QueryByValue("異");
             

            }
            catch (Exception exception)
            {

                Assert.Fail();
            }
        }
        [TestMethod]
        public async Task TestQueryByValue_3()
        {
            try
            {
                PinInDao daao = new PinInDao();

                daao.QueryByValue("靡ㄇㄧˇ不ㄅㄨˋ有ㄧㄡˇ初ㄔㄨ，鮮ㄒㄧㄢˇ克ㄎㄜˋ有ㄧㄡˇ終ㄓㄨㄥ");


            }
            catch (Exception exception)
            {

                Assert.Fail();
            }
        }
        }
}
