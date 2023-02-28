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

namespace BS_HWK_WK2_001
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductModel model = new ProductModel();
            var haveData = model.ProductTable.Any(x => x.PID == textBox1.Text.Trim());
            if (haveData) { MessageBox.Show($"PID {textBox1.Text.Trim()} 資料已經存在"); }
            else
            {
                ProductTable data = new ProductTable()
                {
                    PID = textBox1.Text.Trim(),
                    Name = textBox2.Text.Trim(),
                    Amount = Convert.ToInt32(textBox3.Text.Trim()),
                    Price = Convert.ToDecimal(textBox4.Text.Trim()),
                    Category = textBox5.Text.Trim(),
                };
                try
                {
                    model.ProductTable.Add(data);
                    model.SaveChanges();
                    MessageBox.Show("新增成功");
                    ClearTextBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"發生錯誤 {ex.ToString()}");
                }
            }
            
        }

        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
