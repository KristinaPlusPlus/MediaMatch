namespace MediaMatch
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.artEntry = new System.Windows.Forms.TextBox();
            this.matchButton = new System.Windows.Forms.Button();
            this.movieOutput = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // artEntry
            // 
            this.artEntry.Location = new System.Drawing.Point(222, 89);
            this.artEntry.Name = "artEntry";
            this.artEntry.Size = new System.Drawing.Size(190, 20);
            this.artEntry.TabIndex = 0;
            this.artEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputText_KeyDown);
            // 
            // matchButton
            // 
            this.matchButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.matchButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.matchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.matchButton.Location = new System.Drawing.Point(259, 151);
            this.matchButton.Name = "matchButton";
            this.matchButton.Size = new System.Drawing.Size(116, 57);
            this.matchButton.TabIndex = 1;
            this.matchButton.Text = "Match";
            this.matchButton.UseVisualStyleBackColor = false;
            this.matchButton.Click += new System.EventHandler(this.matchButton_Click);
            // 
            // movieOutput
            // 
            this.movieOutput.AutoSize = true;
            this.movieOutput.Location = new System.Drawing.Point(249, 233);
            this.movieOutput.Name = "movieOutput";
            this.movieOutput.Size = new System.Drawing.Size(0, 13);
            this.movieOutput.TabIndex = 2;
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(140, 39);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(355, 31);
            this.Description.TabIndex = 3;
            this.Description.Text = "Enter an artist name and we will reccommend movies based on your taste! (Example:" +
    " The Who, Pink Floyd, Ludwig Van Beethoven)";
            this.Description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Description.Click += new System.EventHandler(this.Description_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 423);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.movieOutput);
            this.Controls.Add(this.matchButton);
            this.Controls.Add(this.artEntry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Media Match";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox artEntry;
        private System.Windows.Forms.Button matchButton;
        private System.Windows.Forms.Label movieOutput;
        private System.Windows.Forms.Label Description;
    }
}

