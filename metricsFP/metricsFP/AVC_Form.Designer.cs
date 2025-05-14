namespace metricsFP
{
    partial class AVC_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveAVC_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Choose Your Desired Language AVC";
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(69, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 512);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language - AVC";
            // 
            // saveAVC_Button
            // 
            this.saveAVC_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveAVC_Button.Location = new System.Drawing.Point(69, 600);
            this.saveAVC_Button.Name = "saveAVC_Button";
            this.saveAVC_Button.Size = new System.Drawing.Size(399, 60);
            this.saveAVC_Button.TabIndex = 2;
            this.saveAVC_Button.Text = "Save AVC Value";
            this.saveAVC_Button.UseVisualStyleBackColor = true;
            this.saveAVC_Button.Click += new System.EventHandler(this.saveAVC_Button_Click);
            // 
            // AVC_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 690);
            this.Controls.Add(this.saveAVC_Button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "AVC_Form";
            this.Text = "Choose Language/AVC";
            this.Load += new System.EventHandler(this.AVC_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveAVC_Button;
    }
}