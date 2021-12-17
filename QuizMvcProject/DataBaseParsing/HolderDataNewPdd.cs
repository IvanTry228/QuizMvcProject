using DotNetExtra.CustomUtilities;
using DotNetExtra.QuizImplementation;
using QuizTemplateMvcDotnet6.DatabaseSql;
using System;

namespace DotNetExtra.DataBaseParsing
{
    public class HolderDataNewPdd
    {
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
 