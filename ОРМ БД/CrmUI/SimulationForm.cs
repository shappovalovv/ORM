using CrmBL.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class SimulationForm : Form
    {
        ShopComputerModel model = new ShopComputerModel();
        public SimulationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cashBoxes = new List<CashBoxView>();

            for (int i = 0; i < model.CashDesks.Count; i++)
            {
                var box = new CashBoxView(model.CashDesks[i], i, 10, 26 * i);

                cashBoxes.Add(box);

                Controls.Add(box.CashDeskName);
                Controls.Add(box.Price);
                Controls.Add(box.QueueLenght);
                Controls.Add(box.LeaveCustomersCount);
            }
            model.Start();
        }

        private void SimulationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();           
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = model.CustomersSpeed;
            numericUpDown2.Value = model.CashDeskSpeed;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.CustomersSpeed = (int) numericUpDown1.Value;            
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.CashDeskSpeed = (int) numericUpDown2.Value; 
        }

        private void SimulationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            model.Stop();
        }
    }
}
