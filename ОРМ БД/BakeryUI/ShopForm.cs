using BakeryBL.Models;
using System;
using System.Windows.Forms;

namespace BakeryUI
{
    public partial class ShopForm : Form
    {
        public Shop Shop { get; set; }
        public ShopForm()
        {
            InitializeComponent();
        }

        public ShopForm(Shop shop) : this()
        {
            Shop = shop ?? new Shop();
            textBox1.Text = Shop.Name;
            textBox2.Text = Shop.Address;
            textBox3.Text = Shop.Phone;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Shop = Shop ?? new Shop();
            Shop.Name = textBox1.Text;
            Shop.Address = textBox2.Text;
            Shop.Phone = textBox2.Text;
        }
    }
}
