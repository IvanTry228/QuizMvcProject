using DotNetExtra.DataBaseParsing;
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
            Console.WriteLine("Entered Question isFindedResult = " + isFindedResult + " id = " + id);

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

        public IActionResult QuestionCheckAnswer(int _idQuestion, int _indexAnswer)
        {
            Console.WriteLine("QuestionCheckAnswer _idQuestion = " + _idQuestion + " _indexAnswer =" + _indexAnswer);

            IQuestionItem bufferQuestion = HolderDataNewPdd.TryGetQuestion(_idQuestion);

            if (bufferQuestion.GetAnsweredState())
                return RedirectToAction("Question"); //random

            bufferQuestion.SetAnsweredState(true);
            bufferQuestion.SetAnsweredStateByIAnswer(bufferQuestion.GetIAnswersListsOnly()[_indexAnswer]);

            return RedirectToAction("Question", new { id = _idQuestion });
        }

        [HttpGet]
        public IActionResult QuestionNotExist(int id)
        {
            MessageModel currentessage = new MessageModel("Qestion with current id not exist = " + id);
            return View(currentessage);
        }

        [HttpGet]
        public IActionResult QuizHashCodeNotExist(int id)
        {
            MessageModel currentessage = new MessageModel("Quiz with request not exist = " + id);
            return View(currentessage);
        }

        [HttpPost]
        public IActionResult QuestionNotExist(string idstring)
        {
            int parsedId =  int.Parse(idstring);
            Console.WriteLine("QuestionNotExist parsedId = " + parsedId);
            return RedirectToAction("Question", new { id = parsedId });
        }

        [HttpGet]
        public IActionResult GetRandomQuiz()
        {
            Console.WriteLine("GetRandomQuiz ");
            int bufferHashCode = -1;
            QuizPageModel fastQuizPageModel = QuizModelsPoolManager.Instance.GetQuizPageModelFree(out bufferHashCode); // new QuizPageModel(true);
            int defaultId = 0;
            fastQuizPageModel.GetQuizBase().SetCurrenPointertIndex(defaultId);
            return RedirectToAction("QuizPage", new { id = defaultId, hashCode = bufferHashCode });
        }

        [HttpGet]
        public IActionResult QuizPage(int id, int hashCode)
        {
            Console.WriteLine("QuizPage id = " + id + " hashCode = " + hashCode);

            QuizPageModel fastQuizPageModel = QuizModelsPoolManager.Instance.GetQuizPageModelFrFromHash(hashCode); // new QuizPageModel(true);

            if(fastQuizPageModel==null)
                return RedirectToAction("QuizHashCodeNotExist", new { id = hashCode });

            fastQuizPageModel.GetQuizBase().SetCurrenPointertIndex(id);

            return View(fastQuizPageModel);
        }

        [HttpGet]
        public IActionResult CallAnswerForQuestion(int _indexQuestion, int _indexAnswer, int _hashCode)
        {
            Console.WriteLine("!_!!! CallAnswerForQuestion _indexQuestion = " + _indexQuestion + " _indexAnswer = " + _indexAnswer + " _hashCode =" + _hashCode);
            QuizPageModel fastQuizPageModel = QuizModelsPoolManager.Instance.GetQuizPageModelFrFromHash(_hashCode); // new QuizPageModel(true);

            if(fastQuizPageModel==null)
                return RedirectToAction("QuizHashCodeNotExist", new { id = _hashCode });

            fastQuizPageModel.GetQuizBase().CallAnswerForQuestion(_indexQuestion, _indexAnswer);
            fastQuizPageModel.GetQuizBase().CallNextIndex();
            return RedirectToAction("QuizPage", new { id = fastQuizPageModel.GetQuizBase().GetCurrenPointertIndex(), hashCode = _hashCode });
        }
    }
}
