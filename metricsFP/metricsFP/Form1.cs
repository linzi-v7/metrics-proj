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


        private Complexity DetermineComplexity(string controlName)
        {
            if (controlName.EndsWith("Simple")) return Complexity.Simple;
            if (controlName.EndsWith("Average")) return Complexity.Average;
            if (controlName.EndsWith("Complex")) return Complexity.Complex;

            throw new Exception($"Cannot determine complexity type for control: {controlName}");
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

        }

        private void calculateUFP_Button_Click(object sender, EventArgs e)
        {

            int totalUFP = 0;

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
    }
}
