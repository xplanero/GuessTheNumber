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

        // “Protagonismo”: el juego emite lo que ha pasado
        public event EventHandler<GameStateChangedEventArgs>? StateChanged;

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
            _secret = _random.Next(Min, Max + 1);

            RaiseStateChanged(new GameStateChangedEventArgs(
                result: GuessResult.None,
                message: $"Nuevo juego. Adivina un número entre {Min} y {Max}.",
                attempts: Attempts,
                isFinished: IsFinished
            ));
        }

        public void TryGuess(int value)
        {
            if (IsFinished)
            {
                RaiseStateChanged(new GameStateChangedEventArgs(
                    GuessResult.AlreadyFinished,
                    "La partida ya terminó. Pulsa “Nuevo juego”.",
                    Attempts,
                    IsFinished
                ));
                return;
            }

            if (value < Min || value > Max)
            {
                RaiseStateChanged(new GameStateChangedEventArgs(
                    GuessResult.OutOfRange,
                    $"Fuera de rango. Debe estar entre {Min} y {Max}.",
                    Attempts,
                    IsFinished
                ));
                return;
            }

            Attempts++;

            if (value < _secret)
            {
                RaiseStateChanged(new GameStateChangedEventArgs(
                    GuessResult.TooLow,
                    "Más alto.",
                    Attempts,
                    IsFinished
                ));
                return;
            }

            if (value > _secret)
            {
                RaiseStateChanged(new GameStateChangedEventArgs(
                    GuessResult.TooHigh,
                    "Más bajo.",
                    Attempts,
                    IsFinished
                ));
                return;
            }

            IsFinished = true;
            RaiseStateChanged(new GameStateChangedEventArgs(
                GuessResult.Correct,
                $"¡Correcto! 🎉 Lo lograste en {Attempts} intentos.",
                Attempts,
                IsFinished
            ));
        }

        private void RaiseStateChanged(GameStateChangedEventArgs args)
            => StateChanged?.Invoke(this, args);
    }

    public enum GuessResult
    {
        None,
        TooLow,
        TooHigh,
        Correct,
        AlreadyFinished,
        OutOfRange
    }

    public sealed class GameStateChangedEventArgs : EventArgs
    {
        public GuessResult Result { get; }
        public string Message { get; }
        public int Attempts { get; }
        public bool IsFinished { get; }

        public GameStateChangedEventArgs(GuessResult result, string message, int attempts, bool isFinished)
        {
            Result = result;
            Message = message;
            Attempts = attempts;
            IsFinished = isFinished;
        }
    }
}