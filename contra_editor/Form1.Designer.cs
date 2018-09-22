namespace contra_editor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sample_numb = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_loadmap = new System.Windows.Forms.Button();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.data_ppu1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.data_ppu2 = new System.Windows.Forms.NumericUpDown();
            this.data_sobj = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.data_slen = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_write = new System.Windows.Forms.Button();
            this.data_sid = new System.Windows.Forms.Label();
            this.bt_unsel = new System.Windows.Forms.Button();
            this.bt_savemap = new System.Windows.Forms.Button();
            this.bt_resetmap = new System.Windows.Forms.Button();
            this.bt_resorig = new System.Windows.Forms.Button();
            this.hscb = new System.Windows.Forms.HScrollBar();
            this.bt_glitch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.en_sel = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.ehex1 = new System.Windows.Forms.NumericUpDown();
            this.ehex2 = new System.Windows.Forms.NumericUpDown();
            this.ehex3 = new System.Windows.Forms.NumericUpDown();
            this.bt_ewrite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sample_numb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_ppu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_ppu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_sobj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_slen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.en_sel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ehex1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ehex2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ehex3)).BeginInit();
            this.SuspendLayout();
            // 
            // sample_numb
            // 
            this.sample_numb.Location = new System.Drawing.Point(546, 84);
            this.sample_numb.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.sample_numb.Name = "sample_numb";
            this.sample_numb.Size = new System.Drawing.Size(53, 20);
            this.sample_numb.TabIndex = 0;
            this.sample_numb.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(543, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "HEX:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(580, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "00";
            // 
            // bt_loadmap
            // 
            this.bt_loadmap.Location = new System.Drawing.Point(546, 142);
            this.bt_loadmap.Name = "bt_loadmap";
            this.bt_loadmap.Size = new System.Drawing.Size(136, 23);
            this.bt_loadmap.TabIndex = 3;
            this.bt_loadmap.Text = "Load";
            this.bt_loadmap.UseVisualStyleBackColor = true;
            this.bt_loadmap.Click += new System.EventHandler(this.bt_loadmap_Click);
            // 
            // bt_refresh
            // 
            this.bt_refresh.Enabled = false;
            this.bt_refresh.Location = new System.Drawing.Point(546, 200);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(133, 24);
            this.bt_refresh.TabIndex = 6;
            this.bt_refresh.Text = "Refresh";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // data_ppu1
            // 
            this.data_ppu1.Enabled = false;
            this.data_ppu1.Location = new System.Drawing.Point(546, 254);
            this.data_ppu1.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.data_ppu1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.data_ppu1.Name = "data_ppu1";
            this.data_ppu1.Size = new System.Drawing.Size(44, 20);
            this.data_ppu1.TabIndex = 7;
            this.data_ppu1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.data_ppu1.ValueChanged += new System.EventHandler(this.data_ppu1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "PPU Correct";
            // 
            // data_ppu2
            // 
            this.data_ppu2.Enabled = false;
            this.data_ppu2.Location = new System.Drawing.Point(596, 254);
            this.data_ppu2.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.data_ppu2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.data_ppu2.Name = "data_ppu2";
            this.data_ppu2.Size = new System.Drawing.Size(44, 20);
            this.data_ppu2.TabIndex = 7;
            this.data_ppu2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.data_ppu2.ValueChanged += new System.EventHandler(this.data_ppu1_ValueChanged);
            // 
            // data_sobj
            // 
            this.data_sobj.Enabled = false;
            this.data_sobj.Location = new System.Drawing.Point(596, 307);
            this.data_sobj.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.data_sobj.Name = "data_sobj";
            this.data_sobj.Size = new System.Drawing.Size(43, 20);
            this.data_sobj.TabIndex = 9;
            this.data_sobj.ValueChanged += new System.EventHandler(this.data_sobj_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(543, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Edit Selected Object";
            // 
            // data_slen
            // 
            this.data_slen.Enabled = false;
            this.data_slen.Location = new System.Drawing.Point(596, 333);
            this.data_slen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.data_slen.Name = "data_slen";
            this.data_slen.Size = new System.Drawing.Size(43, 20);
            this.data_slen.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(543, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(543, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Length";
            // 
            // bt_write
            // 
            this.bt_write.Enabled = false;
            this.bt_write.Location = new System.Drawing.Point(546, 359);
            this.bt_write.Name = "bt_write";
            this.bt_write.Size = new System.Drawing.Size(133, 24);
            this.bt_write.TabIndex = 12;
            this.bt_write.Text = "Write Data";
            this.bt_write.UseVisualStyleBackColor = true;
            this.bt_write.Click += new System.EventHandler(this.bt_write_Click);
            // 
            // data_sid
            // 
            this.data_sid.AutoSize = true;
            this.data_sid.Location = new System.Drawing.Point(647, 289);
            this.data_sid.Name = "data_sid";
            this.data_sid.Size = new System.Drawing.Size(16, 13);
            this.data_sid.TabIndex = 13;
            this.data_sid.Text = "-1";
            // 
            // bt_unsel
            // 
            this.bt_unsel.Enabled = false;
            this.bt_unsel.Location = new System.Drawing.Point(546, 389);
            this.bt_unsel.Name = "bt_unsel";
            this.bt_unsel.Size = new System.Drawing.Size(133, 24);
            this.bt_unsel.TabIndex = 14;
            this.bt_unsel.Text = "Unselect";
            this.bt_unsel.UseVisualStyleBackColor = true;
            this.bt_unsel.Click += new System.EventHandler(this.bt_unsel_Click);
            // 
            // bt_savemap
            // 
            this.bt_savemap.Enabled = false;
            this.bt_savemap.Location = new System.Drawing.Point(546, 171);
            this.bt_savemap.Name = "bt_savemap";
            this.bt_savemap.Size = new System.Drawing.Size(66, 23);
            this.bt_savemap.TabIndex = 3;
            this.bt_savemap.Text = "Save BAK";
            this.bt_savemap.UseVisualStyleBackColor = true;
            this.bt_savemap.Click += new System.EventHandler(this.bt_savemap_Click);
            // 
            // bt_resetmap
            // 
            this.bt_resetmap.Enabled = false;
            this.bt_resetmap.Location = new System.Drawing.Point(618, 171);
            this.bt_resetmap.Name = "bt_resetmap";
            this.bt_resetmap.Size = new System.Drawing.Size(61, 23);
            this.bt_resetmap.TabIndex = 3;
            this.bt_resetmap.Text = "Res BAK";
            this.bt_resetmap.UseVisualStyleBackColor = true;
            this.bt_resetmap.Click += new System.EventHandler(this.bt_resetmap_Click);
            // 
            // bt_resorig
            // 
            this.bt_resorig.Location = new System.Drawing.Point(546, 449);
            this.bt_resorig.Name = "bt_resorig";
            this.bt_resorig.Size = new System.Drawing.Size(133, 24);
            this.bt_resorig.TabIndex = 15;
            this.bt_resorig.Text = "Reset Orig";
            this.bt_resorig.UseVisualStyleBackColor = true;
            this.bt_resorig.Click += new System.EventHandler(this.bt_resorig_Click);
            // 
            // hscb
            // 
            this.hscb.Enabled = false;
            this.hscb.LargeChange = 1;
            this.hscb.Location = new System.Drawing.Point(12, 460);
            this.hscb.Name = "hscb";
            this.hscb.Size = new System.Drawing.Size(513, 16);
            this.hscb.TabIndex = 16;
            this.hscb.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscb_Scroll);
            // 
            // bt_glitch
            // 
            this.bt_glitch.Enabled = false;
            this.bt_glitch.Location = new System.Drawing.Point(546, 419);
            this.bt_glitch.Name = "bt_glitch";
            this.bt_glitch.Size = new System.Drawing.Size(133, 24);
            this.bt_glitch.TabIndex = 15;
            this.bt_glitch.Text = "Check Glitches";
            this.bt_glitch.UseVisualStyleBackColor = true;
            this.bt_glitch.Click += new System.EventHandler(this.bt_glitch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 500);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Enemy";
            // 
            // en_sel
            // 
            this.en_sel.Location = new System.Drawing.Point(54, 498);
            this.en_sel.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.en_sel.Name = "en_sel";
            this.en_sel.Size = new System.Drawing.Size(32, 20);
            this.en_sel.TabIndex = 18;
            this.en_sel.ValueChanged += new System.EventHandler(this.en_sel_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 500);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Data (more info in enemy_data.txt)";
            // 
            // ehex1
            // 
            this.ehex1.Hexadecimal = true;
            this.ehex1.Location = new System.Drawing.Point(266, 498);
            this.ehex1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ehex1.Name = "ehex1";
            this.ehex1.Size = new System.Drawing.Size(32, 20);
            this.ehex1.TabIndex = 20;
            // 
            // ehex2
            // 
            this.ehex2.Hexadecimal = true;
            this.ehex2.Location = new System.Drawing.Point(304, 498);
            this.ehex2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ehex2.Name = "ehex2";
            this.ehex2.Size = new System.Drawing.Size(32, 20);
            this.ehex2.TabIndex = 20;
            // 
            // ehex3
            // 
            this.ehex3.Hexadecimal = true;
            this.ehex3.Location = new System.Drawing.Point(342, 498);
            this.ehex3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ehex3.Name = "ehex3";
            this.ehex3.Size = new System.Drawing.Size(32, 20);
            this.ehex3.TabIndex = 20;
            // 
            // bt_ewrite
            // 
            this.bt_ewrite.Location = new System.Drawing.Point(380, 498);
            this.bt_ewrite.Name = "bt_ewrite";
            this.bt_ewrite.Size = new System.Drawing.Size(128, 20);
            this.bt_ewrite.TabIndex = 21;
            this.bt_ewrite.Text = "Write Enemy Data";
            this.bt_ewrite.UseVisualStyleBackColor = true;
            this.bt_ewrite.Click += new System.EventHandler(this.bt_ewrite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 529);
            this.Controls.Add(this.bt_ewrite);
            this.Controls.Add(this.ehex3);
            this.Controls.Add(this.ehex2);
            this.Controls.Add(this.ehex1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.en_sel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hscb);
            this.Controls.Add(this.bt_glitch);
            this.Controls.Add(this.bt_resorig);
            this.Controls.Add(this.bt_unsel);
            this.Controls.Add(this.data_sid);
            this.Controls.Add(this.bt_write);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.data_slen);
            this.Controls.Add(this.data_sobj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.data_ppu2);
            this.Controls.Add(this.data_ppu1);
            this.Controls.Add(this.bt_refresh);
            this.Controls.Add(this.bt_resetmap);
            this.Controls.Add(this.bt_savemap);
            this.Controls.Add(this.bt_loadmap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sample_numb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contra Editor 0.33 Alpha (Without level 2 and 4)";
            ((System.ComponentModel.ISupportInitialize)(this.sample_numb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_ppu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_ppu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_sobj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_slen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.en_sel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ehex1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ehex2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ehex3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown sample_numb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_loadmap;
        private System.Windows.Forms.Button bt_refresh;
        private System.Windows.Forms.NumericUpDown data_ppu1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown data_ppu2;
        private System.Windows.Forms.NumericUpDown data_sobj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown data_slen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_write;
        private System.Windows.Forms.Label data_sid;
        private System.Windows.Forms.Button bt_unsel;
        private System.Windows.Forms.Button bt_savemap;
        private System.Windows.Forms.Button bt_resetmap;
        private System.Windows.Forms.Button bt_resorig;
        private System.Windows.Forms.HScrollBar hscb;
        private System.Windows.Forms.Button bt_glitch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown en_sel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown ehex1;
        private System.Windows.Forms.NumericUpDown ehex2;
        private System.Windows.Forms.NumericUpDown ehex3;
        private System.Windows.Forms.Button bt_ewrite;

    }
}

