using BS_HWK_WK2_001.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BS_HWK_WK2_001
{
    public partial class DeletForm : Form
    {
        public DeletForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var model = new ProductModel();

            if (!model.ProductTable.Any(x => x.PID == textBox1.Text.ToString()))
            {
                label7.Text = "查無此PID商品";
            }
            else
            {
                label7.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var model = new ProductModel();

            var PID = textBox1.Text.ToString();
            var item = model.ProductTable.Any(x => x.PID == PID);

            if(!item)
            {
                MessageBox.Show($"無此{PID}資料");
            }
            else
            {
                var msgBox = MessageBox.Show($"請問要刪除嗎?\n{PID}所有資料將刪除", "" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                var result = model.ProductTable.FirstOrDefault(x => x.PID == textBox1.Text);
                if (msgBox == DialogResult.Yes)
                {
                    model.ProductTable.Remove(result);
                    model.SaveChanges();
                    MessageBox.Show("刪除成功");
                }
            }
        }
    }
}
