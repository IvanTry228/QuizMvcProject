using System;
using System.Collections.Generic;

namespace Quick_Quiz.QuizTemplate
{
    public interface IQuiz<T> where T : IQuestionItem
    {
        //public int ageTest;
        IQuiz<T> SetQuestionsList(IList<T> _newQuestions);

        IList<T> GetQuestionsList(IList<T> _newQuestions);
    }

    public class QuizBase : IQuiz<IQuestionItem>, ICustomConsoleLoggable //, ISetDataByDataTable
    {
        protected List<IQuestionItem> questionsItems = new List<IQuestionItem>();

        public void CallConsoleLog()
        {
            string testLog = "QuizBase test log QuestionsCount = " + questionsItems.Count + "\n";
            foreach (var item in questionsItems)
            {
                testLog += item.GetQuestionText() + " ";
            }
            Console.WriteLine(testLog);
        }

        public IList<IQuestionItem> GetQuestionsList(IList<IQuestionItem> _newQuestions)
        {
            return questionsItems;
        }

        //public void SetData(DataTable _dataTable)
        //{

        //}

        public IQuiz<IQuestionItem> SetQuestionsList(IList<IQuestionItem> _newList)
        {
            questionsItems = (List<IQuestionItem>)_newList;
            //foreach (var item in _newList)
            //{

            //}
            return this;
        }
    }
}
