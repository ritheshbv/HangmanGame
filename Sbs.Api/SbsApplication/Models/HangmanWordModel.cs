using System.Collections.Generic;

namespace SbsApplication.Models
{
    public class HangmanWordModel : IHangmanWordModel
    {
        public int Chances { get; set; }
        public List<string> HangmanWordList { get; set; }
        public string HangmanWord { get; set; }

        public string GameMessage { get; set; }

        public string LettersAttempted { get; set; }
        public int Level { get; set; }
    }
}
