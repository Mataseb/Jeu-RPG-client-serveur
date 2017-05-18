namespace ReturnMapTest
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
            this.btnPlayer1 = new System.Windows.Forms.Button();
            this.btnPlayer2 = new System.Windows.Forms.Button();
            this.btnPlayer3 = new System.Windows.Forms.Button();
            this.btnPlayer4 = new System.Windows.Forms.Button();
            this.playerMap2 = new ReturnMapTest.ClassGame.PlayerMap();
            ((System.ComponentModel.ISupportInitialize)(this.playerMap2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlayer1
            // 
            this.btnPlayer1.Location = new System.Drawing.Point(5, 609);
            this.btnPlayer1.Name = "btnPlayer1";
            this.btnPlayer1.Size = new System.Drawing.Size(145, 40);
            this.btnPlayer1.TabIndex = 6;
            this.btnPlayer1.Text = "Joueur 1";
            this.btnPlayer1.UseVisualStyleBackColor = true;
            this.btnPlayer1.Click += new System.EventHandler(this.btnPlayer1_Click);
            // 
            // btnPlayer2
            // 
            this.btnPlayer2.Location = new System.Drawing.Point(156, 609);
            this.btnPlayer2.Name = "btnPlayer2";
            this.btnPlayer2.Size = new System.Drawing.Size(145, 40);
            this.btnPlayer2.TabIndex = 7;
            this.btnPlayer2.Text = "Joueur 2";
            this.btnPlayer2.UseVisualStyleBackColor = true;
            this.btnPlayer2.Click += new System.EventHandler(this.btnPlayer2_Click);
            // 
            // btnPlayer3
            // 
            this.btnPlayer3.Location = new System.Drawing.Point(307, 609);
            this.btnPlayer3.Name = "btnPlayer3";
            this.btnPlayer3.Size = new System.Drawing.Size(145, 40);
            this.btnPlayer3.TabIndex = 8;
            this.btnPlayer3.Text = "Joueur 3";
            this.btnPlayer3.UseVisualStyleBackColor = true;
            this.btnPlayer3.Click += new System.EventHandler(this.btnPlayer3_Click);
            // 
            // btnPlayer4
            // 
            this.btnPlayer4.Location = new System.Drawing.Point(458, 609);
            this.btnPlayer4.Name = "btnPlayer4";
            this.btnPlayer4.Size = new System.Drawing.Size(145, 40);
            this.btnPlayer4.TabIndex = 9;
            this.btnPlayer4.Text = "Joueur 4";
            this.btnPlayer4.UseVisualStyleBackColor = true;
            this.btnPlayer4.Click += new System.EventHandler(this.btnPlayer4_Click);
            // 
            // playerMap2
            // 
            this.playerMap2.Location = new System.Drawing.Point(4, 3);
            this.playerMap2.Name = "playerMap2";
            this.playerMap2.Size = new System.Drawing.Size(600, 600);
            this.playerMap2.TabIndex = 15;
            this.playerMap2.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(608, 654);
            this.Controls.Add(this.playerMap2);
            this.Controls.Add(this.btnPlayer4);
            this.Controls.Add(this.btnPlayer3);
            this.Controls.Add(this.btnPlayer2);
            this.Controls.Add(this.btnPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.playerMap2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassGame.PlayerMap playerMap1;
        private System.Windows.Forms.Button btnPlayer1;
        private System.Windows.Forms.Button btnPlayer2;
        private System.Windows.Forms.Button btnPlayer3;
        private System.Windows.Forms.Button btnPlayer4;
        private ClassGame.PlayerMap playerMap2;
    }
}

