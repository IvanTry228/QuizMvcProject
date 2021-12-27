using System;
using System.Collections.Generic;
using DotNetExtra.DataBaseParsing;
using Quick_Quiz.QuizTemplate;

namespace QuizMvcProject.Models
{
    public class QuizPageModel : ICustomIdIntable
    {
        public int fastCustomcode = -2;

        public int GetCustomId()
        {
            return fastCustomcode;
        }

        public void SetCustomId(int _hashCode)
        {
            fastCustomcode = _hashCode;
        }

        private QuizBase currentQuiz;

        public QuizBase GetQuizBase()
        {
            return currentQuiz;
        }

        public void FastFillRandom()
        {
            List<IQuestionItem> randomedQuestionsItems = new List<IQuestionItem>();
                
            var PddQuizQuestions = HolderDataNewPdd.GetRandomQuestionsForQuiz();

            foreach (var item in PddQuizQuestions)
            {
                randomedQuestionsItems.Add(item);
            }

            currentQuiz = new QuizBase();
            currentQuiz.SetQuestionsList(randomedQuestionsItems);
        }
        public QuizPageModel(bool isRandomInit)
        {
            Console.WriteLine("--QuizPageModel--- isRandomInit =" + isRandomInit);
            if (isRandomInit)
                FastFillRandom();       
        }
    }
}
