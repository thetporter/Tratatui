namespace Tratatui
{
    partial class RecipesForm
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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Салаты и закуски", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Главные блюда", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Гарнир", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Десерты", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Напитки", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Прочее", System.Windows.Forms.HorizontalAlignment.Left);
            listView1 = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            DishName = new System.Windows.Forms.Label();
            DishDescription = new System.Windows.Forms.Label();
            DescTooltip = new System.Windows.Forms.ToolTip(components);
            RecipeBox = new System.Windows.Forms.ListBox();
            AddButton = new System.Windows.Forms.Button();
            EditButton = new System.Windows.Forms.Button();
            DeleteButton = new System.Windows.Forms.Button();
            NameTextbox = new System.Windows.Forms.TextBox();
            DescTextbox = new System.Windows.Forms.TextBox();
            RecipeTextbox = new System.Windows.Forms.TextBox();
            ConfirmButton = new System.Windows.Forms.Button();
            PriceBox = new System.Windows.Forms.MaskedTextBox();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewGroup1.Header = "Салаты и закуски";
            listViewGroup1.Name = "DishGroup1";
            listViewGroup2.Header = "Главные блюда";
            listViewGroup2.Name = "DishGroup2";
            listViewGroup3.Header = "Гарнир";
            listViewGroup3.Name = "DishGroup3";
            listViewGroup4.Header = "Десерты";
            listViewGroup4.Name = "DishGroup4";
            listViewGroup5.Header = "Напитки";
            listViewGroup5.Name = "DishGroup5";
            listViewGroup6.Header = "Прочее";
            listViewGroup6.Name = "DishGroup6";
            listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3, listViewGroup4, listViewGroup5 });
            listView1.Location = new System.Drawing.Point(12, 49);
            listView1.Name = "listView1";
            listView1.ShowItemToolTips = true;
            listView1.Size = new System.Drawing.Size(317, 389);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Название блюда";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Цена";
            columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            columnHeader2.Width = 114;
            // 
            // DishName
            // 
            DishName.AutoEllipsis = true;
            DishName.AutoSize = true;
            DishName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 204);
            DishName.Location = new System.Drawing.Point(335, 12);
            DishName.MaximumSize = new System.Drawing.Size(450, 28);
            DishName.Name = "DishName";
            DishName.Size = new System.Drawing.Size(164, 28);
            DishName.TabIndex = 1;
            DishName.Text = "Название блюда";
            // 
            // DishDescription
            // 
            DishDescription.AutoSize = true;
            DishDescription.Font = new System.Drawing.Font("Segoe UI", 11F);
            DishDescription.Location = new System.Drawing.Point(335, 49);
            DishDescription.MaximumSize = new System.Drawing.Size(450, 45);
            DishDescription.Name = "DishDescription";
            DishDescription.Size = new System.Drawing.Size(128, 20);
            DishDescription.TabIndex = 2;
            DishDescription.Text = "Описание блюда";
            DishDescription.MouseHover += DishDescription_MouseHover;
            // 
            // RecipeBox
            // 
            RecipeBox.FormattingEnabled = true;
            RecipeBox.HorizontalScrollbar = true;
            RecipeBox.ItemHeight = 15;
            RecipeBox.Items.AddRange(new object[] { "Рецепт блюда" });
            RecipeBox.Location = new System.Drawing.Point(335, 102);
            RecipeBox.Name = "RecipeBox";
            RecipeBox.ScrollAlwaysVisible = true;
            RecipeBox.Size = new System.Drawing.Size(453, 334);
            RecipeBox.TabIndex = 3;
            // 
            // AddButton
            // 
            AddButton.Location = new System.Drawing.Point(12, 12);
            AddButton.Name = "AddButton";
            AddButton.Size = new System.Drawing.Size(96, 23);
            AddButton.TabIndex = 4;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new System.Drawing.Point(129, 12);
            EditButton.Name = "EditButton";
            EditButton.Size = new System.Drawing.Size(91, 23);
            EditButton.TabIndex = 5;
            EditButton.Text = "Изменить";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new System.Drawing.Point(238, 12);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new System.Drawing.Size(91, 23);
            DeleteButton.TabIndex = 6;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // NameTextbox
            // 
            NameTextbox.Location = new System.Drawing.Point(335, 17);
            NameTextbox.Name = "NameTextbox";
            NameTextbox.PlaceholderText = "Название";
            NameTextbox.Size = new System.Drawing.Size(453, 23);
            NameTextbox.TabIndex = 7;
            NameTextbox.Visible = false;
            // 
            // DescTextbox
            // 
            DescTextbox.Location = new System.Drawing.Point(335, 46);
            DescTextbox.MaximumSize = new System.Drawing.Size(453, 50);
            DescTextbox.MaxLength = 256;
            DescTextbox.MinimumSize = new System.Drawing.Size(453, 50);
            DescTextbox.Name = "DescTextbox";
            DescTextbox.PlaceholderText = "Описание";
            DescTextbox.Size = new System.Drawing.Size(453, 50);
            DescTextbox.TabIndex = 8;
            DescTextbox.Visible = false;
            // 
            // RecipeTextbox
            // 
            RecipeTextbox.AcceptsReturn = true;
            RecipeTextbox.Location = new System.Drawing.Point(335, 102);
            RecipeTextbox.MaximumSize = new System.Drawing.Size(453, 289);
            RecipeTextbox.MinimumSize = new System.Drawing.Size(453, 289);
            RecipeTextbox.Multiline = true;
            RecipeTextbox.Name = "RecipeTextbox";
            RecipeTextbox.PlaceholderText = "Рецепт";
            RecipeTextbox.Size = new System.Drawing.Size(453, 289);
            RecipeTextbox.TabIndex = 9;
            RecipeTextbox.Visible = false;
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new System.Drawing.Point(653, 397);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new System.Drawing.Size(135, 39);
            ConfirmButton.TabIndex = 10;
            ConfirmButton.Text = "Подтвердить";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Visible = false;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // PriceBox
            // 
            PriceBox.Location = new System.Drawing.Point(379, 406);
            PriceBox.Mask = "1111,11";
            PriceBox.Name = "PriceBox";
            PriceBox.Size = new System.Drawing.Size(268, 23);
            PriceBox.TabIndex = 11;
            PriceBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            PriceBox.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(335, 409);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 15);
            label1.TabIndex = 12;
            label1.Text = "Цена:";
            label1.Visible = false;
            // 
            // RecipesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(label1);
            Controls.Add(PriceBox);
            Controls.Add(ConfirmButton);
            Controls.Add(RecipeTextbox);
            Controls.Add(DescTextbox);
            Controls.Add(NameTextbox);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(RecipeBox);
            Controls.Add(DishDescription);
            Controls.Add(DishName);
            Controls.Add(listView1);
            Name = "RecipesForm";
            Text = "RecipesForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public System.Windows.Forms.Label DishName;
        public System.Windows.Forms.Label DishDescription;
        private System.Windows.Forms.ToolTip DescTooltip;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ListBox RecipeBox;
        public System.Windows.Forms.Button AddButton;
        public System.Windows.Forms.Button EditButton;
        public System.Windows.Forms.Button DeleteButton;
        public System.Windows.Forms.TextBox NameTextbox;
        public System.Windows.Forms.TextBox DescTextbox;
        public System.Windows.Forms.TextBox RecipeTextbox;
        public System.Windows.Forms.Button ConfirmButton;
        public System.Windows.Forms.MaskedTextBox PriceBox;
        public System.Windows.Forms.Label label1;
    }
}