namespace WorldBeehive.WinFormApp
{
    partial class DashboardForm
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
            this.btnSimulation = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.BeeSelectorLabel = new System.Windows.Forms.Label();
            this.FlowersSelectorLabel = new System.Windows.Forms.Label();
            this.PollenSelectorLabel = new System.Windows.Forms.Label();
            this.BeesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FlowersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pollenNumberComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FramesRateLabelNumber = new System.Windows.Forms.Label();
            this.FramesRunLabelNumber = new System.Windows.Forms.Label();
            this.FieldNectarLabelNumber = new System.Windows.Forms.Label();
            this.HiveHoneyLabelNumber = new System.Windows.Forms.Label();
            this.FlowerLabelNumber = new System.Windows.Forms.Label();
            this.BeeLabel = new System.Windows.Forms.Label();
            this.FlowerLabel = new System.Windows.Forms.Label();
            this.HoneyInHivelabel = new System.Windows.Forms.Label();
            this.TotalNectarInFieldLabel = new System.Windows.Forms.Label();
            this.FramesRunLabel = new System.Windows.Forms.Label();
            this.FramesRateLabel = new System.Windows.Forms.Label();
            this.BeesLabelNumber = new System.Windows.Forms.Label();
            this.StatusBeeListBox = new System.Windows.Forms.ListBox();
            this.StatusFlowerListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.BeesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlowersNumericUpDown)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSimulation
            // 
            this.btnSimulation.Location = new System.Drawing.Point(31, 3);
            this.btnSimulation.Name = "btnSimulation";
            this.btnSimulation.Size = new System.Drawing.Size(130, 23);
            this.btnSimulation.TabIndex = 0;
            this.btnSimulation.UseVisualStyleBackColor = true;
            this.btnSimulation.Click += new System.EventHandler(this.btnSimulation_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(170, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(67, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // BeeSelectorLabel
            // 
            this.BeeSelectorLabel.AutoSize = true;
            this.BeeSelectorLabel.Location = new System.Drawing.Point(22, 37);
            this.BeeSelectorLabel.Name = "BeeSelectorLabel";
            this.BeeSelectorLabel.Size = new System.Drawing.Size(172, 13);
            this.BeeSelectorLabel.TabIndex = 2;
            this.BeeSelectorLabel.Text = "Select Max number of bees in Field";
            // 
            // FlowersSelectorLabel
            // 
            this.FlowersSelectorLabel.AutoSize = true;
            this.FlowersSelectorLabel.Location = new System.Drawing.Point(22, 62);
            this.FlowersSelectorLabel.Name = "FlowersSelectorLabel";
            this.FlowersSelectorLabel.Size = new System.Drawing.Size(182, 13);
            this.FlowersSelectorLabel.TabIndex = 3;
            this.FlowersSelectorLabel.Text = "Select Max number of flowers in Field";
            // 
            // PollenSelectorLabel
            // 
            this.PollenSelectorLabel.AutoSize = true;
            this.PollenSelectorLabel.Location = new System.Drawing.Point(22, 87);
            this.PollenSelectorLabel.Name = "PollenSelectorLabel";
            this.PollenSelectorLabel.Size = new System.Drawing.Size(156, 13);
            this.PollenSelectorLabel.TabIndex = 4;
            this.PollenSelectorLabel.Text = "Pollen Required For a New Bee";
            // 
            // BeesNumericUpDown
            // 
            this.BeesNumericUpDown.Location = new System.Drawing.Point(217, 32);
            this.BeesNumericUpDown.Name = "BeesNumericUpDown";
            this.BeesNumericUpDown.Size = new System.Drawing.Size(39, 20);
            this.BeesNumericUpDown.TabIndex = 5;
            // 
            // FlowersNumericUpDown
            // 
            this.FlowersNumericUpDown.Location = new System.Drawing.Point(217, 58);
            this.FlowersNumericUpDown.Name = "FlowersNumericUpDown";
            this.FlowersNumericUpDown.Size = new System.Drawing.Size(39, 20);
            this.FlowersNumericUpDown.TabIndex = 6;
            // 
            // pollenNumberComboBox
            // 
            this.pollenNumberComboBox.FormattingEnabled = true;
            this.pollenNumberComboBox.Location = new System.Drawing.Point(217, 84);
            this.pollenNumberComboBox.Name = "pollenNumberComboBox";
            this.pollenNumberComboBox.Size = new System.Drawing.Size(77, 21);
            this.pollenNumberComboBox.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.FramesRateLabelNumber, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.FramesRunLabelNumber, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.FieldNectarLabelNumber, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.HiveHoneyLabelNumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.FlowerLabelNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.BeeLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FlowerLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.HoneyInHivelabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TotalNectarInFieldLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.FramesRunLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.FramesRateLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.BeesLabelNumber, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 111);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(356, 133);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // FramesRateLabelNumber
            // 
            this.FramesRateLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FramesRateLabelNumber.AutoSize = true;
            this.FramesRateLabelNumber.Location = new System.Drawing.Point(181, 116);
            this.FramesRateLabelNumber.Name = "FramesRateLabelNumber";
            this.FramesRateLabelNumber.Size = new System.Drawing.Size(67, 13);
            this.FramesRateLabelNumber.TabIndex = 11;
            this.FramesRateLabelNumber.Text = "Frames Rate";
            // 
            // FramesRunLabelNumber
            // 
            this.FramesRunLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FramesRunLabelNumber.AutoSize = true;
            this.FramesRunLabelNumber.Location = new System.Drawing.Point(181, 95);
            this.FramesRunLabelNumber.Name = "FramesRunLabelNumber";
            this.FramesRunLabelNumber.Size = new System.Drawing.Size(64, 13);
            this.FramesRunLabelNumber.TabIndex = 10;
            this.FramesRunLabelNumber.Text = "Frames Run";
            // 
            // FieldNectarLabelNumber
            // 
            this.FieldNectarLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FieldNectarLabelNumber.AutoSize = true;
            this.FieldNectarLabelNumber.Location = new System.Drawing.Point(181, 75);
            this.FieldNectarLabelNumber.Name = "FieldNectarLabelNumber";
            this.FieldNectarLabelNumber.Size = new System.Drawing.Size(64, 13);
            this.FieldNectarLabelNumber.TabIndex = 9;
            this.FieldNectarLabelNumber.Text = "Field Nectar";
            // 
            // HiveHoneyLabelNumber
            // 
            this.HiveHoneyLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HiveHoneyLabelNumber.AutoSize = true;
            this.HiveHoneyLabelNumber.Location = new System.Drawing.Point(181, 53);
            this.HiveHoneyLabelNumber.Name = "HiveHoneyLabelNumber";
            this.HiveHoneyLabelNumber.Size = new System.Drawing.Size(63, 13);
            this.HiveHoneyLabelNumber.TabIndex = 8;
            this.HiveHoneyLabelNumber.Text = "Hive Honey";
            // 
            // FlowerLabelNumber
            // 
            this.FlowerLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FlowerLabelNumber.AutoSize = true;
            this.FlowerLabelNumber.Location = new System.Drawing.Point(181, 29);
            this.FlowerLabelNumber.Name = "FlowerLabelNumber";
            this.FlowerLabelNumber.Size = new System.Drawing.Size(43, 13);
            this.FlowerLabelNumber.TabIndex = 7;
            this.FlowerLabelNumber.Text = "Flowers";
            // 
            // BeeLabel
            // 
            this.BeeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BeeLabel.AutoSize = true;
            this.BeeLabel.Location = new System.Drawing.Point(3, 5);
            this.BeeLabel.Name = "BeeLabel";
            this.BeeLabel.Size = new System.Drawing.Size(41, 13);
            this.BeeLabel.TabIndex = 0;
            this.BeeLabel.Text = "# Bees";
            // 
            // FlowerLabel
            // 
            this.FlowerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FlowerLabel.AutoSize = true;
            this.FlowerLabel.Location = new System.Drawing.Point(3, 29);
            this.FlowerLabel.Name = "FlowerLabel";
            this.FlowerLabel.Size = new System.Drawing.Size(53, 13);
            this.FlowerLabel.TabIndex = 1;
            this.FlowerLabel.Text = "# Flowers";
            // 
            // HoneyInHivelabel
            // 
            this.HoneyInHivelabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HoneyInHivelabel.AutoSize = true;
            this.HoneyInHivelabel.Location = new System.Drawing.Point(3, 53);
            this.HoneyInHivelabel.Name = "HoneyInHivelabel";
            this.HoneyInHivelabel.Size = new System.Drawing.Size(119, 13);
            this.HoneyInHivelabel.TabIndex = 2;
            this.HoneyInHivelabel.Text = "Total Honey in the Hive";
            // 
            // TotalNectarInFieldLabel
            // 
            this.TotalNectarInFieldLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TotalNectarInFieldLabel.AutoSize = true;
            this.TotalNectarInFieldLabel.Location = new System.Drawing.Point(3, 75);
            this.TotalNectarInFieldLabel.Name = "TotalNectarInFieldLabel";
            this.TotalNectarInFieldLabel.Size = new System.Drawing.Size(120, 13);
            this.TotalNectarInFieldLabel.TabIndex = 3;
            this.TotalNectarInFieldLabel.Text = "Total Nectar in the Field";
            // 
            // FramesRunLabel
            // 
            this.FramesRunLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FramesRunLabel.AutoSize = true;
            this.FramesRunLabel.Location = new System.Drawing.Point(3, 95);
            this.FramesRunLabel.Name = "FramesRunLabel";
            this.FramesRunLabel.Size = new System.Drawing.Size(64, 13);
            this.FramesRunLabel.TabIndex = 4;
            this.FramesRunLabel.Text = "Frames Run";
            // 
            // FramesRateLabel
            // 
            this.FramesRateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FramesRateLabel.AutoSize = true;
            this.FramesRateLabel.Location = new System.Drawing.Point(3, 116);
            this.FramesRateLabel.Name = "FramesRateLabel";
            this.FramesRateLabel.Size = new System.Drawing.Size(67, 13);
            this.FramesRateLabel.TabIndex = 5;
            this.FramesRateLabel.Text = "Frames Rate";
            // 
            // BeesLabelNumber
            // 
            this.BeesLabelNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BeesLabelNumber.AutoSize = true;
            this.BeesLabelNumber.Location = new System.Drawing.Point(181, 5);
            this.BeesLabelNumber.Name = "BeesLabelNumber";
            this.BeesLabelNumber.Size = new System.Drawing.Size(31, 13);
            this.BeesLabelNumber.TabIndex = 6;
            this.BeesLabelNumber.Text = "Bees";
            // 
            // StatusBeeListBox
            // 
            this.StatusBeeListBox.FormattingEnabled = true;
            this.StatusBeeListBox.Location = new System.Drawing.Point(4, 250);
            this.StatusBeeListBox.Name = "StatusBeeListBox";
            this.StatusBeeListBox.Size = new System.Drawing.Size(357, 95);
            this.StatusBeeListBox.TabIndex = 9;
            // 
            // StatusFlowerListBox
            // 
            this.StatusFlowerListBox.FormattingEnabled = true;
            this.StatusFlowerListBox.Location = new System.Drawing.Point(3, 351);
            this.StatusFlowerListBox.Name = "StatusFlowerListBox";
            this.StatusFlowerListBox.Size = new System.Drawing.Size(358, 95);
            this.StatusFlowerListBox.TabIndex = 10;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 463);
            this.Controls.Add(this.StatusFlowerListBox);
            this.Controls.Add(this.StatusBeeListBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pollenNumberComboBox);
            this.Controls.Add(this.FlowersNumericUpDown);
            this.Controls.Add(this.BeesNumericUpDown);
            this.Controls.Add(this.PollenSelectorLabel);
            this.Controls.Add(this.FlowersSelectorLabel);
            this.Controls.Add(this.BeeSelectorLabel);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSimulation);
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            ((System.ComponentModel.ISupportInitialize)(this.BeesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlowersNumericUpDown)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSimulation;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label BeeSelectorLabel;
        private System.Windows.Forms.Label FlowersSelectorLabel;
        private System.Windows.Forms.Label PollenSelectorLabel;
        private System.Windows.Forms.NumericUpDown BeesNumericUpDown;
        private System.Windows.Forms.NumericUpDown FlowersNumericUpDown;
        private System.Windows.Forms.ComboBox pollenNumberComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox StatusBeeListBox;
        private System.Windows.Forms.ListBox StatusFlowerListBox;
        private System.Windows.Forms.Label BeeLabel;
        private System.Windows.Forms.Label FlowerLabel;
        private System.Windows.Forms.Label HoneyInHivelabel;
        private System.Windows.Forms.Label TotalNectarInFieldLabel;
        private System.Windows.Forms.Label FramesRunLabel;
        private System.Windows.Forms.Label FramesRateLabel;
        private System.Windows.Forms.Label BeesLabelNumber;
        private System.Windows.Forms.Label FramesRateLabelNumber;
        private System.Windows.Forms.Label FramesRunLabelNumber;
        private System.Windows.Forms.Label FieldNectarLabelNumber;
        private System.Windows.Forms.Label HiveHoneyLabelNumber;
        private System.Windows.Forms.Label FlowerLabelNumber;
    }
}