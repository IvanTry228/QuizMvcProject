using Quick_Quiz;
using Quick_Quiz.QuizTemplate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetExtra.DataBaseParsing
{
    public class QuizQuestionLoggerHelper
    {
        public static async void LogQuestionListsItems(IList<IQuestionItem> _questionsList)
        {
            foreach (PddQuestion itemQuestion in _questionsList)
            {
                LogQuestionItem(itemQuestion);
                await Task.Delay(50);
            }
        }

        public static void LogQuestionItem(IQuestionItem _argQuestion)
        {
            Console.WriteLine("IQuestionItem _argQuestion testAnswers = " + GetQuestionLogString<IAnswerItem>((IQuestionItem<IAnswerItem>)_argQuestion));
        }

        public static void LogQuestionItemUniversal(IQuestionItem _argQuestion)
        {
            Console.WriteLine("IQuestionItem _argQuestion testAnswers = " + LogQuestionString(_argQuestion));
        }

        public static string LogQuestionString(IQuestionItem _argQuestion)
        {
            string logString = "Question id: " + _argQuestion.GetId() + "\n";

            logString += " " + _argQuestion.GetQuestionText() + "\n";

            logString += "\nAnswers:\n";

            foreach (var item in _argQuestion.GetIAnswersListsOnly())
            {
                logString += item.GetAnswerText() + "\n";
            }

            return logString;
        }

        public static string GetQuestionLogString<T>(IQuestionItem<IAnswerItem> _argQuestion)
        {
            string testAnswers = _argQuestion.GetId() + " " + _argQuestion.GetQuestionText() + " \n";

            foreach (var item in _argQuestion.GetIAnswersListGeneric())
            {
                testAnswers += " item.GetAnswerText() = " + item.GetAnswerText();
            }

            return testAnswers;
        }
    }

}
 