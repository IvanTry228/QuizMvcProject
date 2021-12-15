using DotNetExtra.CustomUtilities;
using DotNetExtra.QuizImplementation;
using Quick_Quiz;
using QuizTemplateMvcDotnet6.DatabaseSql;
using System;
using System.Collections.Generic;

namespace DotNetExtra.DataBaseParsing
{
    public class ParsingAdapter
    {
        public static void CallParseProcedure()
        {
            ///Console.WriteLine("CallParseProcedure 1 before");
            //await Task.Run(HolderDataOldPdd.CallInitAllOldPddQuestionsAllAndLog);
            HolderDataOldPdd.CallInitAllOldPddQuestionsAllAndLog();
            Console.WriteLine("CallParseProcedure 2 middle");
            HolderDataNewPdd.CallInitNewData();
            Console.WriteLine("CallParseProcedure 3 middle");

            //for (int i = 0; i < 5; i++)
            //{
            //    QuizQuestionLoggerHelper.LogQuestionItemUniversal(HolderDataNewPdd.GetRandomQuestion());
            //}
            //ConvertingProcedure();

            Console.WriteLine("CallParseProcedure 4 middle");
        }

        public static void ConvertingProcedure()
        {
            //for (int i = 0; i < 4; i++)
            //{
            //    ConvertFromOldPddQuestionToNewEntity(HolderDataOldPdd.allPddQUestion[i], HolderDataNewPdd.allHolderNewDataContext);
            //}
            foreach (var item in HolderDataOldPdd.allPddQUestion)
            {
                ConvertFromOldPddQuestionToNewEntity(item, HolderDataNewPdd.allHolderNewDataContext);
            }
            HolderDataNewPdd.allHolderNewDataContext.SaveChanges();
        }

        public static void ConvertFromOldPddQuestionToNewEntity(PddQuestion _oldPddQuestion, QuizTemplate_DbContext _newQuizDbContext)
        {
            QuizPdd_Question bufferQuestion = new QuizPdd_Question();

            //QuizPdd_Answer PddAllAnswers
            IList<QuizPdd_Answer> bufferQuizAnswers = new List<QuizPdd_Answer>(); //(List<QuizPdd_Answer>)_oldPddQuestion.GetIAnswersList();

            ContextOpearionsExtensions.RemoveEntityIfExist(_newQuizDbContext.PddAllQuestions, _oldPddQuestion.GetId());
            _newQuizDbContext.SaveChanges(); //for clear related entities

            bufferQuestion.SetId(_oldPddQuestion.GetId()); // ContextOpearionsExtensions.GetDbItemFromDbByID(_newQuizDbContext.PddAllQuestions, _oldPddQuestion.GetId(), bufferQuestion);

            foreach (var item in _oldPddQuestion.GetIAnswersListGeneric())
            {
                QuizPdd_Answer bufferAnswer = new QuizPdd_Answer();
                bufferAnswer.SetAnswerText(item.GetAnswerText()).SetAnswerPoints(item.GetAnswerPoint());
                bufferQuizAnswers.Add(bufferAnswer);
            }

            foreach (var item in bufferQuizAnswers)
            {
                item.CurrentQuestion = bufferQuestion;
            }

            bufferQuestion.SetQuestionText(_oldPddQuestion.GetQuestionText()).SetAnswersList(bufferQuizAnswers);

            QuizPdd_PictureeGetterUrl bufferPicturePdd = new QuizPdd_PictureeGetterUrl();
            bufferPicturePdd.SetPictureSourceString(_oldPddQuestion.GetPictureSourceString());
            bufferPicturePdd.CurrentQuestion = bufferQuestion;

            _newQuizDbContext.PddAllQuestions.Add(bufferQuestion);
            _newQuizDbContext.PddAllPictureables.Add(bufferPicturePdd);
            _newQuizDbContext.PddAllAnswers.AddRange(bufferQuizAnswers);
        }
    }
}
 