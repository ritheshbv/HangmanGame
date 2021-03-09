using Microsoft.AspNetCore.Mvc;
using SbsApplication.Services;
using System;
using System.Threading.Tasks;

namespace SbsApplication.Controllers
{
    public class HangmanController : Controller
    {       
        private readonly IHangmanService hangmanService;

        public HangmanController(IHangmanService hangmanService)
        {
            this.hangmanService = hangmanService ?? throw new ArgumentNullException(nameof(hangmanService));
        }       

        public IActionResult Level()
        {
            return View();
        }
        public IActionResult Index()
        {
            this.hangmanService.CheckAndUpdateLetters();
            return View(this.hangmanService.Model);
        }

        #region Level page Action region
        public RedirectToActionResult Easy()
        {
            this.hangmanService.UpdateLevel(0);
            return RedirectToAction("Level");
        }
        public RedirectToActionResult Moderate()
        {
            this.hangmanService.UpdateLevel(1);
            return RedirectToAction("Level");
        }
        public RedirectToActionResult Hard()
        {
            this.hangmanService.UpdateLevel(2);
            return RedirectToAction("Level");
        }

        public async Task<RedirectToActionResult> Play()
        {
            var result = await this.hangmanService.GetNewWordBasedOnLevel();
            if (result)
            {
                this.hangmanService.CheckAndUpdateLetters();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Level");            
        }
        #endregion

        public RedirectToActionResult Quit()
        {
            return RedirectToAction("Index", "Home");
        }
        public RedirectToActionResult Replay()
        {
            this.hangmanService.Intialize();
            return RedirectToAction("Level");
        }

        #region Letters action region
        public RedirectToActionResult A()
        {
            LetterAttempted("A");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult B()
        {
            LetterAttempted("B");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult C()
        {
            LetterAttempted("C");
            return RedirectToAction("Index");
        }

        public RedirectToActionResult D()
        {
            LetterAttempted("D");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult E()
        {
            LetterAttempted("E");
            return RedirectToAction("Index");
        }

        public RedirectToActionResult F()
        {
            LetterAttempted("F");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult G()
        {
            LetterAttempted("G");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult H()
        {
            LetterAttempted("H");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult I()
        {
            LetterAttempted("I");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult J()
        {
            LetterAttempted("J");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult K()
        {
            LetterAttempted("K");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult L()
        {
            LetterAttempted("L");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult M()
        {
            LetterAttempted("M");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult N()
        {
            LetterAttempted("N");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult O()
        {
            LetterAttempted("O");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult P()
        {
            LetterAttempted("P");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult Q()
        {
            LetterAttempted("Q");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult R()
        {
            LetterAttempted("R");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult S()
        {
            LetterAttempted("S");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult T()
        {
            LetterAttempted("T");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult U()
        {
            LetterAttempted("U");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult V()
        {
            LetterAttempted("V");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult W()
        {
            LetterAttempted("W");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult X()
        {
            LetterAttempted("X");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult Y()
        {
            LetterAttempted("Y");
            return RedirectToAction("Index");
        }
        public RedirectToActionResult Z()
        {
            LetterAttempted("Z");
            return RedirectToAction("Index");
        }
        private void LetterAttempted(string letter)
        {
            this.hangmanService.AttemptedLetter(letter);
        }
        #endregion
    }
}
