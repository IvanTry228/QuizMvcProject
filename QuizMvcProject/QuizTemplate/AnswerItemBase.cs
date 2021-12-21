using QuizMvcProject.QuizImplementation;
using QuizMvcProject.QuizTemplate;

namespace Quick_Quiz.QuizTemplate
{
    public static class QuizStatic
    {
        public const int pointFalse = 0;
        public const int pointTrue = 1;
    }

    public interface ICustomConsoleLoggable
    {
        void CallConsoleLog();
    }

    public interface IAnswerItem : IStatusQuestion
    {
        //getters:
        string GetAnswerText();
        int GetAnswerPoint();

        //setters (builder)
        IAnswerItem SetAnswerText(string _newText);
        IAnswerItem SetAnswerPoints(int _newPoints);

        void FuncOnAnswered();
    }

    public class AnswerItemBase : IAnswerItem
    {
        public int id { get; private set; }
        public string? answerText { get; private set; }
        public int answerPoints { get; private set; } //default 0 false, 1 true, or other 

        public IQuestionItem CurrentQuestion { get; set; }

        //public AnswerBase(string _answerText, int _answerPoints)
        //{
        //    answerStruct.answerText = _answerText;
        //    answerStruct.answerPoints = _answerPoints;
        //}

        //IAnswer:
        public virtual void FuncOnAnswered()
        {

        }

        //getters
        public string GetAnswerText()
        {
            return answerText;
        }

        public int GetAnswerPoint()
        {
            return answerPoints;
        }

        //setters
        public IAnswerItem SetAnswerPoints(int _newPoints)
        {
            answerPoints = _newPoints;
            return this;
        }

        public IAnswerItem SetAnswerText(string _newText)
        {
            answerText = _newText;
            return this;
        }

        public int GetIndexStatusQuestion()
        {
            int statusIndex;

            if (CurrentQuestion.GetAnsweredState())
            {
                int pointOfAnswer = CurrentQuestion.GetPointsOfAnswer();
                IAnswerItem answeredItem = CurrentQuestion.GetAnsweredItem();
                if (pointOfAnswer <= 0)
                    statusIndex = (int)StatusQuestionAnswered.Wrong;
                else
                    statusIndex = (int)StatusQuestionAnswered.Success;

                if(this != answeredItem)
                    statusIndex = (int)StatusQuestionAnswered.DefaultNot;
            }
            else
                statusIndex = (int)StatusQuestionAnswered.DefaultNot;

            return statusIndex;
        }

        public virtual string GetStatusString()
        {
            return ViewQuizDictionary.AllAnswersButtonsViews[GetIndexStatusQuestion()];
        }
    }
}
