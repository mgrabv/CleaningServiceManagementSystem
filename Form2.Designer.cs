namespace CSMS
{
    partial class Manager_Orders
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager_Orders));
            this.OrdersView = new System.Windows.Forms.DataGridView();
            this.OrderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailsColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ConfirmedButton = new System.Windows.Forms.Button();
            this.IncomingButton = new System.Windows.Forms.Button();
            this.OrdersLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdersView
            // 
            this.OrdersView.AllowUserToAddRows = false;
            this.OrdersView.AllowUserToDeleteRows = false;
            this.OrdersView.AllowUserToResizeColumns = false;
            this.OrdersView.AllowUserToResizeRows = false;
            this.OrdersView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OrdersView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.OrdersView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.OrdersView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderColumn,
            this.DetailsColumn});
            this.OrdersView.Location = new System.Drawing.Point(63, 106);
            this.OrdersView.Name = "OrdersView";
            this.OrdersView.ReadOnly = true;
            this.OrdersView.RowTemplate.Height = 25;
            this.OrdersView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OrdersView.ShowEditingIcon = false;
            this.OrdersView.Size = new System.Drawing.Size(689, 332);
            this.OrdersView.TabIndex = 0;
            this.OrdersView.TabStop = false;
            this.OrdersView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrdersView_CellContentClick);
            // 
            // OrderColumn
            // 
            this.OrderColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.OrderColumn.HeaderText = "Order";
            this.OrderColumn.Name = "OrderColumn";
            this.OrderColumn.ReadOnly = true;
            this.OrderColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OrderColumn.Width = 546;
            // 
            // DetailsColumn
            // 
            this.DetailsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DetailsColumn.HeaderText = "";
            this.DetailsColumn.Name = "DetailsColumn";
            this.DetailsColumn.ReadOnly = true;
            this.DetailsColumn.Text = "Details";
            this.DetailsColumn.UseColumnTextForButtonValue = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ConfirmedButton
            // 
            this.ConfirmedButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConfirmedButton.AutoSize = true;
            this.ConfirmedButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConfirmedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(236)))), ((int)(((byte)(151)))));
            this.ConfirmedButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ConfirmedButton.FlatAppearance.BorderSize = 2;
            this.ConfirmedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmedButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConfirmedButton.Location = new System.Drawing.Point(80, 70);
            this.ConfirmedButton.MaximumSize = new System.Drawing.Size(520, 160);
            this.ConfirmedButton.MinimumSize = new System.Drawing.Size(100, 30);
            this.ConfirmedButton.Name = "ConfirmedButton";
            this.ConfirmedButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ConfirmedButton.Size = new System.Drawing.Size(100, 30);
            this.ConfirmedButton.TabIndex = 2;
            this.ConfirmedButton.TabStop = false;
            this.ConfirmedButton.Text = "Confirmed";
            this.ConfirmedButton.UseVisualStyleBackColor = false;
            this.ConfirmedButton.Click += new System.EventHandler(this.ConfirmedButton_Click);
            // 
            // IncomingButton
            // 
            this.IncomingButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IncomingButton.AutoSize = true;
            this.IncomingButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.IncomingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(236)))), ((int)(((byte)(151)))));
            this.IncomingButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.IncomingButton.FlatAppearance.BorderSize = 2;
            this.IncomingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IncomingButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IncomingButton.Location = new System.Drawing.Point(186, 70);
            this.IncomingButton.MaximumSize = new System.Drawing.Size(520, 160);
            this.IncomingButton.MinimumSize = new System.Drawing.Size(100, 30);
            this.IncomingButton.Name = "IncomingButton";
            this.IncomingButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IncomingButton.Size = new System.Drawing.Size(100, 30);
            this.IncomingButton.TabIndex = 3;
            this.IncomingButton.TabStop = false;
            this.IncomingButton.Text = "Incoming";
            this.IncomingButton.UseVisualStyleBackColor = false;
            // 
            // OrdersLabel
            // 
            this.OrdersLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OrdersLabel.AutoSize = true;
            this.OrdersLabel.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OrdersLabel.Location = new System.Drawing.Point(332, 9);
            this.OrdersLabel.Name = "OrdersLabel";
            this.OrdersLabel.Size = new System.Drawing.Size(150, 54);
            this.OrdersLabel.TabIndex = 5;
            this.OrdersLabel.Text = "Orders";
            // 
            // Manager_Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(181)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(814, 486);
            this.Controls.Add(this.OrdersLabel);
            this.Controls.Add(this.IncomingButton);
            this.Controls.Add(this.ConfirmedButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.OrdersView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(830, 525);
            this.Name = "Manager_Orders";
            this.Text = "Cleaning Service Management System";
            this.Activated += new System.EventHandler(this.Manager_Orders_Activated);
            this.Deactivate += new System.EventHandler(this.Manager_Orders_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Manager_Orders_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView OrdersView;
        private PictureBox pictureBox1;
        private Button ConfirmedButton;
        private Button IncomingButton;
        private Label OrdersLabel;
        private DataGridViewTextBoxColumn OrderColumn;
        private DataGridViewButtonColumn DetailsColumn;
    }
}