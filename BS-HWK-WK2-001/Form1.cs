using BS_HWK_WK2_001.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_HWK_WK2_001
{
    public partial class HomeView : Form
    {
        public HomeView()
        {
            InitializeComponent();
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isErr = false;
            var ProductList = new List<Product>();

            string fileName = @"..\..\..\product.csv";
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            using (StreamReader sr = new StreamReader(fs))
            {
                string temp;
                while ((temp = sr.ReadLine()) != null)
                {
                    if (temp != "商品編號,商品名稱,商品數量,價格,商品類別")
                    {
                        string[] list; 
                        list = temp.Split(',');                  

                        var model = new ProductModel();
                        var stemp = list[0];
                        if (!model.ProductTable.Any(x => x.PID == stemp))
                        {
                            ProductTable data = new ProductTable()
                            {
                                PID = list[0],
                                Name = list[1],
                                Amount = Convert.ToInt32(list[2]),
                                Price = Convert.ToDecimal(list[3]),
                                Category = list[4],
                            };
                            try
                            {
                                model.ProductTable.Add(data);
                                model.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                isErr = true;
                                MessageBox.Show($"發生錯誤 {ex.ToString()}");
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"{list[0]}資料已存在");
                        }
                    }
                }
                if(!isErr) { MessageBox.Show("資料導入成完成"); }
            }
            fs.Close();

            BindData();
        }

        private void BindData()
        {
            ProductModel data = new ProductModel();
            var list = data.ProductTable.ToList();
            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new AddForm();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new ReviseForm();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new DeletForm();
            form.ShowDialog();
        }
    }
}
