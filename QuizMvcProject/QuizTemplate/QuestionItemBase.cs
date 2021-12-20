using DotNetExtra.QuizTemplate;
using QuizMvcProject.QuizImplementation;
using QuizMvcProject.QuizTemplate;
using System.Collections.Generic;

namespace Quick_Quiz.QuizTemplate
{
    public interface IQuestionItem  : IDable, IStatusQuestion //: IQuestionItem<T>
    {
        string GetQuestionText();
        bool GetAnsweredState();
        void SetAnsweredState(bool _newIsAnswered);

        IList<IAnswerItem> GetIAnswersListsOnly();

        //new

        void SetAnsweredStateByIAnswer(IAnswerItem _ianswerItem);
        void SetAnsweredStateByIAnswersList(IList<IAnswerItem> _ianswerItem);

        int GetPointsOfAnswer();
    }

    public interface IQuestionItem<Tansw> : IQuestionItem where Tansw : IAnswerItem
    {
        IQuestionItem<Tansw> SetQuestionText(string _questionText);
        IQuestionItem<Tansw> SetAnswersList(IList<Tansw> _newAnswers);
        IList<Tansw> GetIAnswersListGeneric();
    }

    public class QuestionItemBase<Tansw, Tpict> : IQuestionItem<Tansw>, IPictureble where Tansw : IAnswerItem where Tpict : IPictureGetterTypeStringable
    {
        public int id { get; protected set; }
        public string questionText { get; protected set; }

        public IList<Tansw> answersItemsList { get; set; }

        public Tpict currentIPictureGetterStringable { get; private set; }

        private bool isAnsweredState;

        //new
        private IList<Tansw> answeredItemssList;
        private Tansw answeredItemSingle;

        public IQuestionItem<Tansw> SetAnswersList(IList<Tansw> _newAnswers)
        {
            answersItemsList = _newAnswers;
            return this;
        }

        public IList<Tansw> GetIAnswersListGeneric()
        {
            return answersItemsList;
        }

        public IList<IAnswerItem> GetIAnswersListsOnly()
        {
            List<IAnswerItem> bufferToReturn = new List<IAnswerItem>();

            foreach (var item in answersItemsList)
            {
                bufferToReturn.Add(item);
            }

            //for (int i = 0; i < answersItemsList.Count; i++)
            //{
            //    Console.WriteLine("answersItemsList.Count = " + answersItemsList.Count);
            //    Console.WriteLine("bufferToReturn.Count = " + bufferToReturn.Count);

            //    bufferToReturn[i] = answersItemsList[i];
            //}

            return bufferToReturn;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int _newId)
        {
            id = _newId;
        }

        public string GetQuestionText()
        {
            return questionText;
        }

        public IQuestionItem<Tansw> SetQuestionText(string _questionText)
        {
            questionText = _questionText;
            return this;
        }

        public bool GetAnsweredState()
        {
            return isAnsweredState;
        }

        public void SetAnsweredState(bool _newIsAnswered)
        {
            isAnsweredState = _newIsAnswered;
        }

        public IPictureGetterTypeStringable GetPictureGetter()
        {
            return (IPictureGetterTypeStringable)currentIPictureGetterStringable;
        }

        public void SetPictureGetter(IPictureGetterTypeStringable _pictureableStringable)
        {
            currentIPictureGetterStringable = (Tpict)_pictureableStringable;
        }

        public int GetPointsOfAnswer()
        {
            //only for single:
            return answeredItemSingle.GetAnswerPoint();
        }

        public void SetAnsweredStateByIAnswer(IAnswerItem _ianswerItem)
        {
            answeredItemSingle = (Tansw)_ianswerItem;
        }

        public void SetAnsweredStateByIAnswersList(IList<IAnswerItem> _ianswerItem)
        {
            answeredItemssList = (IList<Tansw>)_ianswerItem;
        }

        public int GetIndexStatusQuestion()
        {
            int statusIndex;

            if (GetAnsweredState())
            {
                int pointOfAnswer = GetPointsOfAnswer();
                if (pointOfAnswer==0)
                    statusIndex = (int)StatusQuestionAnswered.Wrong;
                else
                    statusIndex = (int)StatusQuestionAnswered.Success;
            }
            else
                statusIndex = (int)StatusQuestionAnswered.DefaultNot;

            return statusIndex;
        }

        public virtual string GetStatusString()
        {
            return ViewQuizDictionary.AllButtonsNames[GetIndexStatusQuestion()];
        }
    }
}
