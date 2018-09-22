using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace contra_editor
{
    public partial class Form1 : Form
    {
        void SplashScreen()
        {
            if (File.Exists(splashfile))
            {
                Form splash = new Form();
                splash.StartPosition = FormStartPosition.CenterScreen;
                splash.FormBorderStyle = FormBorderStyle.None;
                splash.Size = new Size(640, 480);
                splash.BackgroundImage = new Bitmap(splashfile);
                splash.Show();
                System.Threading.Thread.Sleep(1000);
                splash.Dispose();
            }
        }

        public Form1()
        {
            SplashScreen();
            InitializeComponent();
            Init();
        }

        //Trying to make clearest code
        const string workdir = "data\\";
        const string nesgamefile = "Contra.nes";
        const string backupfile = workdir + nesgamefile + ".bak";
        const string originalfile = workdir + nesgamefile + ".dat";
        const string splashfile = workdir + "splash.png";
        const string palfile = workdir + "pal";
        uint testaddress = 0x802D;

        const uint level_1 = 0x802D;
        const uint level_3 = 0x84F4;
        //Need multiple addresses because of tank boss
        const uint level_5 = 0x86CB;
        //Only last 1 or 2 screen has problems
        const uint level_6 = 0x8951;
        const uint level_7 = 0x8BB1;
        //Need multiple addresses because first boss
        const uint level_8 = 0x8E6F;

        //Pattern addresses
        const uint pattern_1 = 0xC011;
        const uint pattern_3 = 0xCF08;
        const uint pattern_5 = 0xD6A8;
        const uint pattern_6 = 0xDE2E;
        const uint pattern_7 = 0xE5BA;
        const uint pattern_8 = 0xEDDA;

        //Max pictures in palette
        const int MAX_PICS = 256;
        //Max pictures col,row
        const int MAX_X = 32, MAX_Y = 28;
        //Generation loc,size
        const int x = 12, y = 12;
        const int width = 16, height = 16;
        //Palette img sizes
        const int wt = 16, wh = 16;
        //Max combined blocks
        const int MAX_SBLOCKS = 56;
        const int MAX_BLOCKS = MAX_SBLOCKS * MAX_SCENE;
        //Max scenes
        const int MAX_SCENE = 15;

        //Temporary global integers
        int tmp = 0, tmp2 = 0;
        //Temporary uint (hex addresses)
        uint tmpaddr = 0x0;

        //Store map into memory
        int[] data = new int[MAX_BLOCKS];
        int[] data_spec = new int[MAX_BLOCKS];
        int selid = -1;

        //Compare integers
        int cmp1 = 0;
        int cmp2 = 0;

        //Repeat for generations
        int repeat = 0;

        //Palette combinations
        int[,] picnum = new int[MAX_PICS, 16];

        //Graphics variables
        PictureBox[,] tile = new PictureBox[MAX_X, MAX_Y];
        PictureBox[] sample = new PictureBox[16];
        Graphics pixel;
        Bitmap gamepic;
        Bitmap[] tile_game = new Bitmap[MAX_PICS];

        //Enemy data
        const int MAX_EX = 8;
        const int MAX_EY = 7;

        const int ex = 44, ey = 44;
        const int eoffst = 64;

        const int MAX_ENEMY_DATA = 32;
        const int EDATA_LENGTH = 3;

        const uint enemy_1 = 0x0B855;
        const uint enemy_2 = 0x0B8C6;
        const uint enemy_3 = 0x0B931;
        const uint enemy_4 = 0x0;
        const uint enemy_5 = 0x0BA84;
        const uint enemy_6 = 0x0BB4E;
        const uint enemy_7 = 0x0BBE5;
        const uint enemy_8 = 0x0;

        int[,] edata = new int[MAX_ENEMY_DATA, EDATA_LENGTH];
        List<uint> edata_skip = new List<uint>();

        public static bool RunChecks()
        {
            bool ret = false;
            string fname = palfile + "11.png";
            if (ret |= !File.Exists(fname))
                MessageBox.Show(fname + " not found!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (ret |= !File.Exists(nesgamefile))
                MessageBox.Show(nesgamefile + " not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            return ret;
        }

        private void Init()
        {
            if (!File.Exists(originalfile))
                File.Copy(nesgamefile, originalfile);
            gamepic = new Bitmap(palfile + "11.png");
            for (int i = 0; i < MAX_X; i++)
            {
                for (int i2 = 0; i2 < MAX_Y; i2++)
                {
                    tile[i, i2] = new PictureBox();
                    tile[i, i2].Location = new Point(x + wt * tmp2, y + wh * tmp);
                    tile[i, i2].Size = new Size(wt, wh);
                    tile[i, i2].BackColor = Color.White;
                    tile[i, i2].SizeMode = PictureBoxSizeMode.StretchImage;
                    tile[i, i2].Click += new EventHandler(Form1_Click);
                    Controls.Add(tile[i, i2]);
                    tmp += 1;
                    if (tmp >= MAX_Y)
                    {
                        tmp = 0;
                        tmp2 += 1;
                    }
                }
            }
            tmp = 0;
            tmp2 = 0;
            for (int i = 0; i < 16; i++)
            {
                sample[i] = new PictureBox();
                sample[i].Location = new Point(542 + wt * tmp, y + wh * tmp2);
                sample[i].Size = new Size(wt, wh);
                sample[i].BackColor = Color.White;
                sample[i].SizeMode = PictureBoxSizeMode.StretchImage;
                Controls.Add(sample[i]);
                tmp += 1;
                if (tmp >= 4)
                {
                    tmp = 0;
                    tmp2 += 1;
                }
            }
            tmp = 0;
            tmp2 = 0;
            for (int i = 0; i < MAX_PICS; i++)
            {
                Bitmap pic_proc = new Bitmap(width, width);
                pixel = Graphics.FromImage(pic_proc);
                pixel.DrawImage(gamepic, new Rectangle(0, 0, width, width), width * tmp, height * tmp2, width, width, GraphicsUnit.Pixel);
                tile_game[i] = pic_proc;
                tmp += 1;
                if (tmp >= wt)
                {
                    tmp = 0;
                    tmp2 += 1;
                }
            }
            LoadPattern(1);
        }

        private void LoadPattern(int pid)
        {
            StartReadBytes(nesgamefile);
            if (pid == 1) tmpaddr = pattern_1;
            else if (pid == 3) tmpaddr = pattern_3;
            else if (pid == 5) tmpaddr = pattern_5;
            else if (pid == 6) tmpaddr = pattern_6;
            else if (pid == 7) tmpaddr = pattern_7;
            else if (pid == 8) tmpaddr = pattern_8;
            for (int i = 0; i < MAX_PICS; i++)
            {
                for (int i2 = 0; i2 < 16; i2++)
                {
                    picnum[i, i2] = ReadByte(tmpaddr);
                    tmpaddr += 0x1;
                }
            }
            CloseReadBytes();
            DrawComplexImage2(0);
        }

        private void SetEnemyDataPos(int level)
        {
            if (level == 1) tmpaddr = enemy_1;
            if (level == 2) tmpaddr = enemy_2;
            if (level == 3) tmpaddr = enemy_3;
            if (level == 5) tmpaddr = enemy_5;
            if (level == 6) tmpaddr = enemy_6;
            if (level == 7) tmpaddr = enemy_7;
        }

        private void LoadEnemyData(int level)
        {
            edata_skip.Clear();
            SetEnemyDataPos(level);
            StartReadBytes(nesgamefile);
            for (int i = 0; i < MAX_ENEMY_DATA; i++)
            {
                for (int i2 = 0; i2 < EDATA_LENGTH; )
                {
                    int tmp = ReadByte(tmpaddr);
                    if (tmp == 255) edata_skip.Add(tmpaddr);
                    else
                    {
                        edata[i, i2] = tmp;
                        i2++;
                    }
                    tmpaddr += 0x1;
                }
            }
            CloseReadBytes();
            ReadEnemyHEX();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (!bt_loadmap.Enabled && ((PictureBox)sender).Image == null)
            {
                for (int i = 0; i < MAX_X; i++)
                {
                    for (int i2 = 0; i2 < MAX_Y; i2++)
                    {
                        if (tile[i, i2].BackColor == Color.Blue)
                            tile[i, i2].BackColor = Color.White;
                        else continue;
                    }
                }

                for (int i = 0; i < MAX_X; i++)
                {
                    for (int i2 = 0; i2 < MAX_Y; i2++)
                    {
                        if (sender == tile[i, i2])
                        {
                            if (tile[i, i2].Image == null)
                            {
                                tile[i, i2].BackColor = Color.Blue;
                                selid = (56 * hscb.Value) + (i / 4 + (8 * i2 / 4));
                                data_sid.Text = selid.ToString();
                                data_sobj.Enabled = true;
                                data_sobj.Value = data[selid];
                                data_slen.Enabled = true;
                                data_slen.Value = data_spec[selid];
                                bt_write.Enabled = true;
                                bt_unsel.Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        private void DrawComplexImage(int id, int tnum, int tnum2, bool editable)
        {
            int m1 = 0, m2 = 0;
            for (int i = 0; i < 16; i++)
            {
                tile[tnum + m1, tnum2 + m2].Image = tile_game[picnum[id, i]];
                m1 += 1;
                if (m1 >= 4)
                {
                    m1 = 0;
                    m2 += 1;
                }
            }
            if (editable)
                tile[tnum, tnum2].Image = null;
        }

        private int GetComplexImageLength(int id)
        {
            tmp = 0;
            tmp2 = 0;
            for (int i = 0; i < id; i++)
            {
                tmp += 4;
                if (tmp >= 32)
                {
                    tmp = 0;
                    tmp2 += 4;
                }
            }
            if (tile[tmp, tmp2].Image == null)
            {
                for (int i = 0; i < id; i++)
                {
                    tmp += 4;
                    if (tmp >= 32)
                    {
                        tmp = 0;
                        tmp2 += 4;
                    }
                    if (tile[tmp, tmp2].Image == null)
                        return i + 1;
                }
                return -1;
            }
            else return 0;
        }

        private void ChangeLevel(int numb, int numb2, int value)
        {
            numb = (numb + numb * numb2) / 2;
            data[numb] = value;
        }

        private void DrawComplexImage2(int id)
        {
            for (int i = 0; i < 16; i++)
            {
                sample[i].Image = tile_game[picnum[id, i]];
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            DrawComplexImage2((int)sample_numb.Value);
            data_sobj.Value = sample_numb.Value;

            if (sample_numb.Value < 16)
                label2.Text = "0" + ((uint)sample_numb.Value).ToString("X");
            else
                label2.Text = ((uint)sample_numb.Value).ToString("X");
        }

        private void bt_loadmap_Click(object sender, EventArgs e)
        {
            ReLoad(testaddress);
            LoadScene(hscb.Value, testaddress);
            LoadEnemyData((int)data_ppu1.Value);
            bt_loadmap.Enabled = false;
            bt_refresh.Enabled = true;
            bt_glitch.Enabled = true;
            data_ppu1.Enabled = true;
            data_ppu2.Enabled = true;
            bt_savemap.Enabled = true;
            bt_resetmap.Enabled = true;
            hscb.Enabled = true;
        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            ReLoad(testaddress);
            LoadScene(hscb.Value, testaddress);
        }

        private void ReLoad(uint address)
        {
            StartReadBytes(nesgamefile);
            tmpaddr = address;
            repeat = 0;
            tmp = 0;
            tmp2 = 0;
            for (int i = 0; i < MAX_BLOCKS; i++)
            {
                data[i] = ReadByte(tmpaddr);
                if (data[i] > 0x80 && data[i] < 0x90)
                {
                    data_spec[i] = (int)(data[i] - 0x81);
                    repeat = (int)(data[i] - 0x81);
                    tmpaddr += 0x1;
                    data[i] = ReadByte(tmpaddr);
                }
                else if (repeat > 0)
                {
                    data_spec[i] = 0;
                    repeat -= 1;
                    data[i] = ReadByte(tmpaddr);
                    if (repeat == 0) tmpaddr += 0x1;
                }
                else
                {
                    data_spec[i] = 0;
                    tmpaddr += 0x1;
                }
            }
            hscb.Maximum = MAX_SCENE - 1;
            CloseReadBytes();
        }

        private void ReLoad2(uint address)
        {
            StartReadBytes(originalfile);
            tmpaddr = address;
            repeat = 0;
            tmp = 0;
            tmp2 = 0;
            for (int i = 0; i < MAX_BLOCKS; i++)
            {
                data[i] = ReadByte(tmpaddr);
                if (data[i] > 0x80 && data[i] < 0x90)
                {
                    data_spec[i] = (int)(data[i] - 0x81);
                    repeat = (int)(data[i] - 0x81);
                    tmpaddr += 0x1;
                    data[i] = ReadByte(tmpaddr);
                }
                else if (repeat > 0)
                {
                    data_spec[i] = 0;
                    repeat -= 1;
                    data[i] = ReadByte(tmpaddr);
                    if (repeat == 0) tmpaddr += 0x1;
                }
                else
                {
                    data_spec[i] = 0;
                    tmpaddr += 0x1;
                }
            }
            hscb.Maximum = MAX_SCENE - 1;
            CloseReadBytes();
        }

        private void LoadScene(int push, uint address)
        {
            tmpaddr = address;
            repeat = 0;
            tmp = 0;
            tmp2 = 0;
            for (int i = 0; i < MAX_SBLOCKS; i++)
            {
                if (data_spec[i + MAX_SBLOCKS * push] != 0)
                {
                    repeat = data_spec[i + MAX_SBLOCKS * push];
                    DrawComplexImage(data[i + MAX_SBLOCKS * push], tmp, tmp2, true);
                }
                else if (repeat > 0)
                {
                    repeat -= 1;
                    DrawComplexImage(data[i + MAX_SBLOCKS * push], tmp, tmp2, false);
                }
                else
                    DrawComplexImage(data[i + MAX_SBLOCKS * push], tmp, tmp2, true);

                tmp += 4;
                if (tmp >= 32)
                {
                    tmp = 0;
                    tmp2 += 4;
                }
            }
        }

        private void data_ppu1_ValueChanged(object sender, EventArgs e)
        {
            string pal_file = palfile + (int)data_ppu1.Value + (int)data_ppu2.Value + ".png";
            if (File.Exists(pal_file))
            {
                if (data_ppu1.Value != 2 || data_ppu1.Value != 4)
                {
                    gamepic = new Bitmap(pal_file);
                    tmp = 0;
                    tmp2 = 0;
                    for (int i = 0; i < MAX_PICS; i++)
                    {
                        Bitmap pic_proc = new Bitmap(width, width);
                        pixel = Graphics.FromImage(pic_proc);
                        pixel.DrawImage(gamepic, new Rectangle(0, 0, width, width), width * tmp, height * tmp2, width, width, GraphicsUnit.Pixel);
                        tile_game[i] = pic_proc;
                        tmp += 1;
                        if (tmp >= wt)
                        {
                            tmp = 0;
                            tmp2 += 1;
                        }
                    }
                    LoadPattern((int)data_ppu1.Value);
                    LoadEnemyData((int)data_ppu1.Value);
                    if ((int)data_ppu1.Value == 1)
                    {
                        testaddress = level_1;
                        ReLoad(level_1);
                    }
                    else if ((int)data_ppu1.Value == 3)
                    {
                        testaddress = level_3;
                        ReLoad(level_3);
                    }
                    else if ((int)data_ppu1.Value == 5)
                    {
                        testaddress = level_5;
                        ReLoad(level_5);
                    }
                    else if ((int)data_ppu1.Value == 6)
                    {
                        testaddress = level_6;
                        ReLoad(level_6);
                    }
                    else if ((int)data_ppu1.Value == 7)
                    {
                        testaddress = level_7;
                        ReLoad(level_7);
                    }
                    else if ((int)data_ppu1.Value == 8)
                    {
                        testaddress = level_8;
                        ReLoad(level_8);
                    }
                }
            }
            LoadScene(hscb.Value, testaddress);
        }

        private void bt_write_Click(object sender, EventArgs e)
        {
            StartWriteBytes(nesgamefile);
            tmpaddr = testaddress;
            data[selid] = (int)data_sobj.Value;
            repeat = 0;
            for (int i = 0; i < (MAX_SBLOCKS * (hscb.Value + 1)); i++)
            {
                if (data_spec[i] != 0)
                {
                    repeat = data_spec[i];
                    if ((int)data_slen.Value != 0 && i == selid)
                    {
                        data_spec[selid] = (int)data_slen.Value;
                        WriteBytes(tmpaddr, (int)(data_spec[i] + 0x81));
                        tmpaddr += 0x1;
                    }
                    else if ((int)data_slen.Value == 0 && i == selid) goto end;
                    else
                    {
                        WriteBytes(tmpaddr, (int)(data_spec[i] + 0x81));
                        tmpaddr += 0x1;
                    }
                end:
                    WriteBytes(tmpaddr, data[i]);
                    tmpaddr += 0x1;
                }
                else if (repeat > 0)
                {
                    repeat -= 1;
                    continue;
                }
                else
                {
                    if (i == selid && data_slen.Value != 0)
                    {
                        data_spec[i] = (int)data_slen.Value;
                        WriteBytes(tmpaddr, (int)(data_spec[i] + 0x81));
                        tmpaddr += 0x1;
                        WriteBytes(tmpaddr, data[i]);
                        tmpaddr += 0x1;
                    }
                    else
                    {
                        WriteBytes(tmpaddr, data[i]);
                        tmpaddr += 0x1;
                    }
                }
            }
            CloseWriteBytes();
            ReLoad(testaddress);
            LoadScene(hscb.Value, testaddress);
        }

        private void bt_unsel_Click(object sender, EventArgs e)
        {
            selid = -1;
            data_sid.Text = "-1";
            data_sobj.Value = 0;
            data_sobj.Enabled = false;
            data_slen.Value = 0;
            data_slen.Enabled = false;
            bt_write.Enabled = false;
            bt_unsel.Enabled = false;
            for (int i = 0; i < MAX_X; i++)
            {
                for (int i2 = 0; i2 < MAX_Y; i2++)
                {
                    if (tile[i, i2].BackColor == Color.Blue)
                        tile[i, i2].BackColor = Color.White;
                    else continue;
                }
            }
        }

        private void data_sobj_ValueChanged(object sender, EventArgs e)
        {
            sample_numb.Value = data_sobj.Value;
        }

        private void bt_savemap_Click(object sender, EventArgs e)
        {
            if (File.Exists(nesgamefile))
            {
                if (File.Exists(backupfile))
                {
                    File.Delete(backupfile);
                    File.Copy(workdir + nesgamefile, nesgamefile + ".bak");
                }
                else
                    File.Copy(nesgamefile, backupfile);
                ReLoad(testaddress);
                LoadScene(hscb.Value, testaddress);
                MessageBox.Show("Backup made!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(nesgamefile + " not found!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void bt_resetmap_Click(object sender, EventArgs e)
        {
            if (File.Exists(backupfile))
            {
                if (File.Exists(nesgamefile))
                {
                    File.Delete(nesgamefile);
                    File.Copy(backupfile, nesgamefile);
                }
                else
                    File.Copy(backupfile, nesgamefile);
                ReLoad(testaddress);
                LoadScene(hscb.Value, testaddress);
                MessageBox.Show("Backup restored!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Backup not found!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_resorig_Click(object sender, EventArgs e)
        {
            if (File.Exists(originalfile))
            {
                File.Delete(nesgamefile);
                File.Copy(originalfile, nesgamefile);
                ReLoad(testaddress);
                LoadScene(hscb.Value, testaddress);
                MessageBox.Show("Original restored!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Original file not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void hscb_Scroll(object sender, ScrollEventArgs e)
        {
            LoadScene(hscb.Value, testaddress);
            bt_unsel_Click(sender, e);
        }

        //-----------------------------------UTIL---------------------------------

        FileStream fs;
        BinaryReader br;
        BinaryWriter bw;

        void StartReadBytes(string fileName)
        {
            fs = new FileStream(fileName, FileMode.Open);
            br = new BinaryReader(fs);
        }

        byte ReadByte(uint address)
        {
            br.BaseStream.Position = address;
            return br.ReadByte();
        }

        void CloseReadBytes()
        {
            br.Close();
            fs.Close();
        }

        void StartWriteBytes(string fileName)
        {
            fs = new FileStream(fileName, FileMode.Open);
            bw = new BinaryWriter(fs);
        }

        void WriteBytes(uint address, int numbs)
        {
            bw.BaseStream.Position = address;
            bw.Write((byte)numbs);
        }

        void CloseWriteBytes()
        {
            bw.Close();
            fs.Close();
        }

        private void bt_glitch_Click(object sender, EventArgs e)
        {
            cmp1 = 0;
            cmp2 = 0;
            ReLoad2(testaddress);
            for (int i = 0; i < MAX_SBLOCKS; i++)
            {
                if (data_spec[i + MAX_SBLOCKS * hscb.Value] != 0) cmp1 += 1;
            }
            ReLoad(testaddress);
            for (int i = 0; i < MAX_SBLOCKS; i++)
            {
                if (data_spec[i + MAX_SBLOCKS * hscb.Value] != 0) cmp2 += 1;
            }
            if (cmp1 == cmp2)
                MessageBox.Show("Your map is glitch free!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(
                    "Your map has some glitches!\n" +
                    "Info from current screen:\n" +
                    "Original data:\nNormal: " + (MAX_SBLOCKS - cmp1) + "\nLength: " + cmp1 + "\n\n" +
                    "Your data:\nNormal: " + (MAX_SBLOCKS - cmp2) + "\nLength: " + cmp2 + "\n\n\n" +
                    "Info:\nNormal does not have length (length:0)\nLength does have length (length greater than 0)",
                    "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ReadEnemyHEX()
        {
            ehex1.Value = edata[(int)en_sel.Value, 0];
            ehex2.Value = edata[(int)en_sel.Value, 1];
            ehex3.Value = edata[(int)en_sel.Value, 2];
        }

        private void en_sel_ValueChanged(object sender, EventArgs e)
        {
            ReadEnemyHEX();
        }

        private void bt_ewrite_Click(object sender, EventArgs e)
        {
            StartWriteBytes(nesgamefile);
            SetEnemyDataPos((int)data_ppu1.Value);
            edata[(int)en_sel.Value, 0] = (int)ehex1.Value;
            edata[(int)en_sel.Value, 1] = (int)ehex2.Value;
            edata[(int)en_sel.Value, 2] = (int)ehex3.Value;
            for (int i = 0; i < en_sel.Value + 1; i++)
            {
                for (int i2 = 0; i2 < EDATA_LENGTH; )
                {
                    if (!edata_skip.Contains(tmpaddr))
                    {
                        WriteBytes(tmpaddr, edata[i, i2]);
                        i2++;
                    }
                    tmpaddr += 0x1;
                }
            }
            CloseWriteBytes();
            LoadEnemyData((int)data_ppu1.Value);
        }
    }
}