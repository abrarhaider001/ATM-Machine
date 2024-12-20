namespace Atm_Machine
{
    partial class EnterCard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ucEnterCard1 = new ucEnterCard();
            SuspendLayout();
            // 
            // ucEnterCard1
            // 
            ucEnterCard1.Location = new Point(1, 0);
            ucEnterCard1.Name = "ucEnterCard1";
            ucEnterCard1.Size = new Size(895, 679);
            ucEnterCard1.TabIndex = 0;
            // 
            // EnterCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 676);
            Controls.Add(ucEnterCard1);
            Name = "EnterCard";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private ucEnterCard ucEnterCard1;
    }
}