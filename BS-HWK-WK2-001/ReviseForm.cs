using BS_HWK_WK2_001.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_HWK_WK2_001
{
    public partial class ReviseForm : Form
    {
        public ReviseForm()
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

                var item = model.ProductTable.OrderBy(x => x.PID == textBox1.Text.ToString());

                foreach (var x in item)
                {
                    textBox2.Text = x.Name;
                    textBox3.Text = x.Amount.ToString();
                    textBox4.Text = x.Price.ToString();
                    textBox5.Text = x.Category;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var model = new ProductModel();
            
            if (!model.ProductTable.Any(x => x.PID == textBox1.Text.ToString()))
            {
                MessageBox.Show("查無此PID商品");
            }
            else
            {
                //label7.Text = "";

                var result = model.ProductTable.FirstOrDefault(x => x.PID == textBox1.Text);
                
                if (result != null)
                {
                    result.Name = textBox2.Text;
                    result.Amount = Convert.ToInt32(textBox3.Text);
                    result.Price = Convert.ToDecimal(textBox4.Text);
                    result.Category = textBox5.Text;
                    model.SaveChanges();
                    MessageBox.Show($"資料修改成功，請回到主畫面查看資料", "系統訊息",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"資料庫內找不到您要修改的資料，請再次搜尋!", "注意",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }               
            }
        }
    }
}
