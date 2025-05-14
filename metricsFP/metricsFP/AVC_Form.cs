using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metricsFP
{
    public partial class AVC_Form : Form
    {
        private Form1 mainForm;
        private String chosenLanguage;
        private int chosenAVC;

        private Dictionary<string, int> languageValues = new Dictionary<string, int>()
        {
            { "None", 0 },
            { "Assembly Language", 320 },
            { "C", 128 },
            { "COBOL/Fortran", 105 },
            { "Pascal", 90 },
            { "Ada", 70 },
            { "C++", 64 },
            { "Visual Basic", 32 },
            { "Object-Oriented Languages", 30 },
            { "Smalltalk", 22 },
            { "Code Generators (PowerBuilder)", 15 },
            { "SQL/Oracle", 12 },
            { "Spreadsheets", 6 },
            { "Graphical Languages (icons)", 4 }
        };

        public AVC_Form(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void AVC_Form_Load(object sender, EventArgs e)
        {
            int yPos = 20;
            foreach (var lang in languageValues)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Text = $"{lang.Key} - {lang.Value}";
                radioButton.Tag = lang.Value;
                radioButton.Font = new Font("Microsoft Sans Serif", 10);
                radioButton.Location = new Point(10, yPos);
                radioButton.AutoSize = true;
                radioButton.CheckedChanged += RadioButton_CheckedChanged; //Subscribe to Event Handler

                //make None be the default value
                if(lang.Value == 0)
                {
                    radioButton.Checked = true;
                }

                groupBox1.Controls.Add(radioButton);
                yPos += 27;
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.Checked)
            {
                chosenAVC = (int)radioButton.Tag;
                chosenLanguage = radioButton.Text.Split('-')[0].Trim();
            }
        }

        private void saveAVC_Button_Click(object sender, EventArgs e)
        {
            mainForm.UpdateAVC(chosenLanguage, chosenAVC);
            this.Close();
        }
    }
}
