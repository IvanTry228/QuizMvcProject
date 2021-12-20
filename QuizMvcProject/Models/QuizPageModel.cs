using DotNetExtra.DataBaseParsing;
using Quick_Quiz.QuizTemplate;
using System;
using System.Collections.Generic;

namespace QuizMvcProject.Models
{
    public class QuizPageModel
    {
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
