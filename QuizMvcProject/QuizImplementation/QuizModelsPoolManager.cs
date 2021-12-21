using QuizMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMvcProject.QuizImplementation
{
    public class QuizModelsPoolManager
    {
        private Queue<QuizPageModel> allQuizPagesModelsHolders = new Queue<QuizPageModel>();

        private Dictionary<int, QuizPageModel> quizModelsDictionary = new Dictionary<int, QuizPageModel>();

        public QuizPageModel GetQuizPageModelFree(out int hashCodeOut)
        {
            QuizPageModel newBufferQuiz = new QuizPageModel(true);
            allQuizPagesModelsHolders.Enqueue(newBufferQuiz);

            int freeHashCode = GetFreeHashForDictionary();
            quizModelsDictionary.Add(freeHashCode, newBufferQuiz);

            hashCodeOut = freeHashCode;
            return newBufferQuiz;
        }

        public QuizPageModel GetQuizPageModelFrFromHash(int _hashCode)
        {
            QuizPageModel bufferQuizPAgeModel = quizModelsDictionary.GetValueOrDefault(_hashCode);
            return bufferQuizPAgeModel;
        }

        private int GetFreeHashForDictionary()
        {
            QuizPageModel bufferPickedModel = null;
            Random fastRandom = new Random();
            int potentialHashCode;
            do
            {
                potentialHashCode = fastRandom.Next(0, 99999);
                quizModelsDictionary.TryGetValue(potentialHashCode, out bufferPickedModel);
            } 
            while (bufferPickedModel!=null);
            return potentialHashCode;
        }
    }
}
