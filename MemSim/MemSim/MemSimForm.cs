using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MemSim
{
    public partial class MemSimForm : Form
    {
        Configurations config;
        MemoryManagementUnit MMU;
        string outputString = "";
        string statsString = "";
        public MemSimForm()
        {
            InitializeComponent();
            config = new Configurations();
            MMU = new MemoryManagementUnit();
        }

        private void MemSimForm_Load(object sender, EventArgs e)
        {
            resetConfigToDefault();
            statsString = "";
            outputString = "";
            StatsTextBox.Text = statsString;
            outputTextBox.Text = outputString;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            resetConfigToDefault();
            statsString = "";
            outputString = "";
            StatsTextBox.Text = statsString;
            outputTextBox.Text = outputString;
        }

        private void resetConfigToDefault()
        {
            VirtAddressingCheckBox.Checked = true;
            config.setToDefault();
            updateConfigGUI();
        }

        private void InputFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Path.Combine(Application.StartupPath, "");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(dlg.FileName, Encoding.Default);
                InputTextBox.Text = reader.ReadToEnd();
                reader.Close();
            }
            dlg.Dispose();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            if(InputTextBox.Text != "" && InputTextBox.Text != null)
            {
                string inputString = InputTextBox.Text;
                MMU.RunProgram(ref config, ref inputString, ref statsString, ref outputString);
            }
            updateGUI();
        }

        private void catchValueChange(object sender, EventArgs e)
        {
            updateConfig();
            updateConfigGUI();
        }
        public void updateGUI()
        {
            StatsTextBox.Text = statsString;
            outputTextBox.Text = outputString;
        }

        public void updateConfigGUI()
        {
            PT_VPBox.SelectedIndex = config.PT_NumOfVP == 1 ? 0 : (int)Math.Log(config.PT_NumOfVP, 2);
            PT_PPBox.SelectedIndex = config.PT_NumOfPhyP == 1 ? 0 : (int)Math.Log(config.PT_NumOfPhyP, 2);
            PT_PageSizeBox.SelectedIndex = config.PT_PageSize == 1 ? 0 : (int)Math.Log(config.PT_PageSize, 2);

            DC_NumOfSetsBox.SelectedIndex = config.DC_NumOfSets == 1 ? 0 : (int)Math.Log(config.DC_NumOfSets, 2);
            DC_SetSizeBox.SelectedIndex = config.DC_SetSize == 1 ? 0 : (int)Math.Log(config.DC_SetSize, 2);
            DC_LineSizeBox.SelectedIndex = config.DC_LineSize == 1 ? 0 : (int)Math.Log(config.DC_LineSize, 2);
            DC_WriteThroughCheckBox.Checked = config.DC_Writethrough_NoAllocate;

            L2CacheCheckBox.Checked = config.L2Cache_Exists;
            L2_NumOfSetsBox.SelectedIndex = config.L2_NumOfSets == 1 ? 0 : (int)Math.Log(config.L2_NumOfSets, 2);
            L2_SetSizeBox.SelectedIndex = config.L2_SetSize == 1 ? 0 : (int)Math.Log(config.L2_SetSize, 2);
            L2_LineSizeBox.SelectedIndex = config.L2_LineSize == 1 ? 0 : (int)Math.Log(config.L2_LineSize, 2);
            L2_WriteThroughCheckBox.Checked = config.L2_Writethrough_NoAllocate;

            TLB_Checkbox.Checked = VirtAddressingCheckBox.Checked && config.TLB_Exists;
            TLB_NumOfSetsBox.SelectedIndex = config.TLB_NumOfSets == 1 ? 0 : (int)Math.Log(config.TLB_NumOfSets, 2);
            TLB_SetSizeBox.SelectedIndex = config.TLB_SetSize == 1 ? 0 : (int)Math.Log(config.TLB_SetSize, 2);

            VirtAddressingCheckBox.Checked = config.VirtAddressing;

           if (!VirtAddressingCheckBox.Checked)
            {
                TLB_Checkbox.Enabled = false;
                PT_PageSizeBox.Enabled = false;
                PT_PPBox.Enabled = false;
                PT_VPBox.Enabled = false;
            }
            else
            {
                TLB_Checkbox.Enabled = true;
                PT_PageSizeBox.Enabled = true;
                PT_PPBox.Enabled = true;
                PT_VPBox.Enabled = true;
            }
            if (!TLB_Checkbox.Checked || !VirtAddressingCheckBox.Checked)
            { 
                TLB_NumOfSetsBox.Enabled = false;
                TLB_SetSizeBox.Enabled = false;
            }
            else
            {
                TLB_NumOfSetsBox.Enabled = true;
                TLB_SetSizeBox.Enabled = true;
            }
            if(!L2CacheCheckBox.Checked)
            {
                L2_NumOfSetsBox.Enabled = false;
                L2_SetSizeBox.Enabled = false;
                L2_LineSizeBox.Enabled = false;
                L2_WriteThroughCheckBox.Enabled = false;
            }
            else
            {
                L2_NumOfSetsBox.Enabled = true;
                L2_SetSizeBox.Enabled = true;
                L2_LineSizeBox.Enabled = true;
                L2_WriteThroughCheckBox.Enabled = true;
            }

            config.updateConfiguration();
        }

        public void updateConfig()
        {
            config.PT_NumOfVP = (int)Math.Pow(2, PT_VPBox.SelectedIndex);
            config.PT_NumOfPhyP = (int)Math.Pow(2, PT_PPBox.SelectedIndex);
            config.PT_PageSize = (int)Math.Pow(2, PT_PageSizeBox.SelectedIndex);

            config.DC_NumOfSets = (int)Math.Pow(2, DC_NumOfSetsBox.SelectedIndex);
            config.DC_SetSize = (int)Math.Pow(2, DC_SetSizeBox.SelectedIndex);
            config.DC_LineSize = (int)Math.Pow(2, DC_LineSizeBox.SelectedIndex);
            config.DC_Writethrough_NoAllocate = DC_WriteThroughCheckBox.Checked;

            config.L2Cache_Exists = L2CacheCheckBox.Checked;
            config.L2_NumOfSets = (int)Math.Pow(2, L2_NumOfSetsBox.SelectedIndex);
            config.L2_SetSize = (int)Math.Pow(2, L2_SetSizeBox.SelectedIndex);
            config.L2_LineSize = (int)Math.Pow(2, L2_LineSizeBox.SelectedIndex);
            config.L2_Writethrough_NoAllocate = L2_WriteThroughCheckBox.Checked;

            config.TLB_Exists = TLB_Checkbox.Checked;
            config.TLB_NumOfSets = (int)Math.Pow(2, TLB_NumOfSetsBox.SelectedIndex);
            config.TLB_SetSize = (int)Math.Pow(2, TLB_SetSizeBox.SelectedIndex);

            config.VirtAddressing = VirtAddressingCheckBox.Checked;
        }

    }
}
