namespace QuizMvcProject.Models
{
    public interface IMessage
    {
        string GetText();
        IMessage SetText(string _argText);
    }

    public class MessageModel : IMessage
    {
        private string currentText;

        public string GetText()
        {
            return currentText;
        }

        public IMessage SetText(string _argText)
        {
            currentText = _argText;
            return this;
        }

        public MessageModel(string _argText)
        {
            SetText(_argText);
        }
    }
}
