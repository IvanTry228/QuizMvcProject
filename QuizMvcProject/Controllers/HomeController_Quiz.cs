using Microsoft.AspNetCore.Mvc;
using Quick_Quiz.QuizTemplate;
using QuizMvcProject.Models;
using QuizMvcProject.QuizImplementation;
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

        //static QuizPageModel fastQuizPageModel = new QuizPageModel(true); //static for fast

        [HttpGet]
        public IActionResult GetRandomQuiz()
        {
            //MessageModel currentessage = new MessageModel("Qestion with current id not exist = " + id);
            Console.WriteLine("!!!!!!!!!!!___!!! GetRandomQuiz ");

            int bufferHashCode = -1;
            QuizPageModel fastQuizPageModel = QuizModelsPoolManager.Instance.GetQuizPageModelFree(out bufferHashCode); // new QuizPageModel(true);
            int defaultId = 0;
            fastQuizPageModel.GetQuizBase().SetCurrenPointertIndex(defaultId);
            return RedirectToAction("QuizPage", new { id = defaultId, hashCode = bufferHashCode });
        }

        [HttpGet]
        public IActionResult QuizPage(int id, int hashCode)
        {
            Console.WriteLine("!!!!!!!!!!!___!!! QuizPage id = " + id + " hashCode = " + hashCode);
            //MessageModel currentessage = new MessageModel("Qestion with current id not exist = " + id);

            QuizPageModel fastQuizPageModel = QuizModelsPoolManager.Instance.GetQuizPageModelFrFromHash(hashCode); // new QuizPageModel(true);
            fastQuizPageModel.GetQuizBase().SetCurrenPointertIndex(id);

            return View(fastQuizPageModel);
        }

        [HttpGet]
        public IActionResult CallAnswerForQuestion(int _indexQuestion, int _indexAnswer, int _hashCode)
        {
            Console.WriteLine("!_!!! CallAnswerForQuestion _indexQuestion = " + _indexQuestion + " _indexAnswer = " + _indexAnswer + " _hashCode =" + _hashCode);
            //MessageModel currentessage = new MessageModel("Qestion with current id not exist = " + id);
            //fastQuizPageModel.GetQuizBase().SetCurrenPointertIndex(id);
            //QuizPageModel fastQuizPageModel.GetQuizBase().CallAnswerForQuestion(_indexQuestion, _indexAnswer);
            QuizPageModel fastQuizPageModel = QuizModelsPoolManager.Instance.GetQuizPageModelFrFromHash(_hashCode); // new QuizPageModel(true);
            fastQuizPageModel.GetQuizBase().CallAnswerForQuestion(_indexQuestion, _indexAnswer);
            fastQuizPageModel.GetQuizBase().CallNextIndex();
            return RedirectToAction("QuizPage", new { id = fastQuizPageModel.GetQuizBase().GetCurrenPointertIndex(), hashCode = _hashCode });
        }
    }
}
