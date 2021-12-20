using Quick_Quiz.QuizTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMvcProject.Models
{
    public class QuizPageModel
    {
        private QuizBase currentQuiz;

        public QuizBase GetQuizBase()
        {
            return currentQuiz;
        }
    }
}
