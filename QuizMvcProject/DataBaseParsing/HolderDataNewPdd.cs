using DotNetExtra.CustomUtilities;
using DotNetExtra.QuizImplementation;
using QuizTemplateMvcDotnet6.DatabaseSql;

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
    }
}
 