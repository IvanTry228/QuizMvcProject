using DotNetExtra.DataBaseParsing;
using DotNetExtra.QuizImplementation;
using QuizMvcProject.VideosAssets;
using QuizTemplateMvcDotnet6.VideosTools;
using System.Collections.Generic;

namespace QuizTemplateMvcDotnet6.Models
{
    public class TestQuestionModel
    {
        public string testTitle = " its test str ";

        public QuizPdd_Question currentQuestion { get; private set; }

        public void FillRandom()
        {
            currentQuestion = HolderDataNewPdd.GetRandomQuestion();
        }

        public void FillById(int _id, out bool _isFinded)
        {
            currentQuestion = HolderDataNewPdd.TryGetQuestion(_id);

            if(currentQuestion==null)
                _isFinded = false;
            else
                _isFinded = true;
        }

        public string GetText()
        {
            //FillRandom();
            string textQuestion = QuizQuestionLoggerHelper.LogQuestionString(currentQuestion);;
            return textQuestion;
        }

        public string GetUrlRef()
        {
            return currentQuestion.GetPictureGetter().GetPictureSourceString();
        }

        public List<VideoItem> GetVideosList()
        {
            return VideosHolder.AllVideosHolder;
        }
    }
}
