﻿using BakeryBL.Models;
using System;
using System.Windows.Forms;

namespace BakeryUI
{

    public partial class ProductForm : Form
    {
        public Product Product { get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(Product product) : this()
        {
            Product = product ?? new Product();
            textBox1.Text = Product.Name;
            numericUpDown1.Value = Product.Price;
            numericUpDown2.Value = Product.Count;      

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Product = Product ?? new Product();

            Product.Name = textBox1.Text;
            Product.Price = numericUpDown1.Value;
            Product.Count = Convert.ToInt32(numericUpDown2.Value);            
            Close();
        }
    }
}
