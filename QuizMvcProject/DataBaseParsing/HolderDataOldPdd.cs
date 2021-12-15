using DotNetExtra.CustomUtilities;
using Quick_Quiz;
using Quick_Quiz.QuizTemplate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetExtra.DataBaseParsing
{
    public class HolderDataOldPdd
    {
        public static List<PddQuestion> allPddQUestion { get; private set; } = new List<PddQuestion>();

        public static async void CallInitAllOldPddQuestionsAllAndLog()
        {
            SqlDbManager.WakeSqlDb();

            allPddQUestion.Clear();

            var testData = SqlDbManager.GetAllData();

            foreach (DataRow itemRow in testData.Rows)
            {
                ToInsertQuestionFromRow(itemRow);
            }

            for (int i = 0; i < 5; i++)
            {
                QuizQuestionLoggerHelper.LogQuestionItem(allPddQUestion.GetRandomItem());
            }

            Console.WriteLine("Old data successfull loaded, all counts : = " + allPddQUestion.Count);

            //await Task.Run(TestAsyncCallInitPddQuestionsAll);
        }

        private static async void TestAsyncCallInitPddQuestionsAll()
        {
            Console.WriteLine("TestAsync start");
            await Task.Run(()=>QuizQuestionLoggerHelper.LogQuestionListsItems(new List<IQuestionItem>(allPddQUestion)));
            Console.WriteLine("TestAsync end");
        }

        private static void ToInsertQuestionFromRow(DataRow _row)
        {
            string _idQuestion = _row["idQuestion"].ToString();
            string _textQuestion = _row["textQuestion"].ToString();
            string _allAnswers = _row["allAnswers"].ToString();
            string _amountAnswers = _row["amountAnswers"].ToString();
            string _urlPicture = _row["pictureUrl"].ToString();
            string[] _answersArray = _allAnswers.Split(';');

            PddQuestion bufferPddQuestion = new PddQuestion(int.Parse(_idQuestion), _textQuestion, _answersArray, int.Parse(_amountAnswers), _urlPicture);
            bufferPddQuestion.SetPictureSourceString(_urlPicture);

            List<IAnswerItem> bufferIAnswerItems = new List<IAnswerItem>();

            foreach (string itemAnswer in _answersArray)
            {
                //Console.WriteLine("ToInsertQuestionFromRow itemAnswer = !" + itemAnswer + "!");
                //Console.WriteLine("ToInsertQuestionFromRow Count = !" + itemAnswer.Count() + "!");

                if (itemAnswer.Count() <= 2) continue;

                PddAnswerItem bufferPddAnswer = new PddAnswerItem();
                bufferPddAnswer.SetAnswerText(itemAnswer);
                bufferIAnswerItems.Add(bufferPddAnswer);
            }

            int indexRightQuestion = 0; //in db
            bufferIAnswerItems[indexRightQuestion].SetAnswerPoints(QuizStatic.pointTrue);

            bufferPddQuestion.SetAnswersList(bufferIAnswerItems);

            allPddQUestion.Add(bufferPddQuestion);
        }
    }
}
 