using System.Collections.Generic;

namespace SbsApplication.Models
{
    public interface IHangmanWordModel
    {
        int Chances { get; set; }
        string GameMessage { get; set; }
        string HangmanWord { get; set; }
        List<string> HangmanWordList { get; set; }
        string LettersAttempted { get; set; }
        int Level { get; set; }
    }
}