namespace CSMS
{
    partial class Manager_ModifyCleaners
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager_ModifyCleaners));
            this.AssignedCleanersData = new System.Windows.Forms.DataGridView();
            this.AssignedCleaners = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CurrentlyAssignedLabel = new System.Windows.Forms.Label();
            this.AvailableCleanersLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.AvailableCleanersData = new System.Windows.Forms.DataGridView();
            this.AvailableCleaners = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddButtons = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.AssignedCleanersData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableCleanersData)).BeginInit();
            this.SuspendLayout();
            // 
            // AssignedCleanersData
            // 
            this.AssignedCleanersData.AllowUserToAddRows = false;
            this.AssignedCleanersData.AllowUserToDeleteRows = false;
            this.AssignedCleanersData.AllowUserToResizeColumns = false;
            this.AssignedCleanersData.AllowUserToResizeRows = false;
            this.AssignedCleanersData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AssignedCleanersData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.AssignedCleanersData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AssignedCleanersData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AssignedCleaners,
            this.DelButton});
            this.AssignedCleanersData.Location = new System.Drawing.Point(38, 58);
            this.AssignedCleanersData.Name = "AssignedCleanersData";
            this.AssignedCleanersData.ReadOnly = true;
            this.AssignedCleanersData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AssignedCleanersData.RowTemplate.Height = 25;
            this.AssignedCleanersData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AssignedCleanersData.ShowEditingIcon = false;
            this.AssignedCleanersData.Size = new System.Drawing.Size(339, 362);
            this.AssignedCleanersData.TabIndex = 0;
            this.AssignedCleanersData.TabStop = false;
            // 
            // AssignedCleaners
            // 
            this.AssignedCleaners.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AssignedCleaners.HeaderText = "Cleaners";
            this.AssignedCleaners.Name = "AssignedCleaners";
            this.AssignedCleaners.ReadOnly = true;
            this.AssignedCleaners.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AssignedCleaners.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DelButton
            // 
            this.DelButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DelButton.HeaderText = "";
            this.DelButton.MinimumWidth = 20;
            this.DelButton.Name = "DelButton";
            this.DelButton.ReadOnly = true;
            this.DelButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DelButton.Text = "-";
            this.DelButton.UseColumnTextForButtonValue = true;
            this.DelButton.Width = 20;
            // 
            // CurrentlyAssignedLabel
            // 
            this.CurrentlyAssignedLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CurrentlyAssignedLabel.AutoSize = true;
            this.CurrentlyAssignedLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CurrentlyAssignedLabel.Location = new System.Drawing.Point(69, 18);
            this.CurrentlyAssignedLabel.Name = "CurrentlyAssignedLabel";
            this.CurrentlyAssignedLabel.Size = new System.Drawing.Size(277, 28);
            this.CurrentlyAssignedLabel.TabIndex = 2;
            this.CurrentlyAssignedLabel.Text = "Currently Assigned Cleaners";
            // 
            // AvailableCleanersLabel
            // 
            this.AvailableCleanersLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AvailableCleanersLabel.AutoSize = true;
            this.AvailableCleanersLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AvailableCleanersLabel.Location = new System.Drawing.Point(510, 18);
            this.AvailableCleanersLabel.Name = "AvailableCleanersLabel";
            this.AvailableCleanersLabel.Size = new System.Drawing.Size(186, 28);
            this.AvailableCleanersLabel.TabIndex = 3;
            this.AvailableCleanersLabel.Text = "Available Cleaners";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveButton.AutoSize = true;
            this.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(217)))), ((int)(((byte)(168)))));
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(156)))), ((int)(((byte)(140)))));
            this.SaveButton.FlatAppearance.BorderSize = 3;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.Location = new System.Drawing.Point(368, 438);
            this.SaveButton.MaximumSize = new System.Drawing.Size(520, 160);
            this.SaveButton.MinimumSize = new System.Drawing.Size(81, 36);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SaveButton.Size = new System.Drawing.Size(81, 36);
            this.SaveButton.TabIndex = 22;
            this.SaveButton.TabStop = false;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AvailableCleanersData
            // 
            this.AvailableCleanersData.AllowUserToAddRows = false;
            this.AvailableCleanersData.AllowUserToDeleteRows = false;
            this.AvailableCleanersData.AllowUserToResizeColumns = false;
            this.AvailableCleanersData.AllowUserToResizeRows = false;
            this.AvailableCleanersData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AvailableCleanersData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.AvailableCleanersData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvailableCleanersData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AvailableCleaners,
            this.AddButtons});
            this.AvailableCleanersData.Location = new System.Drawing.Point(433, 58);
            this.AvailableCleanersData.Name = "AvailableCleanersData";
            this.AvailableCleanersData.ReadOnly = true;
            this.AvailableCleanersData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AvailableCleanersData.RowTemplate.Height = 25;
            this.AvailableCleanersData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AvailableCleanersData.ShowEditingIcon = false;
            this.AvailableCleanersData.Size = new System.Drawing.Size(339, 362);
            this.AvailableCleanersData.TabIndex = 23;
            this.AvailableCleanersData.TabStop = false;
            this.AvailableCleanersData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvailableCleanersData_CellContentClick);
            // 
            // AvailableCleaners
            // 
            this.AvailableCleaners.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AvailableCleaners.HeaderText = "Cleaners";
            this.AvailableCleaners.Name = "AvailableCleaners";
            this.AvailableCleaners.ReadOnly = true;
            this.AvailableCleaners.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AvailableCleaners.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AddButtons
            // 
            this.AddButtons.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AddButtons.HeaderText = "";
            this.AddButtons.MinimumWidth = 20;
            this.AddButtons.Name = "AddButtons";
            this.AddButtons.ReadOnly = true;
            this.AddButtons.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AddButtons.Text = "+";
            this.AddButtons.UseColumnTextForButtonValue = true;
            this.AddButtons.Width = 20;
            // 
            // Manager_ModifyCleaners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(209)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(814, 486);
            this.Controls.Add(this.AvailableCleanersData);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AvailableCleanersLabel);
            this.Controls.Add(this.CurrentlyAssignedLabel);
            this.Controls.Add(this.AssignedCleanersData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(830, 525);
            this.Name = "Manager_ModifyCleaners";
            this.Text = "Cleaning Service Management System";
            this.Load += new System.EventHandler(this.Manager_ModifyCleaners_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AssignedCleanersData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableCleanersData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView AssignedCleanersData;
        private Label CurrentlyAssignedLabel;
        private Label AvailableCleanersLabel;
        private Button SaveButton;
        private DataGridViewTextBoxColumn AssignedCleaners;
        private DataGridViewButtonColumn DelButton;
        private DataGridView AvailableCleanersData;
        private DataGridViewTextBoxColumn AvailableCleaners;
        private DataGridViewButtonColumn AddButtons;
    }
}