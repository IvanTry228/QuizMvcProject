using DotNetExtra.QuizImplementation;
using DotNetExtra.QuizTemplate;

namespace Quick_Quiz.QuizTemplate
{
    public interface IPictureble
    {
        IPictureGetterTypeStringable GetPictureGetter();
        void SetPictureGetter(IPictureGetterTypeStringable _pictureableStringable);
    }

    public interface IPictureGetterTypeStringable
    {
        string GetPictureSourceString();
        void SetPictureSourceString(string _argSource);
    }

    public class PictureGetterString : IPictureGetterTypeStringable, IDable
    {
        public int id { get; protected set; }

        public string sourcePath { get; private set; }

        public string GetPictureSourceString()
        {
            return sourcePath;
        }

        public void SetPictureSourceString(string _argSource)
        {
            sourcePath = _argSource;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int _newId)
        {
            id = _newId;
        }
    }

    public class PictureFromUrl : PictureGetterString
    {
        
    }

    public class PictureFromMemory : PictureGetterString
    {

    }
}
