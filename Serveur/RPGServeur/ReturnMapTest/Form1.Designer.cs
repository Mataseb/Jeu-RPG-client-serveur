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
            this.btnMovetop = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.lblCoord = new System.Windows.Forms.Label();
            this.lblPlayermaporigin = new System.Windows.Forms.Label();
            this.playerMap1 = new ReturnMapTest.ClassGame.PlayerMap();
            ((System.ComponentModel.ISupportInitialize)(this.playerMap1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMovetop
            // 
            this.btnMovetop.Location = new System.Drawing.Point(503, 28);
            this.btnMovetop.Name = "btnMovetop";
            this.btnMovetop.Size = new System.Drawing.Size(60, 28);
            this.btnMovetop.TabIndex = 1;
            this.btnMovetop.Text = "^";
            this.btnMovetop.UseVisualStyleBackColor = true;
            this.btnMovetop.Click += new System.EventHandler(this.btnMovetop_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Location = new System.Drawing.Point(468, 62);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(60, 26);
            this.btnMoveLeft.TabIndex = 2;
            this.btnMoveLeft.Text = "<";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Location = new System.Drawing.Point(534, 62);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(60, 26);
            this.btnMoveRight.TabIndex = 3;
            this.btnMoveRight.Text = ">";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(503, 94);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(60, 26);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.Text = "v";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // lblCoord
            // 
            this.lblCoord.AutoSize = true;
            this.lblCoord.Location = new System.Drawing.Point(465, 141);
            this.lblCoord.Name = "lblCoord";
            this.lblCoord.Size = new System.Drawing.Size(70, 13);
            this.lblCoord.TabIndex = 6;
            this.lblCoord.Text = "Coordonnées";
            // 
            // lblPlayermaporigin
            // 
            this.lblPlayermaporigin.AutoSize = true;
            this.lblPlayermaporigin.Location = new System.Drawing.Point(465, 179);
            this.lblPlayermaporigin.Name = "lblPlayermaporigin";
            this.lblPlayermaporigin.Size = new System.Drawing.Size(86, 13);
            this.lblPlayermaporigin.TabIndex = 8;
            this.lblPlayermaporigin.Text = "origin player map";
            // 
            // playerMap1
            // 
            this.playerMap1.Location = new System.Drawing.Point(12, 12);
            this.playerMap1.Name = "playerMap1";
            this.playerMap1.Size = new System.Drawing.Size(420, 420);
            this.playerMap1.TabIndex = 7;
            this.playerMap1.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(607, 445);
            this.Controls.Add(this.lblPlayermaporigin);
            this.Controls.Add(this.playerMap1);
            this.Controls.Add(this.lblCoord);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveRight);
            this.Controls.Add(this.btnMoveLeft);
            this.Controls.Add(this.btnMovetop);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.playerMap1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMovetop;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Label lblCoord;
        private ClassGame.PlayerMap playerMap1;
        private System.Windows.Forms.Label lblPlayermaporigin;
    }
}

