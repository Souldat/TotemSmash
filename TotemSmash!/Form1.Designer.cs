namespace TotemSmash_
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
            this.btnRecord = new System.Windows.Forms.Button();
            this.txtOut = new System.Windows.Forms.RichTextBox();
            this.btnStopRecord = new System.Windows.Forms.Button();
            this.NewMacro = new System.Windows.Forms.Button();
            this.macroListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(361, 54);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(114, 23);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(179, 12);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(176, 420);
            this.txtOut.TabIndex = 1;
            this.txtOut.Text = "";
            // 
            // btnStopRecord
            // 
            this.btnStopRecord.Location = new System.Drawing.Point(361, 83);
            this.btnStopRecord.Name = "btnStopRecord";
            this.btnStopRecord.Size = new System.Drawing.Size(114, 23);
            this.btnStopRecord.TabIndex = 2;
            this.btnStopRecord.Text = "Stop Recording";
            this.btnStopRecord.UseVisualStyleBackColor = true;
            this.btnStopRecord.Click += new System.EventHandler(this.btnStopRecord_Click);
            // 
            // NewMacro
            // 
            this.NewMacro.Location = new System.Drawing.Point(361, 12);
            this.NewMacro.Name = "NewMacro";
            this.NewMacro.Size = new System.Drawing.Size(114, 23);
            this.NewMacro.TabIndex = 3;
            this.NewMacro.Text = "New Macro";
            this.NewMacro.UseVisualStyleBackColor = true;
            this.NewMacro.Click += new System.EventHandler(this.NewMacro_Click);
            // 
            // macroListBox
            // 
            this.macroListBox.FormattingEnabled = true;
            this.macroListBox.Location = new System.Drawing.Point(12, 12);
            this.macroListBox.Name = "macroListBox";
            this.macroListBox.Size = new System.Drawing.Size(161, 420);
            this.macroListBox.TabIndex = 4;
            this.macroListBox.SelectedIndexChanged += new System.EventHandler(this.macroListBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 450);
            this.Controls.Add(this.macroListBox);
            this.Controls.Add(this.NewMacro);
            this.Controls.Add(this.btnStopRecord);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.btnRecord);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.RichTextBox txtOut;
        private System.Windows.Forms.Button btnStopRecord;
        private System.Windows.Forms.Button NewMacro;
        private System.Windows.Forms.ListBox macroListBox;
    }
}

