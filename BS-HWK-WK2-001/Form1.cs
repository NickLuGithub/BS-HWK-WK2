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
                        ProductList.Add(new Product()
                        {
                            ID = list[0],
                            Name = list[1],
                            Amount = Convert.ToInt32(list[2]),
                            Price = Convert.ToDecimal(list[3]),
                            Category = list[4],
                        });
                    }
                }
            }
            fs.Close();

            foreach (Product p in ProductList)
            {
                ProductTable data = new ProductTable()
                {
                    PID = p.ID,
                    Name = p.Name,
                    Amount = p.Amount,
                    Price = p.Price,
                    Category = p.Category,
                };
                try
                {
                    ProductModel model = new ProductModel();
                    model.ProductTable.Add(data);
                    model.SaveChanges();
                    MessageBox.Show("導入成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"發生錯誤 {ex.ToString()}");
                    break;
                }
            }
            
            BindData();
        }

        private void BindData()
        {
            ProductModel data = new ProductModel();
            var list = data.ProductTable.ToList();
            dataGridView1.DataSource = list;
        }

    }
}
