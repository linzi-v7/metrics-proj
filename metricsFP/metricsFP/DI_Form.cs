using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public enum TCF
{
    noInfluence = 0,
    incidental = 1,
    moderate = 2,
    average = 3,
    significant = 4,
    essential = 5,
}

namespace metricsFP
{
    public partial class DI_Form : Form
    {
        private Form1 mainForm;

        string[] TCFItems = {
        "Data Communications",
        "Distributed Processing",
        "Performance Requirements",
        "Heavily Used Configuration",
        "Transaction Rate",
        "Online Data Entry",
        "End-User Efficiency",
        "Online Updates",
        "Complex Processing",
        "Reusability",
        "Installation Ease",
        "Operational Ease",
        "Multiple Sites",
        "Facilitate Change"
        };

        private TCF determineTCF(string comboBoxValue)
        {
            if (comboBoxValue.Equals("No Influence")) return TCF.noInfluence;
            if (comboBoxValue.Equals("Incidental")) return TCF.incidental;
            if (comboBoxValue.Equals("Moderate")) return TCF.moderate;
            if (comboBoxValue.Equals("Average")) return TCF.average;
            if (comboBoxValue.Equals("Significant")) return TCF.significant;
            if (comboBoxValue.Equals("Essential")) return TCF.essential;

            throw new Exception($"Cannot determine TCF for control comboBox");
        }

        public DI_Form(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Details_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Size normalSize = new Size(250, 200);
            Size expandedSize = new Size(340, 600);


            //show more details
            if (Details_Checkbox.Checked)
            {
                this.Size = expandedSize;
                Details_Checkbox.Location = new Point(100, 10);
                calculateDI_Button.Location = new Point(50, 480);

                foreach (Control control in this.Controls)
                {
                    if (control is CheckBox) continue;
                    if (control is Button) continue;
                    if (control.Visible)
                    {
                        control.Visible = false;
                    }
                    else
                    {
                        control.Visible = true;
                    }
                }

            }
            else
            {
                this.Size = normalSize;
                Details_Checkbox.Location = new Point(45, 80);
                calculateDI_Button.Location = new Point(20, 105);

                foreach (Control control in this.Controls)
                {
                    if (control is CheckBox) continue;
                    if (control is Button) continue;
                    if(control.Visible)
                    {
                        control.Visible = false;
                    }
                    else
                    {
                        control.Visible = true;
                    }
                }

            }
        }

        private void DI_Form_Load(object sender, EventArgs e)
        {
            DIValue_Label.Visible = true;
            DI_nud.Visible = true;

            int yPosition = 50;
            foreach (string item in TCFItems)
            {
                Label label = new Label();
                label.Text = item;
                label.AutoSize = true;
                label.Location = new Point(20, yPosition);
                label.Visible = false;

                ComboBox comboBox = new ComboBox();
                comboBox.Location = new Point(170, yPosition);
                comboBox.Visible = false;
                comboBox.Items.Add("No Influence");
                comboBox.Items.Add("Incidental");
                comboBox.Items.Add("Moderate");
                comboBox.Items.Add("Average");
                comboBox.Items.Add("Significant");
                comboBox.Items.Add("Essential");
                
                comboBox.SelectedIndex = 0;

                this.Controls.Add(comboBox);
                this.Controls.Add(label);
                yPosition += 30;
            }

        }

        private void calculateDI_Button_Click(object sender, EventArgs e)
        {
            int totalDI = 0;

            if (!Details_Checkbox.Checked
                 && DI_nud.Visible)
            {
                totalDI = (int) DI_nud.Value;
                mainForm.UpdateDILabel(totalDI);
                this.Close();
                return;
            }

            foreach (Control control in this.Controls) 
            {
                if (!control.Visible) continue;
                if(control is ComboBox comboBox)
                {
                    TCF comboBoxTCF = determineTCF(comboBox.Text);
                    totalDI += (int) comboBoxTCF;
                }

            }
            mainForm.UpdateDILabel(totalDI);
            this.Close();
        }
    }
}
