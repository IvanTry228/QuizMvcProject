using QuizTemplateMvcDotnet6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMvcProject.Models
{
    public class QuestionModel
    {
        public TestQuestionModel testQuestionModelObj = new TestQuestionModel();

        private int id = -1;

        public int GetIdQuestion()
        {
            return id;
        }

        public QuestionModel()
        {
            this.id = -1;
            Console.WriteLine("_____________Log QuestionModel id = " + this.id);
        }

        public QuestionModel(int id)
        {
            this.id = id;
            Console.WriteLine("_____________Log QuestionModel id = " + this.id);
        }
    }
}
