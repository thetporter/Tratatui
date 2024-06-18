
namespace Tratatui
{
    partial class GuestForm
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
            this.MenuItems = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OrderButton = new System.Windows.Forms.Button();
            this.TotalCostLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MenuItems
            // 
            this.MenuItems.FormattingEnabled = true;
            this.MenuItems.Location = new System.Drawing.Point(13, 13);
            this.MenuItems.MultiColumn = true;
            this.MenuItems.Name = "MenuItems";
            this.MenuItems.ScrollAlwaysVisible = false;
            this.MenuItems.Size = new System.Drawing.Size(556, 420);
            this.MenuItems.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(597, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Итоговая цена:";
            // 
            // OrderButton
            // 
            this.OrderButton.Location = new System.Drawing.Point(576, 390);
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(212, 42);
            this.OrderButton.TabIndex = 2;
            this.OrderButton.Text = "Подтвердить заказ";
            this.OrderButton.UseVisualStyleBackColor = true;
            this.OrderButton.Click += new System.EventHandler(this.OrderButton_Click);
            // 
            // TotalCostLabel
            // 
            this.TotalCostLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalCostLabel.AutoSize = true;
            this.TotalCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalCostLabel.Location = new System.Drawing.Point(688, 354);
            this.TotalCostLabel.MinimumSize = new System.Drawing.Size(100, 0);
            this.TotalCostLabel.Name = "TotalCostLabel";
            this.TotalCostLabel.Size = new System.Drawing.Size(100, 20);
            this.TotalCostLabel.TabIndex = 3;
            this.TotalCostLabel.Text = "0,0";
            this.TotalCostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(588, 13);
            this.label2.MinimumSize = new System.Drawing.Size(200, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Итого:";
            // 
            // GuestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TotalCostLabel);
            this.Controls.Add(this.OrderButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MenuItems);
            this.Name = "GuestForm";
            this.Text = "Трататуй - Меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MenuItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OrderButton;
        private System.Windows.Forms.Label TotalCostLabel;
        private System.Windows.Forms.Label label2;
    }
}