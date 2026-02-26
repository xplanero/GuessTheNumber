namespace GuessTheNumber
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.TextBox txtGuess;
        private System.Windows.Forms.Button btnTry;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblAttempts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.txtGuess = new System.Windows.Forms.TextBox();
            this.btnTry = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblAttempts = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(18, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Adivina el número";

            // lblRange
            this.lblRange.AutoSize = true;
            this.lblRange.Location = new System.Drawing.Point(20, 50);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(95, 15);
            this.lblRange.TabIndex = 1;
            this.lblRange.Text = "Rango: 1 – 100";

            // txtGuess
            this.txtGuess.Location = new System.Drawing.Point(23, 78);
            this.txtGuess.Name = "txtGuess";
            this.txtGuess.Size = new System.Drawing.Size(120, 23);
            this.txtGuess.TabIndex = 2;

            // btnTry
            this.btnTry.Location = new System.Drawing.Point(155, 77);
            this.btnTry.Name = "btnTry";
            this.btnTry.Size = new System.Drawing.Size(90, 25);
            this.btnTry.TabIndex = 3;
            this.btnTry.Text = "Probar";
            this.btnTry.UseVisualStyleBackColor = true;
            this.btnTry.Click += new System.EventHandler(this.btnTry_Click);

            // btnNew
            this.btnNew.Location = new System.Drawing.Point(255, 77);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(110, 25);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "Nuevo juego";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            // lblHint
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(20, 120);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(18, 15);
            this.lblHint.TabIndex = 5;
            this.lblHint.Text = "—";

            // lblAttempts
            this.lblAttempts.AutoSize = true;
            this.lblAttempts.Location = new System.Drawing.Point(20, 145);
            this.lblAttempts.Name = "lblAttempts";
            this.lblAttempts.Size = new System.Drawing.Size(68, 15);
            this.lblAttempts.TabIndex = 6;
            this.lblAttempts.Text = "Intentos: 0";

            // MainForm
            this.AcceptButton = this.btnTry;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 185);
            this.Controls.Add(this.lblAttempts);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnTry);
            this.Controls.Add(this.txtGuess);
            this.Controls.Add(this.lblRange);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guess the Number";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}