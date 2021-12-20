using System;
using System.Collections.Generic;
using System.Timers;

namespace Quick_Quiz.QuizTemplate
{
    public interface IQuiz<T> where T : IQuestionItem
    {
        //public int ageTest;
        IQuiz<T> SetQuestionsList(IList<T> _newQuestions);

        IList<T> GetQuestionsList();

        int GetAllAnsweredCount();

        int GetAllQuestionsCount();

        int GetAllPointsCount();

        int GetCurrenPointertIndex();

        void SetCurrenPointertIndex(int _argIndex);

        T GetCurrentQuestion();

        T GetQuestionByIndex(int _argIndex);

        void CallNextIndex();

        //new

        void CallAnswerForQuestion(int _argIndexQuestion, int _argIndexAnswer);

        void CallToAnswerFromAnswer(IQuestionItem _argQuestionItem, IAnswerItem _argAnswer);

        //Timer GetCurrentTimer();
    }

    public class QuizBase : IQuiz<IQuestionItem>, ICustomConsoleLoggable //, ISetDataByDataTable
    {
        protected List<IQuestionItem> questionsItems = new List<IQuestionItem>();

        private int currentPointerIndex = 0;

        public void CallConsoleLog()
        {
            Console.WriteLine(GetLogString());
        }

        public string GetLogString()
        {
            string testLog = "QuizBase test log QuestionsCount = " + GetAllQuestionsCount() + "\n";
            foreach (var item in questionsItems)
            {
                testLog += item.GetQuestionText() + " isAnswered : " + item.GetAnsweredState();
            }
            return testLog;
        }

        public int GetAllAnsweredCount()
        {
            int allAnswered = 0;

            foreach (var item in questionsItems)
            {
                if (item.GetAnsweredState())
                {
                    allAnswered++;
                }
            }

            return allAnswered;
        }

        public int GetAllPointsCount()
        {
            int allPoints = 0;

            foreach (var item in questionsItems)
            {
                if(item.GetAnsweredState())
                {
                    allPoints += item.GetPointsOfAnswer();
                }
            }

            return allPoints;
        }

        public int GetAllQuestionsCount()
        {
            return questionsItems.Count;
        }

        public int GetCurrenPointertIndex()
        {
            return currentPointerIndex;
        }

        public IQuestionItem GetQuestionByIndex(int _argIndex)
        {
            return GetQuestionsList()[_argIndex];
        }

        public IList<IQuestionItem> GetQuestionsList()
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

        public IQuestionItem GetCurrentQuestion()
        {
            return GetQuestionsList()[GetCurrenPointertIndex()];
        }

        public void CallNextIndex()
        {
            currentPointerIndex++;
        }

        public void SetCurrenPointertIndex(int _argIndex)
        {
            currentPointerIndex = _argIndex;
        }

        public void CallAnswerForQuestion(int _argIndexQuestion, int _argIndexAnswer)
        {
            IQuestionItem bufferQuestion = questionsItems[_argIndexQuestion];
            IAnswerItem bufferAnswer = bufferQuestion.GetIAnswersListsOnly()[_argIndexAnswer];
            CallToAnswerFromAnswer(questionsItems[_argIndexQuestion], bufferAnswer);
        }

        public void CallToAnswerFromAnswer(IQuestionItem _argQuestionItem, IAnswerItem _argAnswer)
        {
            if (_argQuestionItem.GetAnsweredState())
                return;

            _argQuestionItem.SetAnsweredState(true);
            _argQuestionItem.SetAnsweredStateByIAnswer(_argAnswer);
        }
    }
}
