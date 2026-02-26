using System;

namespace GuessTheNumber
{
    public sealed class NumberGuessGame
    {
        private readonly Random _random = new();
        private int _secret;

        public int Min { get; }
        public int Max { get; }
        public int Attempts { get; private set; }
        public bool IsFinished { get; private set; }

        public NumberGuessGame(int min, int max)
        {
            if (min >= max) throw new ArgumentException("min debe ser menor que max.");
            Min = min;
            Max = max;
            Reset();
        }

        public void Reset()
        {
            Attempts = 0;
            IsFinished = false;
            _secret = _random.Next(Min, Max + 1); // inclusive
        }

        public GuessResult TryGuess(int value)
        {
            if (IsFinished) return GuessResult.AlreadyFinished;

            Attempts++;

            if (value < _secret) return GuessResult.TooLow;
            if (value > _secret) return GuessResult.TooHigh;

            IsFinished = true;
            return GuessResult.Correct;
        }
    }

    public enum GuessResult
    {
        TooLow,
        TooHigh,
        Correct,
        AlreadyFinished
    }
}