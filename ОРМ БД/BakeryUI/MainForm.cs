using BakeryBL.Models;
using System;
using System.Windows.Forms;
using BakeryBL.Repository.impl;

namespace BakeryUI
{
    public partial class MainForm : Form
    {
        ProductRepository productRepository;
        OrderRepository orderRepository;
        ShopRepository shopRepository;
        public MainForm()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
            orderRepository = new OrderRepository();
            shopRepository = new ShopRepository();
        }

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new CatalogForm<Product>(productRepository.Products, productRepository, shopRepository);
            catalogProduct.Show();
            Hide();
        }

        private void ShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogShop = new CatalogForm<Shop>(shopRepository.Shops, productRepository, shopRepository);
            catalogShop.Show();
            Hide();
        }

        private void OrderToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            var catalogOrder = new CatalogForm<Order>(orderRepository.Orders, productRepository, shopRepository);
            catalogOrder.Show();
            Hide();
        }

        private void AddProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                productRepository.Products.Add(form.Product);
                productRepository.SaveChanges();
            }
        }

        private void AddShopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new ShopForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                shopRepository.Shops.Add(form.Shop);
                shopRepository.SaveChanges();
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
 