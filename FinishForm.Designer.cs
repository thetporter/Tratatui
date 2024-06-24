namespace Tratatui
{
    partial class FinishForm
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
            FinishButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // FinishButton
            // 
            FinishButton.Location = new System.Drawing.Point(12, 36);
            FinishButton.Name = "FinishButton";
            FinishButton.Size = new System.Drawing.Size(183, 48);
            FinishButton.TabIndex = 0;
            FinishButton.Text = "Оплатить и выйти";
            FinishButton.UseVisualStyleBackColor = true;
            FinishButton.Click += FinishButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(42, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(122, 15);
            label1.TabIndex = 1;
            label1.Text = "Приятного аппетита!";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FinishForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(207, 94);
            Controls.Add(label1);
            Controls.Add(FinishButton);
            Name = "FinishForm";
            Text = "FinishForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button FinishButton;
        private System.Windows.Forms.Label label1;
    }
}