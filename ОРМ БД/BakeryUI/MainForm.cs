using BakeryBL.Models;
using System;
using System.Windows.Forms;

namespace BakeryUI
{
    public partial class MainForm : Form
    {
        CrmDbContext db;
        public MainForm()
        {
            InitializeComponent();
            db = new CrmDbContext();
        }

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new CatalogForm<Product>(db.Products, db);
            catalogProduct.Show(); 
            Hide();
        }

        private void ShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogShop = new CatalogForm<Shop>(db.Shops, db);
            catalogShop.Show();
            Hide();
        }

        private void OrderToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            var catalogOrder = new CatalogForm<Order>(db.Orders, db);
            catalogOrder.Show();
            Hide();
        }

        private void AddProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(form.Product);
                db.SaveChanges();
            }
        }

        private void AddShopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new ShopForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Shops.Add(form.Shop);
                db.SaveChanges();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        { 
        }
    }
}
 