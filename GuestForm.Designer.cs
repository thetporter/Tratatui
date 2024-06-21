
using System.Windows.Forms;

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
            label1 = new System.Windows.Forms.Label();
            OrderButton = new System.Windows.Forms.Button();
            TotalCostLabel = new System.Windows.Forms.Label();
            MenuItem = new System.Windows.Forms.ListView();
            System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("Салаты и закуски", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("Главные блюда", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup18 = new System.Windows.Forms.ListViewGroup("Гарнир", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup19 = new System.Windows.Forms.ListViewGroup("Десерты", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup20 = new System.Windows.Forms.ListViewGroup("Напитки", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup21 = new System.Windows.Forms.ListViewGroup("Прочее", System.Windows.Forms.HorizontalAlignment.Left);
            NameColumn = new System.Windows.Forms.ColumnHeader();
            DescriptionColumn = new System.Windows.Forms.ColumnHeader();
            CostColumn = new System.Windows.Forms.ColumnHeader();
            AmountColumn = new System.Windows.Forms.ColumnHeader();
            amtSelector = new System.Windows.Forms.NumericUpDown();
            OrderList = new System.Windows.Forms.ListView();
            NameColumn0 = new System.Windows.Forms.ColumnHeader();
            AmountColumn0 = new System.Windows.Forms.ColumnHeader();
            TotalColumn = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)amtSelector).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(950, 423);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(90, 15);
            label1.TabIndex = 1;
            label1.Text = "Итоговая цена:";
            // 
            // OrderButton
            // 
            OrderButton.Location = new System.Drawing.Point(950, 450);
            OrderButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            OrderButton.Name = "OrderButton";
            OrderButton.Size = new System.Drawing.Size(327, 48);
            OrderButton.TabIndex = 2;
            OrderButton.Text = "Подтвердить заказ";
            OrderButton.UseVisualStyleBackColor = true;
            OrderButton.Click += OrderButton_Click;
            // 
            // TotalCostLabel
            // 
            TotalCostLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            TotalCostLabel.AutoSize = true;
            TotalCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            TotalCostLabel.Location = new System.Drawing.Point(1160, 418);
            TotalCostLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            TotalCostLabel.MinimumSize = new System.Drawing.Size(117, 0);
            TotalCostLabel.Name = "TotalCostLabel";
            TotalCostLabel.Size = new System.Drawing.Size(117, 20);
            TotalCostLabel.TabIndex = 3;
            TotalCostLabel.Text = "0,0";
            TotalCostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MenuItem
            // 
            MenuItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { NameColumn, DescriptionColumn, CostColumn, AmountColumn });
            listViewGroup16.Header = "Салаты и закуски";
            listViewGroup16.Name = "DishGroup1";
            listViewGroup17.Header = "Главные блюда";
            listViewGroup17.Name = "DishGroup2";
            listViewGroup18.Header = "Гарнир";
            listViewGroup18.Name = "DishGroup3";
            listViewGroup19.Header = "Десерты";
            listViewGroup19.Name = "DishGroup4";
            listViewGroup20.Header = "Напитки";
            listViewGroup20.Name = "DishGroup5";
            listViewGroup21.Header = "Прочее";
            listViewGroup21.Name = "DishGroup6";
            MenuItem.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup16, listViewGroup17, listViewGroup18, listViewGroup19, listViewGroup20 });
            MenuItem.FullRowSelect = true;
            MenuItem.GridLines = true;
            MenuItem.Location = new System.Drawing.Point(12, 12);
            MenuItem.MultiSelect = false;
            MenuItem.Name = "MenuItem";
            MenuItem.Size = new System.Drawing.Size(931, 486);
            MenuItem.TabIndex = 5;
            MenuItem.UseCompatibleStateImageBehavior = false;
            MenuItem.View = System.Windows.Forms.View.Details;
            MenuItem.SelectedIndexChanged += MenuItem_SelectedIndexChanged;
            // 
            // NameColumn
            // 
            NameColumn.Text = "Блюдо";
            NameColumn.Width = 250;
            // 
            // DescriptionColumn
            // 
            DescriptionColumn.Text = "Описание";
            DescriptionColumn.Width = 530;
            // 
            // CostColumn
            // 
            CostColumn.Text = "Цена";
            CostColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            CostColumn.Width = 75;
            // 
            // AmountColumn
            // 
            AmountColumn.Text = "Кол-во";
            AmountColumn.Width = 74;
            // 
            // amtSelector
            // 
            amtSelector.Location = new System.Drawing.Point(869, 54);
            amtSelector.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            amtSelector.Name = "amtSelector";
            amtSelector.Size = new System.Drawing.Size(75, 23);
            amtSelector.TabIndex = 6;
            amtSelector.Visible = false;
            amtSelector.ValueChanged += amtSelector_ValueChanged;
            // 
            // OrderList
            // 
            OrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { NameColumn0, AmountColumn0, TotalColumn });
            OrderList.FullRowSelect = true;
            OrderList.GridLines = true;
            OrderList.Location = new System.Drawing.Point(950, 12);
            OrderList.MultiSelect = false;
            OrderList.Name = "OrderList";
            OrderList.Size = new System.Drawing.Size(328, 399);
            OrderList.TabIndex = 7;
            OrderList.UseCompatibleStateImageBehavior = false;
            OrderList.View = System.Windows.Forms.View.Details;
            // 
            // NameColumn0
            // 
            NameColumn0.Text = "Блюдо";
            NameColumn0.Width = 175;
            // 
            // AmountColumn0
            // 
            AmountColumn0.Text = "Кол-во";
            AmountColumn0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            AmountColumn0.Width = 75;
            // 
            // TotalColumn
            // 
            TotalColumn.Text = "Сумма";
            TotalColumn.Width = 74;
            // 
            // GuestForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1290, 510);
            Controls.Add(OrderList);
            Controls.Add(amtSelector);
            Controls.Add(MenuItem);
            Controls.Add(TotalCostLabel);
            Controls.Add(OrderButton);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "GuestForm";
            Text = "Трататуй - Меню";
            FormClosed += GuestForm_FormClosed;
            Load += GuestForm_Load;
            ((System.ComponentModel.ISupportInitialize)amtSelector).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OrderButton;
        private System.Windows.Forms.Label TotalCostLabel;
        private System.Windows.Forms.ListView MenuItem;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader DescriptionColumn;
        private System.Windows.Forms.ColumnHeader CostColumn;
        private System.Windows.Forms.ColumnHeader AmountColumn;
        private System.Windows.Forms.NumericUpDown amtSelector;
        private System.Windows.Forms.ListView OrderList;
        private System.Windows.Forms.ColumnHeader NameColumn0;
        private System.Windows.Forms.ColumnHeader AmountColumn0;
        private System.Windows.Forms.ColumnHeader TotalColumn;
    }
}