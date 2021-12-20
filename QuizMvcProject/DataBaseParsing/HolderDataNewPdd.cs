using DotNetExtra.CustomUtilities;
using DotNetExtra.QuizImplementation;
using Quick_Quiz.QuizTemplate;
using QuizTemplateMvcDotnet6.DatabaseSql;
using System;
using System.Collections.Generic;

namespace DotNetExtra.DataBaseParsing
{
    public class HolderDataNewPdd
    {
        public const int AllQuizQuestionFast = 20;

        public static QuizTemplate_DbContext allHolderNewDataContext; // = new DataBaseNewQuizContext();
        
        public static void CallInitNewData()
        {
            allHolderNewDataContext = new QuizTemplate_DbContext();
            
            allHolderNewDataContext.SaveChanges();
        }

        public static QuizPdd_Question GetRandomQuestion()
        {
            return allHolderNewDataContext.PddAllQuestions.GetRandomItem();
        }

        public static List<QuizPdd_Question> GetRandomQuestionsForQuiz()
        {
            var randomedQuestions = EnumerableExtension.GetRandomItems(allHolderNewDataContext.PddAllQuestions, AllQuizQuestionFast); //GetRandomItems<>(allHolderNewDataContext.PddAllQuestions, AllQuizQuestionFast);

            List<QuizPdd_Question> randomedQuestionsItems = new List<QuizPdd_Question>();

            foreach (var item in randomedQuestions)
            {
                randomedQuestionsItems.Add(item);
            }

            return randomedQuestionsItems;
        }

        public static QuizPdd_Question TryGetQuestion(int _id)
        {
            var bufferFind = allHolderNewDataContext.PddAllQuestions.Find(_id);

            if (bufferFind != null)
                return bufferFind;
            else
            {
                Console.WriteLine("QuizPdd_Question TryGetQuestion _id not exist = " + _id);
                return null;
            }
        }
    }
}
 