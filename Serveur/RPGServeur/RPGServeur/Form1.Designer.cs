namespace RPGServeur
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblStatutServeur = new System.Windows.Forms.Label();
            this.btnActiver = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblStatutServeur
            // 
            this.lblStatutServeur.AutoSize = true;
            this.lblStatutServeur.Location = new System.Drawing.Point(12, 18);
            this.lblStatutServeur.Name = "lblStatutServeur";
            this.lblStatutServeur.Size = new System.Drawing.Size(92, 13);
            this.lblStatutServeur.TabIndex = 0;
            this.lblStatutServeur.Text = "Statut : Désactivé";
            // 
            // btnActiver
            // 
            this.btnActiver.Location = new System.Drawing.Point(12, 54);
            this.btnActiver.Name = "btnActiver";
            this.btnActiver.Size = new System.Drawing.Size(92, 37);
            this.btnActiver.TabIndex = 2;
            this.btnActiver.Text = "Désactiver";
            this.btnActiver.UseVisualStyleBackColor = true;
            this.btnActiver.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 424);
            this.Controls.Add(this.btnActiver);
            this.Controls.Add(this.lblStatutServeur);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatutServeur;
        private System.Windows.Forms.Button btnActiver;
        private System.Windows.Forms.Timer timer1;
    }
}

