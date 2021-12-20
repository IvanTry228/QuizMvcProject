using Microsoft.AspNetCore.Mvc;
using Quick_Quiz.QuizTemplate;
using QuizMvcProject.Models;
using System;

namespace QuizMvcProject.Controllers
{
    public partial class HomeController
    {
        public IActionResult Question(int id)
        {
            bool isFindedResult = true;
            Console.WriteLine("Entered Question isFindedResult = " + isFindedResult + " id =" + id);

            QuestionModel bufferModel = new QuestionModel(id);
            
            if (id == 0)
                bufferModel.testQuestionModelObj.FillRandom();
            else
                bufferModel.testQuestionModelObj.FillById(id, out isFindedResult);

            Console.WriteLine("Exit Question isFindedResult = " + isFindedResult + " id =" + id);

            if (isFindedResult)
                return View(bufferModel);
            else
                return RedirectToAction("QuestionNotExist", id);
        }

        [HttpGet]
        public IActionResult QuestionNotExist(int id)
        {
            MessageModel currentessage = new MessageModel("Qestion with current id not exist = " + id);
            return View(currentessage);
        }

        [HttpPost]
        public IActionResult QuestionNotExist(string login, string password)
        {
            string authData = $"Login: {login}   Password: {password}";
            Console.WriteLine("QuestionNotExist authData = " + authData);
            int testInt = Int32.Parse(password);
            Console.WriteLine("QuestionNotExist testInt = " + testInt);
            return RedirectToAction("Question", new { id = testInt });
        }

        QuizPageModel fastQuizPageModel = new QuizPageModel(true);

        [HttpGet]
        public IActionResult QuizPage()
        {
            //MessageModel currentessage = new MessageModel("Qestion with current id not exist = " + id);
            fastQuizPageModel = new QuizPageModel(true);
            return View(fastQuizPageModel);
        }

        [HttpGet]
        public IActionResult QuizPage(int id)
        {
            //MessageModel currentessage = new MessageModel("Qestion with current id not exist = " + id);
            fastQuizPageModel.GetQuizBase().SetCurrenPointertIndex(id);
            return View(fastQuizPageModel);
        }

        //[HttpPost]
        //public IActionResult QuestionNotExist(string dfsdfwe)
        //{
        //    string authData = $"Login: {dfsdfwe}";
        //    Console.WriteLine("QuestionNotExist authData = " + dfsdfwe);
        //    int testInt = Int32.Parse(dfsdfwe);
        //    Console.WriteLine("QuestionNotExist testInt = " + testInt);
        //    return RedirectToAction("Question", new { id = testInt });
        //}
    }
}
