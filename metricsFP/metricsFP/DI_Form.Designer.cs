namespace metricsFP
{
    partial class DI_Form
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
            this.DIValue_Label = new System.Windows.Forms.Label();
            this.DI_nud = new System.Windows.Forms.NumericUpDown();
            this.Details_Checkbox = new System.Windows.Forms.CheckBox();
            this.calculateDI_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DI_nud)).BeginInit();
            this.SuspendLayout();
            // 
            // DIValue_Label
            // 
            this.DIValue_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DIValue_Label.Location = new System.Drawing.Point(57, 27);
            this.DIValue_Label.Name = "DIValue_Label";
            this.DIValue_Label.Size = new System.Drawing.Size(236, 45);
            this.DIValue_Label.TabIndex = 0;
            this.DIValue_Label.Text = "Enter DI As Number";
            // 
            // DI_nud
            // 
            this.DI_nud.Location = new System.Drawing.Point(61, 62);
            this.DI_nud.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.DI_nud.Name = "DI_nud";
            this.DI_nud.Size = new System.Drawing.Size(180, 22);
            this.DI_nud.TabIndex = 1;
            // 
            // Details_Checkbox
            // 
            this.Details_Checkbox.AutoSize = true;
            this.Details_Checkbox.Location = new System.Drawing.Point(61, 102);
            this.Details_Checkbox.Name = "Details_Checkbox";
            this.Details_Checkbox.Size = new System.Drawing.Size(141, 20);
            this.Details_Checkbox.TabIndex = 2;
            this.Details_Checkbox.Text = "Show More Details";
            this.Details_Checkbox.UseVisualStyleBackColor = true;
            this.Details_Checkbox.CheckedChanged += new System.EventHandler(this.Details_Checkbox_CheckedChanged);
            // 
            // calculateDI_Button
            // 
            this.calculateDI_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculateDI_Button.Location = new System.Drawing.Point(24, 151);
            this.calculateDI_Button.Name = "calculateDI_Button";
            this.calculateDI_Button.Size = new System.Drawing.Size(269, 58);
            this.calculateDI_Button.TabIndex = 3;
            this.calculateDI_Button.Text = "Calculate And Save DI";
            this.calculateDI_Button.UseVisualStyleBackColor = true;
            this.calculateDI_Button.Click += new System.EventHandler(this.calculateDI_Button_Click);
            // 
            // DI_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 234);
            this.Controls.Add(this.calculateDI_Button);
            this.Controls.Add(this.Details_Checkbox);
            this.Controls.Add(this.DI_nud);
            this.Controls.Add(this.DIValue_Label);
            this.Name = "DI_Form";
            this.Text = "DI Calculation Form";
            this.Load += new System.EventHandler(this.DI_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DI_nud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DIValue_Label;
        private System.Windows.Forms.NumericUpDown DI_nud;
        private System.Windows.Forms.CheckBox Details_Checkbox;
        private System.Windows.Forms.Button calculateDI_Button;
    }
}