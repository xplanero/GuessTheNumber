using System;
using System.Windows.Forms;

namespace GuessTheNumber
{
    public partial class MainForm : Form
    {
        private readonly NumberGuessGame _game = new(min: 1, max: 100);

        public MainForm()
        {
            InitializeComponent();
            ApplyNewGameState();
        }

        private void btnTry_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGuess.Text, out int value))
            {
                lblHint.Text = "Introduce un número válido.";
                txtGuess.SelectAll();
                txtGuess.Focus();
                return;
            }

            if (value < _game.Min || value > _game.Max)
            {
                lblHint.Text = $"El número debe estar entre {_game.Min} y {_game.Max}.";
                txtGuess.SelectAll();
                txtGuess.Focus();
                return;
            }

            var result = _game.TryGuess(value);

            lblAttempts.Text = $"Intentos: {_game.Attempts}";

            lblHint.Text = result switch
            {
                GuessResult.TooLow => "Más alto.",
                GuessResult.TooHigh => "Más bajo.",
                GuessResult.Correct => "¡Correcto! 🎉 Pulsa “Nuevo juego” para repetir.",
                GuessResult.AlreadyFinished => "La partida ya terminó. Pulsa “Nuevo juego”.",
                _ => "—"
            };

            if (result == GuessResult.Correct)
            {
                txtGuess.Enabled = false;
                btnTry.Enabled = false;
            }

            txtGuess.SelectAll();
            txtGuess.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _game.Reset();
            ApplyNewGameState();
        }

        private void ApplyNewGameState()
        {
            lblRange.Text = $"Rango: {_game.Min} – {_game.Max}";
            lblAttempts.Text = "Intentos: 0";
            lblHint.Text = "Escribe un número y pulsa “Probar”.";
            txtGuess.Enabled = true;
            btnTry.Enabled = true;
            txtGuess.Text = "";
            txtGuess.Focus();
        }
    }
}