using BakeryBL.Models;
using System.Data.Entity;
using System.Windows.Forms;
using System;

namespace BakeryUI
{
    public partial class CatalogForm<T> : Form
        where T : class
    {
        CrmDbContext db;
        DbSet<T> set;
        public CatalogForm(DbSet<T> set, CrmDbContext db)
        {
            InitializeComponent();
            this.db = db;
            this.set = set;
            set.Load();
            dataGridView.DataSource = set.Local.ToBindingList();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;
            if (typeof(T) == typeof(Product))
            {
                var product = set.Find(id) as Product;
                if (product != null)
                {
                    var form = new ProductForm(product);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }

            else if (typeof(T) == typeof(Shop))
            {
                var shop = set.Find(id) as Shop;
                if (shop != null)
                {
                    var form = new ShopForm(shop);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        shop = form.Shop;
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            Hide();
        }
    }
}
