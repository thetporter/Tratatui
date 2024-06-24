namespace Tratatui
{
    partial class WaitingForm
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            WaiterLabel = new System.Windows.Forms.Label();
            StateLabel = new System.Windows.Forms.Label();
            NumberLabel = new System.Windows.Forms.Label();
            EditOrderButton = new System.Windows.Forms.Button();
            CancelOrderButton = new System.Windows.Forms.Button();
            CallWaiterButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(129, 15);
            label1.TabIndex = 0;
            label1.Text = "Номер вашего заказа:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 35);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(150, 15);
            label2.TabIndex = 1;
            label2.Text = "Состояние вашего заказа:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 61);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(144, 15);
            label3.TabIndex = 2;
            label3.Text = "Вас обслужит официант:";
            // 
            // WaiterLabel
            // 
            WaiterLabel.AutoSize = true;
            WaiterLabel.Location = new System.Drawing.Point(250, 61);
            WaiterLabel.Name = "WaiterLabel";
            WaiterLabel.Size = new System.Drawing.Size(82, 15);
            WaiterLabel.TabIndex = 3;
            WaiterLabel.Text = "(не назначен)";
            WaiterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StateLabel
            // 
            StateLabel.AutoSize = true;
            StateLabel.Location = new System.Drawing.Point(231, 35);
            StateLabel.Name = "StateLabel";
            StateLabel.Size = new System.Drawing.Size(101, 15);
            StateLabel.TabIndex = 4;
            StateLabel.Text = "Только поступил";
            StateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumberLabel
            // 
            NumberLabel.AutoSize = true;
            NumberLabel.Location = new System.Drawing.Point(301, 9);
            NumberLabel.Name = "NumberLabel";
            NumberLabel.Size = new System.Drawing.Size(31, 15);
            NumberLabel.TabIndex = 5;
            NumberLabel.Text = "0069";
            NumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditOrderButton
            // 
            EditOrderButton.Location = new System.Drawing.Point(12, 90);
            EditOrderButton.Name = "EditOrderButton";
            EditOrderButton.Size = new System.Drawing.Size(323, 23);
            EditOrderButton.TabIndex = 6;
            EditOrderButton.Text = "Изменить заказ";
            EditOrderButton.UseVisualStyleBackColor = true;
            EditOrderButton.Click += EditOrderButton_Click;
            // 
            // CancelOrderButton
            // 
            CancelOrderButton.Location = new System.Drawing.Point(12, 119);
            CancelOrderButton.Name = "CancelOrderButton";
            CancelOrderButton.Size = new System.Drawing.Size(323, 23);
            CancelOrderButton.TabIndex = 7;
            CancelOrderButton.Text = "Отменить заказ";
            CancelOrderButton.UseVisualStyleBackColor = true;
            CancelOrderButton.Click += CancelOrderButton_Click;
            // 
            // CallWaiterButton
            // 
            CallWaiterButton.Location = new System.Drawing.Point(12, 148);
            CallWaiterButton.Name = "CallWaiterButton";
            CallWaiterButton.Size = new System.Drawing.Size(323, 23);
            CallWaiterButton.TabIndex = 8;
            CallWaiterButton.Text = "Позвать официанта";
            CallWaiterButton.UseVisualStyleBackColor = true;
            CallWaiterButton.Click += CallWaiterButton_Click;
            // 
            // WaitingForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(347, 180);
            Controls.Add(CallWaiterButton);
            Controls.Add(CancelOrderButton);
            Controls.Add(EditOrderButton);
            Controls.Add(NumberLabel);
            Controls.Add(StateLabel);
            Controls.Add(WaiterLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "WaitingForm";
            Text = "WaitingForm";
            Load += WaitingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label WaiterLabel;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.Button EditOrderButton;
        private System.Windows.Forms.Button CancelOrderButton;
        private System.Windows.Forms.Button CallWaiterButton;
        public System.Windows.Forms.Label NumberLabel;
    }
}