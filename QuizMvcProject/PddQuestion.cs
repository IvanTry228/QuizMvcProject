using Quick_Quiz.QuizTemplate;
using System.Collections.Generic;

namespace Quick_Quiz
{
    public class PddQuestion : IQuestionItem<IAnswerItem>, IPictureGetterTypeStringable
    {
        public int questId { get; set; }
        public string questText { get; set; }

        public string[] questAnswers = new string[] { }; //old

        public IList<IAnswerItem> answersList { get; private set; } // = new IList<IAnswerItem>(); //new

        public int questAmountAnswers { get; set; }
        public string urlPicture { get; set; }

        public bool isAnswered = false;
        public bool isTrueAnswered;

        public PddQuestion(int _questId, string _questText, string[] _questAnswers, int _questAmountAnswers, string _urlPicture)
        {
            questId = _questId;
            questText = _questText;
            questAnswers = _questAnswers;
            questAmountAnswers = _questAmountAnswers;
            urlPicture = _urlPicture;
        }

        public IQuestionItem<IAnswerItem> SetAnswersList(IList<IAnswerItem> _newAnswers)
        {
            answersList = new List<IAnswerItem>(_newAnswers);
            return this;
        }

        public IList<IAnswerItem> GetIAnswersListGeneric()
        {
            return answersList;
        }

        public string GetQuestionText()
        {
            return questText;
        }

        public IQuestionItem<IAnswerItem> SetQuestionText(string _questionText)
        {
            questText = _questionText;
            return this;
        }

        public bool GetAnsweredState()
        {
            return isAnswered;
        }

        public int GetId()
        {
            return questId;
        }

        public void SetAnsweredState(bool _newIsAnswered)
        {
            isAnswered = _newIsAnswered;
        }

        public void SetId(int _newId)
        {
            questId = _newId;
        }

        public string GetPictureSourceString()
        {
            return urlPicture;
        }

        public void SetPictureSourceString(string _argSource)
        {
            urlPicture = _argSource;
        }

        public IList<IAnswerItem> GetIAnswersListsOnly()
        {
            return (IList<IAnswerItem>)answersList;
        }

        public void SetAnsweredStateByIAnswer(IAnswerItem _ianswerItem)
        {
            throw new System.NotImplementedException();
        }

        public void SetAnsweredStateByIAnswersList(IList<IAnswerItem> _ianswerItem)
        {
            throw new System.NotImplementedException();
        }

        public int GetPointsOfAnswer()
        {
            throw new System.NotImplementedException();
        }

        public int GetIndexStatusQuestion()
        {
            throw new System.NotImplementedException();
        }

        public string GetStatusString()
        {
            throw new System.NotImplementedException();
        }
    }

    public class PddAnswerItem : IAnswerItem
    {
        private string currentAnswerText;
        private int answersPoint;

        public void FuncOnAnswered()
        {

        }

        public int GetAnswerPoint()
        {
            return answersPoint;
        }

        public string GetAnswerText()
        {
            return currentAnswerText;
        }

        public IAnswerItem SetAnswerPoints(int _newPoints)
        {
            answersPoint = _newPoints;
            return this;
        }

        public IAnswerItem SetAnswerText(string _newText)
        {
            currentAnswerText = _newText;
            return this;
        }
    }

    public class PddQuiz
    {
        public int countQuestions; //20
        public int currentIndexPosition = 0; //0-20
        //public Button[] quizArrayButtons = new Button[] {  }; //pddForm.button2, pddForm.button3, pddForm.button4, pddForm.button5, pddForm.button7

        //private string timerString;

        public int IquestId;
        public string IquestText;
        public string[] IquestAnswers = new string[] { };
        public int IquestAmountAnswers;

        //PddQuestion[] arrayQustions = new PddQuestion[] { };
        public List<PddQuestion> ListQuestions = new List<PddQuestion>();

        public PddQuiz(int _countQuestions)
        {
            countQuestions = _countQuestions;
        }
    }
}
