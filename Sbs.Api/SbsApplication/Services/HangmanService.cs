using SbsApplication.Models;
using SbsApplication.Services.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApplication.Services
{
    public interface IHangmanService
    {
        IHangmanWordModel Model { get; }
        void Intialize();

        void UpdateLevel(int level);

        void AttemptedLetter(string letter);
        void CheckAndUpdateLetters();

        Task<bool> GetNewWordBasedOnLevel();
    }

    public class HangmanService : IHangmanService
    {
        private readonly IHangmanWordModel model;
        private readonly IHangmanApiService apiService;


        public HangmanService(IHangmanWordModel model, IHangmanApiService apiService)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            Intialize();
        }

        public IHangmanWordModel Model => model;

        public void Intialize()
        {
            this.model.Chances = 6;
            this.model.Level = 0;
            this.model.GameMessage = "Keep Going";
            this.model.LettersAttempted = string.Empty;
            this.model.HangmanWord = string.Empty;
            this.model.HangmanWordList = new List<string>();
        }

        public void UpdateLevel(int level)
        {
            this.model.Level = level;
        }

        public void AttemptedLetter(string letter)
        {
            if (CanDecrementChances(letter))
            {
                this.model.Chances--;
            }

            if (CanUpdateLetterAttemptedChances(letter))
            {
                this.model.LettersAttempted += letter + ' ';
            }

            UpdateGameMessage();
        }

        public void CheckAndUpdateLetters()
        {
            UpdateHangmanWordList();

            if (CanDisplayWinMessage())
            {
                this.model.GameMessage = "You Won!!!";
            }
        }

        public async Task<bool> GetNewWordBasedOnLevel()
        {
            this.model.HangmanWord = await this.apiService.GetWord(this.model.Level);

            return !string.IsNullOrEmpty(this.model.HangmanWord);
        }

        #region Private Methods
        private bool CanDecrementChances(string letter)
        {
            return !this.model.HangmanWord.ToUpper().Contains(letter.ToUpper());
        }

        private bool CanUpdateLetterAttemptedChances(string letter)
        {
            return !this.model.LettersAttempted.ToUpper().Contains(letter.ToUpper());
        }

        private bool CanDisplayWinMessage()
        {
            return !this.model.HangmanWordList.Any(l => l.Equals("_"));
        }

        private void UpdateGameMessage()
        {
            if (this.model.Chances == 0)
            {
                this.model.GameMessage = "You Lost!";
                if (!this.model.HangmanWordList.Any(l => l.Equals("_")))
                {
                    this.model.GameMessage = "You Won!!!";
                }
            }
        }

        private void UpdateHangmanWordList()
        {
            var stringList = new List<string>();
            var characters = this.model.HangmanWord.ToUpper().ToCharArray();
            foreach (var letter in characters)
            {
                if (this.model.LettersAttempted.ToUpper().Contains(letter))
                {
                    stringList.Add(letter.ToString());
                }
                else
                {
                    stringList.Add("_");
                }
            }

            this.model.HangmanWordList = stringList;
        }
        #endregion
    }
}
