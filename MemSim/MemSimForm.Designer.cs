namespace MemSim
{
    partial class MemSimForm
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
            System.Windows.Forms.TabPage outputBox;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemSimForm));
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.InputFileButton = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.InputTextBox = new System.Windows.Forms.RichTextBox();
            this.MemRefLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.outputTabs = new System.Windows.Forms.TabControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.runButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.TLB_Checkbox = new System.Windows.Forms.CheckBox();
            this.L2CacheCheckBox = new System.Windows.Forms.CheckBox();
            this.PT_VPBox = new System.Windows.Forms.ComboBox();
            this.PT_VP_Label = new System.Windows.Forms.Label();
            this.PT_PPBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PT_PageSizeBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.VirtAddressingCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DC_SetSizeBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DC_LineSizeBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DC_WriteThroughCheckBox = new System.Windows.Forms.CheckBox();
            this.L2_WriteThroughCheckBox = new System.Windows.Forms.CheckBox();
            this.L2_LineSizeBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.L2_SetSizeBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TLB_SetSizeBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.DC_NumOfSetsBox = new System.Windows.Forms.ComboBox();
            this.TLB_NumOfSetsBox = new System.Windows.Forms.ComboBox();
            this.L2_NumOfSetsBox = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.StatsTextBox = new System.Windows.Forms.RichTextBox();
            outputBox = new System.Windows.Forms.TabPage();
            outputBox.SuspendLayout();
            this.outputTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputBox
            // 
            outputBox.Controls.Add(this.outputTextBox);
            outputBox.Location = new System.Drawing.Point(4, 22);
            outputBox.Name = "outputBox";
            outputBox.Padding = new System.Windows.Forms.Padding(3);
            outputBox.Size = new System.Drawing.Size(855, 324);
            outputBox.TabIndex = 0;
            outputBox.Text = "Summary";
            outputBox.UseVisualStyleBackColor = true;
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.outputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.Location = new System.Drawing.Point(3, 7);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(846, 314);
            this.outputTextBox.TabIndex = 0;
            this.outputTextBox.Text = "";
            // 
            // InputFileButton
            // 
            this.InputFileButton.Location = new System.Drawing.Point(12, 9);
            this.InputFileButton.Name = "InputFileButton";
            this.InputFileButton.Size = new System.Drawing.Size(63, 23);
            this.InputFileButton.TabIndex = 149;
            this.InputFileButton.Text = "Input File";
            this.InputFileButton.UseVisualStyleBackColor = true;
            this.InputFileButton.Click += new System.EventHandler(this.InputFileButton_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(783, 363);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(63, 22);
            this.SaveFileButton.TabIndex = 150;
            this.SaveFileButton.Text = "Save";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            // 
            // InputTextBox
            // 
            this.InputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputTextBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.Location = new System.Drawing.Point(12, 41);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(446, 346);
            this.InputTextBox.TabIndex = 151;
            this.InputTextBox.Text = "";
            // 
            // MemRefLabel
            // 
            this.MemRefLabel.AutoSize = true;
            this.MemRefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemRefLabel.Location = new System.Drawing.Point(127, 8);
            this.MemRefLabel.Name = "MemRefLabel";
            this.MemRefLabel.Size = new System.Drawing.Size(198, 24);
            this.MemRefLabel.TabIndex = 153;
            this.MemRefLabel.Text = "Memory References";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(581, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 25);
            this.label2.TabIndex = 155;
            this.label2.Text = "Configurations";
            // 
            // outputTabs
            // 
            this.outputTabs.Controls.Add(outputBox);
            this.outputTabs.Controls.Add(this.tabPage1);
            this.outputTabs.Location = new System.Drawing.Point(12, 393);
            this.outputTabs.Name = "outputTabs";
            this.outputTabs.SelectedIndex = 0;
            this.outputTabs.Size = new System.Drawing.Size(863, 350);
            this.outputTabs.TabIndex = 156;
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.ForeColor = System.Drawing.Color.Blue;
            this.runButton.Location = new System.Drawing.Point(383, 7);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 27);
            this.runButton.TabIndex = 157;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(465, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 160;
            this.label4.Text = "Page Table";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(652, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 161;
            this.label5.Text = "Data Cache";
            // 
            // resetButton
            // 
            this.resetButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.resetButton.Location = new System.Drawing.Point(702, 363);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 163;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // TLB_Checkbox
            // 
            this.TLB_Checkbox.AutoSize = true;
            this.TLB_Checkbox.Checked = true;
            this.TLB_Checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TLB_Checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLB_Checkbox.Location = new System.Drawing.Point(656, 224);
            this.TLB_Checkbox.Name = "TLB_Checkbox";
            this.TLB_Checkbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TLB_Checkbox.Size = new System.Drawing.Size(57, 24);
            this.TLB_Checkbox.TabIndex = 164;
            this.TLB_Checkbox.Text = "TLB";
            this.TLB_Checkbox.UseVisualStyleBackColor = true;
            this.TLB_Checkbox.CheckedChanged += new System.EventHandler(this.catchValueChange);
            // 
            // L2CacheCheckBox
            // 
            this.L2CacheCheckBox.AutoSize = true;
            this.L2CacheCheckBox.Checked = true;
            this.L2CacheCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.L2CacheCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L2CacheCheckBox.Location = new System.Drawing.Point(464, 195);
            this.L2CacheCheckBox.Name = "L2CacheCheckBox";
            this.L2CacheCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.L2CacheCheckBox.Size = new System.Drawing.Size(92, 24);
            this.L2CacheCheckBox.TabIndex = 165;
            this.L2CacheCheckBox.Text = "L2Cache";
            this.L2CacheCheckBox.UseVisualStyleBackColor = true;
            this.L2CacheCheckBox.CheckedChanged += new System.EventHandler(this.catchValueChange);
            // 
            // PT_VPBox
            // 
            this.PT_VPBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PT_VPBox.FormattingEnabled = true;
            this.PT_VPBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048",
            "4096",
            "8192"});
            this.PT_VPBox.Location = new System.Drawing.Point(469, 91);
            this.PT_VPBox.Name = "PT_VPBox";
            this.PT_VPBox.Size = new System.Drawing.Size(64, 24);
            this.PT_VPBox.TabIndex = 167;
            this.PT_VPBox.Text = "64";
            this.PT_VPBox.SelectedIndexChanged += new System.EventHandler(this.catchValueChange);
            // 
            // PT_VP_Label
            // 
            this.PT_VP_Label.AutoSize = true;
            this.PT_VP_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PT_VP_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PT_VP_Label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PT_VP_Label.Location = new System.Drawing.Point(536, 96);
            this.PT_VP_Label.Name = "PT_VP_Label";
            this.PT_VP_Label.Size = new System.Drawing.Size(87, 16);
            this.PT_VP_Label.TabIndex = 166;
            this.PT_VP_Label.Text = "Virtual Pages";
            // 
            // PT_PPBox
            // 
            this.PT_PPBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PT_PPBox.FormattingEnabled = true;
            this.PT_PPBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048"});
            this.PT_PPBox.Location = new System.Drawing.Point(469, 125);
            this.PT_PPBox.Name = "PT_PPBox";
            this.PT_PPBox.Size = new System.Drawing.Size(64, 24);
            this.PT_PPBox.TabIndex = 169;
            this.PT_PPBox.Text = "4";
            this.PT_PPBox.SelectedIndexChanged += new System.EventHandler(this.catchValueChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(536, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 168;
            this.label3.Text = "Physical Pages";
            // 
            // PT_PageSizeBox
            // 
            this.PT_PageSizeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PT_PageSizeBox.FormattingEnabled = true;
            this.PT_PageSizeBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048",
            "4096"});
            this.PT_PageSizeBox.Location = new System.Drawing.Point(469, 159);
            this.PT_PageSizeBox.Name = "PT_PageSizeBox";
            this.PT_PageSizeBox.Size = new System.Drawing.Size(64, 24);
            this.PT_PageSizeBox.TabIndex = 171;
            this.PT_PageSizeBox.Text = "256";
            this.PT_PageSizeBox.SelectedIndexChanged += new System.EventHandler(this.catchValueChange);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(536, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 170;
            this.label6.Text = "Page Size";
            // 
            // VirtAddressingCheckBox
            // 
            this.VirtAddressingCheckBox.AutoSize = true;
            this.VirtAddressingCheckBox.Checked = true;
            this.VirtAddressingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VirtAddressingCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VirtAddressingCheckBox.Location = new System.Drawing.Point(469, 363);
            this.VirtAddressingCheckBox.Name = "VirtAddressingCheckBox";
            this.VirtAddressingCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VirtAddressingCheckBox.Size = new System.Drawing.Size(153, 24);
            this.VirtAddressingCheckBox.TabIndex = 172;
            this.VirtAddressingCheckBox.Text = "Virtual Addresses";
            this.VirtAddressingCheckBox.UseVisualStyleBackColor = true;
            this.VirtAddressingCheckBox.CheckedChanged += new System.EventHandler(this.catchValueChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(726, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 173;
            this.label1.Text = "Number of Sets";
            // 
            // DC_SetSizeBox
            // 
            this.DC_SetSizeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DC_SetSizeBox.FormattingEnabled = true;
            this.DC_SetSizeBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.DC_SetSizeBox.Location = new System.Drawing.Point(657, 125);
            this.DC_SetSizeBox.Name = "DC_SetSizeBox";
            this.DC_SetSizeBox.Size = new System.Drawing.Size(64, 24);
            this.DC_SetSizeBox.TabIndex = 176;
            this.DC_SetSizeBox.Text = "1";
            this.DC_SetSizeBox.SelectedIndexChanged += new System.EventHandler(this.catchValueChange);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(724, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 175;
            this.label7.Text = "Set Size";
            // 
            // DC_LineSizeBox
            // 
            this.DC_LineSizeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DC_LineSizeBox.FormattingEnabled = true;
            this.DC_LineSizeBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256"});
            this.DC_LineSizeBox.Location = new System.Drawing.Point(657, 159);
            this.DC_LineSizeBox.Name = "DC_LineSizeBox";
            this.DC_LineSizeBox.Size = new System.Drawing.Size(64, 24);
            this.DC_LineSizeBox.TabIndex = 178;
            this.DC_LineSizeBox.Text = "16";
            this.DC_LineSizeBox.SelectedIndexChanged += new System.EventHandler(this.catchValueChange);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(724, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 177;
            this.label8.Text = "Line Size";
            // 
            // DC_WriteThroughCheckBox
            // 
            this.DC_WriteThroughCheckBox.AutoSize = true;
            this.DC_WriteThroughCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DC_WriteThroughCheckBox.Location = new System.Drawing.Point(657, 194);
            this.DC_WriteThroughCheckBox.Name = "DC_WriteThroughCheckBox";
            this.DC_WriteThroughCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DC_WriteThroughCheckBox.Size = new System.Drawing.Size(218, 20);
            this.DC_WriteThroughCheckBox.TabIndex = 179;
            this.DC_WriteThroughCheckBox.Text = "Write Through/No Write Allocate";
            this.DC_WriteThroughCheckBox.UseVisualStyleBackColor = true;
            this.DC_WriteThroughCheckBox.CheckedChanged += new System.EventHandler(this.catchValueChange);
            // 
            // L2_WriteThroughCheckBox
            // 
            this.L2_WriteThroughCheckBox.AutoSize = true;
            this.L2_WriteThroughCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L2_WriteThroughCheckBox.Location = new System.Drawing.Point(469, 325);
            this.L2_WriteThroughCheckBox.Name = "L2_WriteThroughCheckBox";
            this.L2_WriteThroughCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.L2_WriteThroughCheckBox.Size = new System.Drawing.Size(218, 20);
            this.L2_WriteThroughCheckBox.TabIndex = 186;
            this.L2_WriteThroughCheckBox.Text = "Write Through/No Write Allocate";
            this.L2_WriteThroughCheckBox.UseVisualStyleBackColor = true;
            this.L2_WriteThroughCheckBox.CheckedChanged += new System.EventHandler(this.catchValueChange);
            // 
            // L2_LineSizeBox
            // 
            this.L2_LineSizeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L2_LineSizeBox.FormattingEnabled = true;
            this.L2_LineSizeBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.L2_LineSizeBox.Location = new System.Drawing.Point(469, 290);
            this.L2_LineSizeBox.Name = "L2_LineSizeBox";
            this.L2_LineSizeBox.Size = new System.Drawing.Size(64, 24);
            this.L2_LineSizeBox.TabIndex = 185;
            this.L2_LineSizeBox.Text = "16";
            this.L2_LineSizeBox.SelectedIndexChanged += new System.EventHandler(this.catchValueChange);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(536, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 16);
            this.label9.TabIndex = 184;
            this.label9.Text = "Line Size";
            // 
            // L2_SetSizeBox
            // 
            this.L2_SetSizeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L2_SetSizeBox.FormattingEnabled = true;
            this.L2_SetSizeBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.L2_SetSizeBox.Location = new System.Drawing.Point(469, 256);
            this.L2_SetSizeBox.Name = "L2_SetSizeBox";
            this.L2_SetSizeBox.Size = new System.Drawing.Size(64, 24);
            this.L2_SetSizeBox.TabIndex = 183;
            this.L2_SetSizeBox.Text = "4";
            this.L2_SetSizeBox.SelectedIndexChanged += new System.EventHandler(this.catchValueChange);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(536, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 182;
            this.label10.Text = "Set Size";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(538, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 16);
            this.label11.TabIndex = 180;
            this.label11.Text = "Number of Sets";
            // 
            // TLB_SetSizeBox
            // 
            this.TLB_SetSizeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLB_SetSizeBox.FormattingEnabled = true;
            this.TLB_SetSizeBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.TLB_SetSizeBox.Location = new System.Drawing.Point(657, 288);
            this.TLB_SetSizeBox.Name = "TLB_SetSizeBox";
            this.TLB_SetSizeBox.Size = new System.Drawing.Size(64, 24);
            this.TLB_SetSizeBox.TabIndex = 190;
            this.TLB_SetSizeBox.Text = "1";
            this.TLB_SetSizeBox.SelectedIndexChanged += new System.EventHandler(this.catchValueChange);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(724, 293);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 189;
            this.label12.Text = "Set Size";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(726, 260);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 16);
            this.label13.TabIndex = 187;
            this.label13.Text = "Number of Sets";
            // 
            // DC_NumOfSetsBox
            // 
            this.DC_NumOfSetsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DC_NumOfSetsBox.FormattingEnabled = true;
            this.DC_NumOfSetsBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8"});
            this.DC_NumOfSetsBox.Location = new System.Drawing.Point(657, 91);
            this.DC_NumOfSetsBox.Name = "DC_NumOfSetsBox";
            this.DC_NumOfSetsBox.Size = new System.Drawing.Size(64, 24);
            this.DC_NumOfSetsBox.TabIndex = 191;
            this.DC_NumOfSetsBox.Text = "4";
            this.DC_NumOfSetsBox.SelectedIndexChanged += new System.EventHandler(this.catchValueChange);
            // 
            // TLB_NumOfSetsBox
            // 
            this.TLB_NumOfSetsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLB_NumOfSetsBox.FormattingEnabled = true;
            this.TLB_NumOfSetsBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16"});
            this.TLB_NumOfSetsBox.Location = new System.Drawing.Point(657, 256);
            this.TLB_NumOfSetsBox.Name = "TLB_NumOfSetsBox";
            this.TLB_NumOfSetsBox.Size = new System.Drawing.Size(64, 24);
            this.TLB_NumOfSetsBox.TabIndex = 192;
            this.TLB_NumOfSetsBox.Text = "2";
            this.TLB_NumOfSetsBox.SelectedIndexChanged += new System.EventHandler(this.catchValueChange);
            // 
            // L2_NumOfSetsBox
            // 
            this.L2_NumOfSetsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L2_NumOfSetsBox.FormattingEnabled = true;
            this.L2_NumOfSetsBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16"});
            this.L2_NumOfSetsBox.Location = new System.Drawing.Point(469, 222);
            this.L2_NumOfSetsBox.Name = "L2_NumOfSetsBox";
            this.L2_NumOfSetsBox.Size = new System.Drawing.Size(64, 24);
            this.L2_NumOfSetsBox.TabIndex = 193;
            this.L2_NumOfSetsBox.Text = "16";
            this.L2_NumOfSetsBox.SelectedIndexChanged += new System.EventHandler(this.catchValueChange);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.StatsTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(855, 324);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Statistics";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // StatsTextBox
            // 
            this.StatsTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.StatsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatsTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatsTextBox.Location = new System.Drawing.Point(3, 5);
            this.StatsTextBox.Name = "StatsTextBox";
            this.StatsTextBox.ReadOnly = true;
            this.StatsTextBox.Size = new System.Drawing.Size(849, 314);
            this.StatsTextBox.TabIndex = 1;
            this.StatsTextBox.Text = "";
            // 
            // MemSimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 746);
            this.Controls.Add(this.L2_NumOfSetsBox);
            this.Controls.Add(this.TLB_NumOfSetsBox);
            this.Controls.Add(this.DC_NumOfSetsBox);
            this.Controls.Add(this.TLB_SetSizeBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.L2_WriteThroughCheckBox);
            this.Controls.Add(this.L2_LineSizeBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.L2_SetSizeBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DC_WriteThroughCheckBox);
            this.Controls.Add(this.DC_LineSizeBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DC_SetSizeBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VirtAddressingCheckBox);
            this.Controls.Add(this.PT_PageSizeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PT_PPBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PT_VPBox);
            this.Controls.Add(this.PT_VP_Label);
            this.Controls.Add(this.L2CacheCheckBox);
            this.Controls.Add(this.TLB_Checkbox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.outputTabs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MemRefLabel);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.SaveFileButton);
            this.Controls.Add(this.InputFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MemSimForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Hierarchy Simulator";
            this.Load += new System.EventHandler(this.MemSimForm_Load);
            outputBox.ResumeLayout(false);
            this.outputTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InputFileButton;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.RichTextBox InputTextBox;
        private System.Windows.Forms.Label MemRefLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl outputTabs;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.CheckBox TLB_Checkbox;
        private System.Windows.Forms.CheckBox L2CacheCheckBox;
        private System.Windows.Forms.ComboBox PT_VPBox;
        private System.Windows.Forms.Label PT_VP_Label;
        private System.Windows.Forms.ComboBox PT_PPBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox PT_PageSizeBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox VirtAddressingCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DC_SetSizeBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox DC_LineSizeBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox DC_WriteThroughCheckBox;
        private System.Windows.Forms.CheckBox L2_WriteThroughCheckBox;
        private System.Windows.Forms.ComboBox L2_LineSizeBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox L2_SetSizeBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox TLB_SetSizeBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox DC_NumOfSetsBox;
        private System.Windows.Forms.ComboBox TLB_NumOfSetsBox;
        private System.Windows.Forms.ComboBox L2_NumOfSetsBox;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox StatsTextBox;
    }
}

