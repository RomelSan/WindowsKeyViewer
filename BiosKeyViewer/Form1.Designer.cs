namespace BiosKeyViewer
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
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.label_injectedKey = new System.Windows.Forms.Label();
            this.textBox_injectedkey = new System.Windows.Forms.TextBox();
            this.label_winkey = new System.Windows.Forms.Label();
            this.textBox_winkey = new System.Windows.Forms.TextBox();
            this.label_credits = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_content
            // 
            this.textBox_content.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_content.Location = new System.Drawing.Point(12, 90);
            this.textBox_content.Multiline = true;
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.ReadOnly = true;
            this.textBox_content.Size = new System.Drawing.Size(532, 309);
            this.textBox_content.TabIndex = 0;
            // 
            // label_injectedKey
            // 
            this.label_injectedKey.AutoSize = true;
            this.label_injectedKey.Location = new System.Drawing.Point(13, 23);
            this.label_injectedKey.Name = "label_injectedKey";
            this.label_injectedKey.Size = new System.Drawing.Size(89, 15);
            this.label_injectedKey.TabIndex = 1;
            this.label_injectedKey.Text = "Injected Key:";
            // 
            // textBox_injectedkey
            // 
            this.textBox_injectedkey.Location = new System.Drawing.Point(169, 21);
            this.textBox_injectedkey.Name = "textBox_injectedkey";
            this.textBox_injectedkey.ReadOnly = true;
            this.textBox_injectedkey.Size = new System.Drawing.Size(375, 21);
            this.textBox_injectedkey.TabIndex = 2;
            // 
            // label_winkey
            // 
            this.label_winkey.AutoSize = true;
            this.label_winkey.Location = new System.Drawing.Point(13, 57);
            this.label_winkey.Name = "label_winkey";
            this.label_winkey.Size = new System.Drawing.Size(150, 15);
            this.label_winkey.TabIndex = 3;
            this.label_winkey.Text = "Windows Key (partial):";
            // 
            // textBox_winkey
            // 
            this.textBox_winkey.Location = new System.Drawing.Point(169, 57);
            this.textBox_winkey.Name = "textBox_winkey";
            this.textBox_winkey.ReadOnly = true;
            this.textBox_winkey.Size = new System.Drawing.Size(375, 21);
            this.textBox_winkey.TabIndex = 4;
            // 
            // label_credits
            // 
            this.label_credits.AutoSize = true;
            this.label_credits.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_credits.Location = new System.Drawing.Point(453, 403);
            this.label_credits.Name = "label_credits";
            this.label_credits.Size = new System.Drawing.Size(91, 14);
            this.label_credits.TabIndex = 5;
            this.label_credits.Text = "by @RomelSan";
            this.label_credits.Click += new System.EventHandler(this.label_credits_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 426);
            this.Controls.Add(this.label_credits);
            this.Controls.Add(this.textBox_winkey);
            this.Controls.Add(this.label_winkey);
            this.Controls.Add(this.textBox_injectedkey);
            this.Controls.Add(this.label_injectedKey);
            this.Controls.Add(this.textBox_content);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Bios Key Viewer 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_content;
        private System.Windows.Forms.Label label_injectedKey;
        private System.Windows.Forms.TextBox textBox_injectedkey;
        private System.Windows.Forms.Label label_winkey;
        private System.Windows.Forms.TextBox textBox_winkey;
        private System.Windows.Forms.Label label_credits;
    }
}

