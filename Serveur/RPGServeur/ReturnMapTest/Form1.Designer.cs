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
            this.playerMap3 = new ReturnMapTest.ClassGame.PlayerMap();
            ((System.ComponentModel.ISupportInitialize)(this.playerMap3)).BeginInit();
            this.SuspendLayout();
            // 
            // playerMap3
            // 
            this.playerMap3.Location = new System.Drawing.Point(13, 13);
            this.playerMap3.Name = "playerMap3";
            this.playerMap3.Size = new System.Drawing.Size(433, 431);
            this.playerMap3.TabIndex = 0;
            this.playerMap3.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(564, 527);
            this.Controls.Add(this.playerMap3);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.playerMap3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassGame.PlayerMap playerMap1;
        private ClassGame.PlayerMap playerMap2;
        private ClassGame.PlayerMap playerMap3;
    }
}

