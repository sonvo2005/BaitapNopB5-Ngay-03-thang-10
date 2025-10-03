using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace BaitapNopB5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbbPhongChu.Text = "Tahoma";
            cbbCoChu.Text = "14";

            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                cbbPhongChu.Items.Add(font.Name);
            }

            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                cbbCoChu.Items.Add(s);
            }
        }

        // ---------------- MENU ----------------
        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            MessageBox.Show("Tạo văn bản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text file|*.txt|Rich Text|*.rtf|Tất cả|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Path.GetExtension(dlg.FileName).ToLower() == ".rtf")
                        richTextBox1.LoadFile(dlg.FileName, RichTextBoxStreamType.RichText);
                    else
                        richTextBox1.LoadFile(dlg.FileName, RichTextBoxStreamType.PlainText);

                    MessageBox.Show("Tập tin đã được mở thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở tập tin!\nLỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text file|*.txt|Rich Text|*.rtf|Tất cả|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (Path.GetExtension(dlg.FileName).ToLower() == ".rtf")
                        richTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText);
                    else
                        richTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.PlainText);

                    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể lưu văn bản!\nLỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // ---------------- BUTTON ----------------
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            MessageBox.Show("Bạn đã tạo mới văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            lưuNộiDungVănBảnToolStripMenuItem_Click(sender, e);
        }

        private void btnInDam_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle fs = richTextBox1.SelectionFont.Style;
                if (richTextBox1.SelectionFont.Bold)
                    fs &= ~FontStyle.Bold;
                else
                    fs |= FontStyle.Bold;

                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, fs);
            }
        }

        private void btnInNghien_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle fs = richTextBox1.SelectionFont.Style;
                if (richTextBox1.SelectionFont.Italic)
                    fs &= ~FontStyle.Italic;
                else
                    fs |= FontStyle.Italic;

                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, fs);
            }
        }

        private void btnGachChan_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle fs = richTextBox1.SelectionFont.Style;
                if (richTextBox1.SelectionFont.Underline)
                    fs &= ~FontStyle.Underline;
                else
                    fs |= FontStyle.Underline;

                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, fs);
            }
        }

        // ---------------- COMBOBOX ----------------
        private void cbbPhongChu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                string fontName = cbbPhongChu.Text;
                float size = richTextBox1.SelectionFont.Size;
                richTextBox1.SelectionFont = new Font(fontName, size, richTextBox1.SelectionFont.Style);
            }
        }

        private void cbbCoChu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                string fontName = richTextBox1.SelectionFont.FontFamily.Name;
                float size = float.Parse(cbbCoChu.Text);
                richTextBox1.SelectionFont = new Font(fontName, size, richTextBox1.SelectionFont.Style);
            }
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.ShowColor = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = dlg.Font;
                richTextBox1.ForeColor = dlg.Color;
            }
        }
    }
}
