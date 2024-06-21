
namespace Tratatui
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            LoginAsGuest = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            StaffCodeField = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            PasswordField = new System.Windows.Forms.TextBox();
            LoginAsStaff = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // LoginAsGuest
            // 
            LoginAsGuest.Location = new System.Drawing.Point(14, 14);
            LoginAsGuest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            LoginAsGuest.Name = "LoginAsGuest";
            LoginAsGuest.Size = new System.Drawing.Size(461, 27);
            LoginAsGuest.TabIndex = 0;
            LoginAsGuest.Text = "Войти как посетитель";
            LoginAsGuest.UseVisualStyleBackColor = true;
            LoginAsGuest.Click += LoginAsGuest_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(238, 44);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(28, 15);
            label1.TabIndex = 1;
            label1.Text = "или";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StaffCodeField
            // 
            StaffCodeField.Location = new System.Drawing.Point(122, 67);
            StaffCodeField.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            StaffCodeField.Name = "StaffCodeField";
            StaffCodeField.Size = new System.Drawing.Size(352, 23);
            StaffCodeField.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(14, 70);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(93, 15);
            label2.TabIndex = 3;
            label2.Text = "Код сотрудника";
            // 
            // PasswordField
            // 
            PasswordField.Location = new System.Drawing.Point(122, 98);
            PasswordField.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            PasswordField.Name = "PasswordField";
            PasswordField.Size = new System.Drawing.Size(352, 23);
            PasswordField.TabIndex = 4;
            PasswordField.UseSystemPasswordChar = true;
            // 
            // LoginAsStaff
            // 
            LoginAsStaff.Location = new System.Drawing.Point(14, 129);
            LoginAsStaff.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            LoginAsStaff.Name = "LoginAsStaff";
            LoginAsStaff.Size = new System.Drawing.Size(460, 27);
            LoginAsStaff.TabIndex = 5;
            LoginAsStaff.Text = "Войти как сотрудник";
            LoginAsStaff.UseVisualStyleBackColor = true;
            LoginAsStaff.Click += LoginAsStaff_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(14, 102);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 15);
            label3.TabIndex = 6;
            label3.Text = "Пароль";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(489, 171);
            Controls.Add(label3);
            Controls.Add(LoginAsStaff);
            Controls.Add(PasswordField);
            Controls.Add(label2);
            Controls.Add(StaffCodeField);
            Controls.Add(label1);
            Controls.Add(LoginAsGuest);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "LoginForm";
            Text = "Трататуй - Ресторан, который тратит все деньги";
            FormClosing += LoginForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button LoginAsGuest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StaffCodeField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.Button LoginAsStaff;
        private System.Windows.Forms.Label label3;
    }
}

