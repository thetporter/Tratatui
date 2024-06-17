
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
            this.LoginAsGuest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.StaffCodeField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LoginAsStaff = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginAsGuest
            // 
            this.LoginAsGuest.Location = new System.Drawing.Point(12, 12);
            this.LoginAsGuest.Name = "LoginAsGuest";
            this.LoginAsGuest.Size = new System.Drawing.Size(395, 23);
            this.LoginAsGuest.TabIndex = 0;
            this.LoginAsGuest.Text = "Войти как посетитель";
            this.LoginAsGuest.UseVisualStyleBackColor = true;
            this.LoginAsGuest.Click += new System.EventHandler(this.LoginAsGuest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "или";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StaffCodeField
            // 
            this.StaffCodeField.Location = new System.Drawing.Point(105, 58);
            this.StaffCodeField.Name = "StaffCodeField";
            this.StaffCodeField.Size = new System.Drawing.Size(302, 20);
            this.StaffCodeField.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Код сотрудника";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(302, 20);
            this.textBox1.TabIndex = 4;
            // 
            // LoginAsStaff
            // 
            this.LoginAsStaff.Location = new System.Drawing.Point(12, 112);
            this.LoginAsStaff.Name = "LoginAsStaff";
            this.LoginAsStaff.Size = new System.Drawing.Size(394, 23);
            this.LoginAsStaff.TabIndex = 5;
            this.LoginAsStaff.Text = "Войти как сотрудник";
            this.LoginAsStaff.UseVisualStyleBackColor = true;
            this.LoginAsStaff.Click += new System.EventHandler(this.LoginAsStaff_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Пароль";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 148);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LoginAsStaff);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StaffCodeField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginAsGuest);
            this.Name = "LoginForm";
            this.Text = "Трататуй - Ресторан, который тратит все деньги";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginAsGuest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StaffCodeField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button LoginAsStaff;
        private System.Windows.Forms.Label label3;
    }
}

