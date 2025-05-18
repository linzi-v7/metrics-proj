using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public enum Parameter
{
    //values to index into the complexity table array
    ExternalInput = 0,
    ExternalOutput = 1,
    ExternalInquiry = 2,
    InternalLogicalFiles = 3,
    ExternalInterfaceFiles = 4,
}

public enum Complexity
{
    //values to index into the complexity table array
    Simple = 0,
    Average = 1,
    Complex = 2,
}


namespace metricsFP
{


    public partial class Form1 : Form
    {
        //index this using complexity paramter type and level enums to get desired value
        private int[,] complexityTable = new int[5, 3]
        {
            { 3, 4,   6 },
            { 4,  5,  7 },
            { 3,  4,  6 },
            { 7, 10, 15 },
            { 5,  7, 10 },
        };

        private int totalDI = 1;
        private int totalUFP;
        private double totalTCF;
        private double totalFP = -1;
        private double totalLOC;

        private String chosenLanguage = "None";
        private int chosenAVC = 0;

        private Complexity DetermineComplexity(string controlName)
        {
            if (controlName.EndsWith("Simple")) return Complexity.Simple;
            if (controlName.EndsWith("Average")) return Complexity.Average;
            if (controlName.EndsWith("Complex")) return Complexity.Complex;

            throw new Exception($"Cannot determine complexity type for control: {controlName}");
        }

        public void UpdateDILabel(int result)
        {
            if (result == 0)
            {
                result = 1;
            }
            totalDI = result;
            DI_Label.Text = $"Current DI: {result}";
        }

        public void UpdateAVC(String chosenLanguage, int chosenAVC)
        {
            this.chosenLanguage = chosenLanguage;
            this.chosenAVC = chosenAVC;

            languageLabel.Text = $"Language: {chosenLanguage}";
            avcLabel.Text = $"AVC: {chosenAVC}";
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //assign each groupbox to its relevant parameter type for
            //easier processing in other functions.
            extInput_GroupBox.Tag = Parameter.ExternalInput;
            extOutput_GroupBox.Tag = Parameter.ExternalOutput;
            extInquiry_GroupBox.Tag = Parameter.ExternalInquiry;
            intLogicFiles_GroupBox.Tag = Parameter.InternalLogicalFiles;
            extInterfaceFiles_GroupBox.Tag = Parameter.ExternalInterfaceFiles;


            resultTextBox.Text = "Welcome to the FP Calculator Assistant!\r\n" +
            "Follow these steps to complete your Function Point calculation:\r\n\r\n" +
            "1. Calculate the Unadjusted Function Points (UFP)\r\n" +
            "2. Determine the Degree of Influence (DI) using our dedicated DI form\r\n" +
            "3. Compute the Technical Complexity Factor (TCF)\r\n" +
            "4. You're now ready to calculate the final Function Points (FP)!\r\n" +
            "5. Choose Language and its corresponding AVC from relevant form.\r\n" +
            "6. Calculate the total Lines Of Code (LOC) needed!\r\n" +
            "7. You are done!\r\n" +
            "To show instructions again while calculating, press on the show instructions button.";
        }

        private void calculateUFP_Button_Click(object sender, EventArgs e)
        {

            totalUFP = 0;

            //iterate over each groupbox in the master groupbox (countGroupBox)
            foreach (Control control in countGroupBox.Controls)
            {
                if (!(control is GroupBox currentGroupBox)) continue;

                int parameterType = (int)currentGroupBox.Tag;

                //iterate over every numeric input in the subGroupBox
                foreach (Control innerControl in currentGroupBox.Controls)
                {
                    if (!(innerControl is NumericUpDown numericControl)) continue;

                    Complexity complexityType = DetermineComplexity(numericControl.Name);
                    int complexityValue = complexityTable[parameterType, (int)complexityType];
                    totalUFP += (int)numericControl.Value * complexityValue;
                }
            }

            resultTextBox.Text =
              "Function Point Analysis Result\n" +
              "------------------------------\n" +
              $"Total Unadjusted Function Points (UFP): {totalUFP}";
        }

