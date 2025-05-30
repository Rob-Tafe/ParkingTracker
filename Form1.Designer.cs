namespace ParkingTracker
{
    partial class ParkingTracker
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
            this.components = new System.ComponentModel.Container();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TbInput = new System.Windows.Forms.TextBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnBinary = new System.Windows.Forms.Button();
            this.BtnLinear = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.LbMain = new System.Windows.Forms.ListBox();
            this.LbTagged = new System.Windows.Forms.ListBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnTag = new System.Windows.Forms.Button();
            this.TbFeedback = new System.Windows.Forms.TextBox();
            this.LabelTagged = new System.Windows.Forms.Label();
            this.LabelMain = new System.Windows.Forms.Label();
            this.LabelFeedback = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LabelInput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(20, 20);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(60, 35);
            this.BtnOpen.TabIndex = 0;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(100, 20);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(60, 35);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TbInput
            // 
            this.TbInput.Location = new System.Drawing.Point(20, 85);
            this.TbInput.Name = "TbInput";
            this.TbInput.Size = new System.Drawing.Size(140, 20);
            this.TbInput.TabIndex = 2;
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(220, 20);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(60, 35);
            this.BtnReset.TabIndex = 3;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            // 
            // BtnBinary
            // 
            this.BtnBinary.Location = new System.Drawing.Point(20, 115);
            this.BtnBinary.Name = "BtnBinary";
            this.BtnBinary.Size = new System.Drawing.Size(60, 35);
            this.BtnBinary.TabIndex = 4;
            this.BtnBinary.Text = "Binary Search";
            this.BtnBinary.UseVisualStyleBackColor = true;
            this.BtnBinary.Click += new System.EventHandler(this.BtnBinary_Click);
            // 
            // BtnLinear
            // 
            this.BtnLinear.Location = new System.Drawing.Point(20, 160);
            this.BtnLinear.Name = "BtnLinear";
            this.BtnLinear.Size = new System.Drawing.Size(60, 35);
            this.BtnLinear.TabIndex = 5;
            this.BtnLinear.Text = "Linear Search";
            this.BtnLinear.UseVisualStyleBackColor = true;
            this.BtnLinear.Click += new System.EventHandler(this.BtnLinear_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(100, 115);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(60, 35);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(100, 160);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(60, 35);
            this.BtnEdit.TabIndex = 7;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = true;
            // 
            // LbMain
            // 
            this.LbMain.FormattingEnabled = true;
            this.LbMain.Location = new System.Drawing.Point(180, 85);
            this.LbMain.Name = "LbMain";
            this.LbMain.Size = new System.Drawing.Size(100, 264);
            this.LbMain.TabIndex = 8;
            // 
            // LbTagged
            // 
            this.LbTagged.FormattingEnabled = true;
            this.LbTagged.Location = new System.Drawing.Point(380, 85);
            this.LbTagged.Name = "LbTagged";
            this.LbTagged.Size = new System.Drawing.Size(100, 264);
            this.LbTagged.TabIndex = 9;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(100, 250);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(60, 35);
            this.BtnDelete.TabIndex = 10;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // BtnTag
            // 
            this.BtnTag.Location = new System.Drawing.Point(300, 85);
            this.BtnTag.Name = "BtnTag";
            this.BtnTag.Size = new System.Drawing.Size(60, 35);
            this.BtnTag.TabIndex = 11;
            this.BtnTag.Text = "Tag";
            this.toolTip1.SetToolTip(this.BtnTag, "Select a Licence number from the\r\n\'Main\' list and click the \"Tag\" button\r\nto add " +
        "it to the \"Tagged\" list.\r\n");
            this.BtnTag.UseVisualStyleBackColor = true;
            // 
            // TbFeedback
            // 
            this.TbFeedback.Location = new System.Drawing.Point(20, 373);
            this.TbFeedback.Name = "TbFeedback";
            this.TbFeedback.ReadOnly = true;
            this.TbFeedback.Size = new System.Drawing.Size(460, 20);
            this.TbFeedback.TabIndex = 12;
            // 
            // LabelTagged
            // 
            this.LabelTagged.AutoSize = true;
            this.LabelTagged.Location = new System.Drawing.Point(380, 70);
            this.LabelTagged.Name = "LabelTagged";
            this.LabelTagged.Size = new System.Drawing.Size(44, 13);
            this.LabelTagged.TabIndex = 13;
            this.LabelTagged.Text = "Tagged";
            // 
            // LabelMain
            // 
            this.LabelMain.AutoSize = true;
            this.LabelMain.Location = new System.Drawing.Point(180, 70);
            this.LabelMain.Name = "LabelMain";
            this.LabelMain.Size = new System.Drawing.Size(30, 13);
            this.LabelMain.TabIndex = 14;
            this.LabelMain.Text = "Main";
            // 
            // LabelFeedback
            // 
            this.LabelFeedback.AutoSize = true;
            this.LabelFeedback.Location = new System.Drawing.Point(20, 358);
            this.LabelFeedback.Name = "LabelFeedback";
            this.LabelFeedback.Size = new System.Drawing.Size(55, 13);
            this.LabelFeedback.TabIndex = 15;
            this.LabelFeedback.Text = "Feedback";
            // 
            // LabelInput
            // 
            this.LabelInput.AutoSize = true;
            this.LabelInput.Location = new System.Drawing.Point(20, 70);
            this.LabelInput.Name = "LabelInput";
            this.LabelInput.Size = new System.Drawing.Size(31, 13);
            this.LabelInput.TabIndex = 16;
            this.LabelInput.Text = "Input";
            // 
            // ParkingTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 411);
            this.Controls.Add(this.LabelInput);
            this.Controls.Add(this.LabelFeedback);
            this.Controls.Add(this.LabelMain);
            this.Controls.Add(this.LabelTagged);
            this.Controls.Add(this.TbFeedback);
            this.Controls.Add(this.BtnTag);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.LbTagged);
            this.Controls.Add(this.LbMain);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnLinear);
            this.Controls.Add(this.BtnBinary);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.TbInput);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnOpen);
            this.Name = "ParkingTracker";
            this.Text = "Parking Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TbInput;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnBinary;
        private System.Windows.Forms.Button BtnLinear;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.ListBox LbMain;
        private System.Windows.Forms.ListBox LbTagged;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnTag;
        private System.Windows.Forms.TextBox TbFeedback;
        private System.Windows.Forms.Label LabelTagged;
        private System.Windows.Forms.Label LabelMain;
        private System.Windows.Forms.Label LabelFeedback;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label LabelInput;
    }
}

