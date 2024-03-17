using System.Text;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
    }
    public void Hide()
    {
        StringBuilder hiddenText = new StringBuilder();

        foreach (char c in _text)
        {
           if (char.IsLetter(c)) 
           {
                hiddenText.Append("_");
           }
           else
           {
                hiddenText.Append(c);
           }
        }
        _text = hiddenText.ToString();
        _isHidden = true;
    }
    public void Show()
    {
        _isHidden = false;
    }
    public bool IsHidden()
    {
        if (_isHidden == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public string GetDisplayText()
    {
        return _text;
    }
}