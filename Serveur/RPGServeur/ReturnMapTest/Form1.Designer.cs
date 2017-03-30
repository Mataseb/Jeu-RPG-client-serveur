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
            this.playerMap1 = new ReturnMapTest.ClassGame.PlayerMap();
            ((System.ComponentModel.ISupportInitialize)(this.playerMap1)).BeginInit();
            this.SuspendLayout();
            // 
            // playerMap1
            // 
            this.playerMap1.Location = new System.Drawing.Point(3, 5);
            this.playerMap1.Name = "playerMap1";
            this.playerMap1.Size = new System.Drawing.Size(630, 630);
            this.playerMap1.TabIndex = 0;
            this.playerMap1.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(638, 639);
            this.Controls.Add(this.playerMap1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.playerMap1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassGame.PlayerMap playerMap1;
    }
}