        private void openDI_Button_Click(object sender, EventArgs e)
        {
            DI_Form dI_Form = new DI_Form(this);
            dI_Form.ShowDialog();
        }

        private void calculateTCF_Button_Click(object sender, EventArgs e)
        {
            if (totalUFP == 0 || totalDI == 0)
            {
                resultTextBox.Text =
                "Function Point Analysis Result\n" +
                "------------------------------\n" +
                "ERROR: CANT CALCULATE RESULT.\n" +
                "TRY CALCULATING UFP & DI FIRST!";
                return;
            }

            totalTCF = 0.65 + (0.01 * totalDI);
            resultTextBox.Text =
            "Function Point Analysis Result\n" +
             "------------------------------\n" +
            $"Total Unadjusted Function Points (UFP): {totalUFP}\n" +
            $"Total Degree of Influence (DI): {totalDI}\n" +
            $"Total Technical Complexity Factor (TCF): {totalTCF}\n";
        }

        private void calculateFP_button_Click(object sender, EventArgs e)
        {
            if (totalUFP == 0 || totalTCF == 0)
            {
                resultTextBox.Text =
                "Function Point Analysis Result\n" +
                "------------------------------\n" +
                "ERROR: CANT CALCULATE RESULT.\n" +
                "TRY CALCULATING UFP & TCF/DI FIRST!";
                return;
            }

            totalFP = totalUFP * totalTCF;
            resultTextBox.Text =
            "Function Point Analysis Result\n" +
             "------------------------------\n" +
            $"Total Unadjusted Function Points (UFP): {totalUFP}\n" +
            $"Total Degree of Influence (DI): {totalDI}\n" +
            $"Total Technical Complexity Factor (TCF): {totalTCF}\n" +
            $"Total Function Points (FP): {totalFP}\n";
        }

        private void help_Button_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = "Welcome to the FP Calculator Assistant!\r\n" +
                "Follow these steps to complete your Function Point calculation:\r\n\r\n" +
                "1. Calculate the Unadjusted Function Points (UFP)\r\n" +
                "2. Determine the Degree of Influence (DI) using our dedicated DI form\r\n" +
                "3. Compute the Technical Complexity Factor (TCF)\r\n" +
                "4. You're now ready to calculate the final Function Points (FP)!\r\n" +
                "5. Choose Language and its corresponding AVC from relevant form.\r\n" +
                "6. Calculate the total Lines Of Code (LOC) needed!\r\n" +
                "7. You are done!\r\n" +
                "To show instructions again while calculating, press on the show instructions button.";
        }

        private void AVCForm_Button_Click(object sender, EventArgs e)
        {
            AVC_Form avcForm = new AVC_Form(this);
            avcForm.ShowDialog();
        }

        private void calculateLOC_Button_Click(object sender, EventArgs e)
        {
            if(chosenAVC == 0 || chosenLanguage == "None")
            {
                resultTextBox.Text =
                    "Function Point Analysis Result\n" +
                    "------------------------------\n" +
                    "ERROR: CANT CALCULATE LOC RESULT.\n" +
                    "TRY CHOOSING AVC VALUE FROM FORM FIRST!";
                return;
            }

            if(totalFP == -1)
            {
                resultTextBox.Text =
                    "Function Point Analysis Result\n" +
                    "------------------------------\n" +
                    "ERROR: CANT CALCULATE LOC RESULT.\n" +
                    "TRY CALCULATING FP FIRST!";
                return;
            }

            totalLOC = chosenAVC * totalFP;
            resultTextBox.Text =
                "Function Point Analysis Result\n" +
                "------------------------------\n" +
                $"Total Unadjusted Function Points (UFP): {totalUFP}\n" +
                $"Total Degree of Influence (DI): {totalDI}\n" +
                $"Total Technical Complexity Factor (TCF): {totalTCF}\n" +
                $"Total Function Points (FP): {totalFP}\n" +
                $"Chosen Programming Language For LOC: {chosenLanguage}\n" +
                $"AVC Corresponding to Programming Language: {chosenAVC}\n" +
                $"Total Lines Of Code (LOC): {totalLOC}\n";
        }
    }
}
