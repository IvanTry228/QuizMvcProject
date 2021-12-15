using Microsoft.EntityFrameworkCore;
using Quick_Quiz.QuizTemplate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetExtra.QuizImplementation
{
    public class CustomSqlConfig
    {
        public const string mysqlstr =
            "server=localhost;" + //server=127.0.0.1
            "port=3306;" +
            "user=root;" +
            "password=mysqlroot1111;"; //allusersdb

        public const string dataBase_testpdd3 = "database=testpdd3;";

        public const string database_quiztest = "database=quiznewtest3;";
    }

    //sample implement one-to-many
    //one:
    public class QuizPdd_Question : QuestionItemBase<QuizPdd_Answer, QuizPdd_PictureeGetterUrl>
    {

    }
    //many
    public class QuizPdd_Answer : AnswerItemBase
    {

    }

    //public class QuizPdd_PictureableBaser : PictureBase
    //{

    //}

    public class QuizPdd_PictureeGetterUrl : PictureFromUrl
    {
        public QuizPdd_Question CurrentQuestion { get; set; }

        public int currentQuestionId { get; set; }

        //public 
    }
}
