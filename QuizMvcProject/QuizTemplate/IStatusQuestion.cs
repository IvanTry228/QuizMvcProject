using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMvcProject.QuizTemplate
{
    public interface IStatusQuestion
    {
        int GetIndexStatusQuestion();
        string GetStatusString();
    }
}
