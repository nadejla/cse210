using System.Text;

public class Scripture
{
    // These are the member variables.
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    // This is the constructor.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        char separator = ' ';
        string[] words = text.Split(separator);
        // I found this resource online to help me.
        // https://ironpdf.com/blog/net-help/csharp-split-string-guide/#:~:text=Imagine%20you%20have%20a%20sentence,based%20on%20a%20given%20separator.
        foreach (string splitWord in words)
        {
            Word word = new Word(splitWord);
            _words.Add(word);
        }
        // add code to pass the text of the scripture, create a list,
        // split up the words in the text to create Word object for each
        // one and put them in the list
    }

    // These are the methods.
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            // I found this resource to help with checking all the words.
            // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all?view=net-8.0&redirectedfrom=MSDN#System_Linq_Enumerable_All__1_System_Collections_Generic_IEnumerable___0__System_Func___0_System_Boolean__
            if (_words.All(word => word.IsHidden()))
            {
                break;
            }
            int randomIndex = random.Next(_words.Count);
            if (_words[randomIndex].IsHidden() == false)
            {
                _words[randomIndex].Hide();
            }
            else
            {
                i--;
            }
        } 
    }
    
    public string GetDisplayText()
    {
        string reference = _reference.GetDisplayText();
        StringBuilder scriptureText = new StringBuilder();
        foreach (Word word in _words)
        {
            scriptureText.Append($"{word.GetDisplayText()} ");
        }
        return $"{reference} {scriptureText}";
    }
    public bool IsCompletelyHidden()
    {
        if (_words.All(word => word.IsHidden()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}