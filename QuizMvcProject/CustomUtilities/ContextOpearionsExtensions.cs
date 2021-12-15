using DotNetExtra.QuizTemplate;
using Microsoft.EntityFrameworkCore;
using Quick_Quiz.QuizTemplate;
using System;
using System.Linq;

namespace DotNetExtra.CustomUtilities
{
    public class ContextOpearionsExtensions
    {
        public static T GetSelectRandom<T>(DbSet<T> _someDbSet) where T : class
        {
            if(_someDbSet.Count()==0)
                return default(T);

            T selectItem = _someDbSet.GetRandomItem();
            return selectItem;
        }

        public static void RemoveEntityIfExist<T>(DbSet<T> _someDbContext, int _argId) where T : class
        {
            T findedObj = _someDbContext.Find(_argId);

            if (findedObj != null)
            {
                Console.WriteLine("Find result finded success");
                _someDbContext.Remove(findedObj);
            }
            else
                Console.WriteLine("Not found");
        }

        public static T GetDbItemFromDbByID<T>(DbSet<T> _someDbContext, int _argId, T _argRefObj) where T : class
        {
            T findedObj = _someDbContext.Find(_argId);

            if (findedObj != null)
            {
                Console.WriteLine("Find result finded success");
                return findedObj;
            }
            else //create with id
            {
                Console.WriteLine("Find result = null");
                try
                {
                    //findedObj = default;
                    IDable testIdable = null;
                    testIdable = (IDable)_argRefObj;
                    testIdable.SetId(_argId);

                    findedObj = _argRefObj;
                }
                catch (Exception)
                {
                    Console.WriteLine("GetDbItemFromDbByID Exception with cant Cast TO IIDable interface. Returned null");
                    //throw;
                    return null;
                }
                _someDbContext.Add(findedObj);
                return findedObj;
            }

            //allHolderNewDataContext.Quiz_questions.Add(bufferQuestionTest);
        }
    }
}
