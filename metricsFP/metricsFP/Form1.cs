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
            { 3, 4, 6   },
            { 4,  5,  7 },
            { 3,  4,  6 },
            { 7, 10, 15 },
            { 5,  7, 10 },
        };
        



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set all combo boxes to first value
            extInput_ComboBox.SelectedIndex = 0;
            extOutput_ComboBox.SelectedIndex = 0;
            extInquiry_ComboBox.SelectedIndex = 0;
            intLogicFiles_ComboBox.SelectedIndex = 0;
            extInterfaceFiles_ComboBox.SelectedIndex = 0;

        }

        private void calculateUFP_Button_Click(object sender, EventArgs e)
        {
            //get count of all parameters based on input
            int extInputCount = (int) extInput_Numeric.Value;
            int extOutputCount = (int) extOutput_Numeric.Value;
            int extInquiryCount = (int) extInquiry_Numeric.Value;
            int intLogicFilesCount = (int) intLogicFiles_Numeric.Value;
            int extInterfaceFilesCount = (int) extInterfaceFiles_Numeric.Value;

            //get complexity type of all parameters from the combobox
            int extInputType = extInput_ComboBox.SelectedIndex;
            int extOutputType = extOutput_ComboBox.SelectedIndex;
            int extInquiryType = extInquiry_ComboBox.SelectedIndex;
            int intLogicFilesType = intLogicFiles_ComboBox.SelectedIndex;
            int extInterfaceFilesType = extInterfaceFiles_ComboBox.SelectedIndex;

            //index complexity table
            int extInputComplexity = complexityTable[(int)Parameter.ExternalInput, extInputType];
            int extOutputComplexity = complexityTable[(int)Parameter.ExternalOutput, extOutputType];
            int extInquiryComplexity = complexityTable[(int)Parameter.ExternalInquiry, extInquiryType];
            int intLogicFilesComplexity = complexityTable[(int)Parameter.InternalLogicalFiles, intLogicFilesType];
            int extInterfaceFilesComplexity = complexityTable[(int)Parameter.ExternalInterfaceFiles, extInterfaceFilesType];


            int totalUFP =
             extInputCount * extInputComplexity +
             extOutputCount * extOutputComplexity +
             extInquiryCount * extInquiryComplexity +
             intLogicFilesCount * intLogicFilesComplexity +
             extInterfaceFilesCount * extInterfaceFilesComplexity;

            resultTextBox.Text =
              "Function Point Analysis Result\n" +
              "------------------------------\n" +
              $"Total Unadjusted Function Points (UFP): {totalUFP}";
        }
    }
}
