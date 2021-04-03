namespace UoB.TD
{
    partial class TDDataEntry
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
            this.btnMDCreate = new System.Windows.Forms.Button();
            this.btnMDEdit = new System.Windows.Forms.Button();
            this.btnTDEntry = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDeleteDAta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMDCreate
            // 
            this.btnMDCreate.Location = new System.Drawing.Point(12, 12);
            this.btnMDCreate.Name = "btnMDCreate";
            this.btnMDCreate.Size = new System.Drawing.Size(108, 30);
            this.btnMDCreate.TabIndex = 2;
            this.btnMDCreate.Text = "Create Master DB";
            this.btnMDCreate.UseVisualStyleBackColor = true;
            this.btnMDCreate.Click += new System.EventHandler(this.btnMDCreate_Click);
            // 
            // btnMDEdit
            // 
            this.btnMDEdit.Location = new System.Drawing.Point(126, 12);
            this.btnMDEdit.Name = "btnMDEdit";
            this.btnMDEdit.Size = new System.Drawing.Size(97, 30);
            this.btnMDEdit.TabIndex = 1;
            this.btnMDEdit.Text = "Edit Master Data";
            this.btnMDEdit.UseVisualStyleBackColor = true;
            // 
            // btnTDEntry
            // 
            this.btnTDEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTDEntry.Location = new System.Drawing.Point(274, 85);
            this.btnTDEntry.Name = "btnTDEntry";
            this.btnTDEntry.Size = new System.Drawing.Size(243, 46);
            this.btnTDEntry.TabIndex = 0;
            this.btnTDEntry.Text = "Enter Training Data";
            this.btnTDEntry.UseVisualStyleBackColor = true;
            this.btnTDEntry.Click += new System.EventHandler(this.btnTDEntry_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(680, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 30);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDeleteDAta
            // 
            this.btnDeleteDAta.Location = new System.Drawing.Point(126, 12);
            this.btnDeleteDAta.Name = "btnDeleteDAta";
            this.btnDeleteDAta.Size = new System.Drawing.Size(108, 30);
            this.btnDeleteDAta.TabIndex = 3;
            this.btnDeleteDAta.Text = "Delete Master DB";
            this.btnDeleteDAta.UseVisualStyleBackColor = true;
            this.btnDeleteDAta.Click += new System.EventHandler(this.btnDeleteDAta_Click);
            // 
            // TDDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnDeleteDAta);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTDEntry);
            this.Controls.Add(this.btnMDEdit);
            this.Controls.Add(this.btnMDCreate);
            this.Name = "TDDataEntry";
            this.Text = "Training Data Entry Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMDCreate;
        private System.Windows.Forms.Button btnMDEdit;
        private System.Windows.Forms.Button btnTDEntry;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDeleteDAta;
    }
}