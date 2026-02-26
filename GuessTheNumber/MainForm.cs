using System;
using System.Windows.Forms;
//Realizado por CHATGPT-4, basado en el ejercicio de adivinar
//un número. El código se ha estructurado para que el juego tenga el protagonismo,
//emitiendo eventos con su estado, y la UI solo se encarga de mostrarlo y enviar los intentos del usuario.
namespace GuessTheNumber
{
    public partial class MainForm : Form
    {
        private readonly NumberGuessGame _game = new(min: 1, max: 100);

        public MainForm()
        {
            InitializeComponent();

            // La UI escucha al juego
            _game.StateChanged += Game_StateChanged;

            // Primer estado
            lblRange.Text = $"Rango: {_game.Min} – {_game.Max}";
        }

        private void Game_StateChanged(object? sender, GameStateChangedEventArgs e)
        {
            lblHint.Text = e.Message;
            lblAttempts.Text = $"Intentos: {e.Attempts}";

            txtGuess.Enabled = !e.IsFinished;
            btnTry.Enabled = !e.IsFinished;

            txtGuess.SelectAll();
            txtGuess.Focus();
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

            // La UI NO decide el resultado, solo envía el intento
            _game.TryGuess(value);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _game.Reset();
            txtGuess.Text = "";
        }
    }
}