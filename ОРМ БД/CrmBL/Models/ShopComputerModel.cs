using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrmBL.Models
{
    public class ShopComputerModel
    {
        Random rnd = new Random();
        Generator Generator = new Generator();
        bool isWorking = false;
        List<Task> tasks = new List<Task>();
        CancellationTokenSource cancellationTokenSource;
        CancellationToken token;

        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sale> Sales { get; set; } = new List<Sale>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();
        public int CustomersSpeed { get; set; } = 100;
        public int CashDeskSpeed { get; set; } = 100;

        public ShopComputerModel()
        {
            var sellers = Generator.GetNewSellers(20);
            Generator.GetNewProducts(1000);
            Generator.GetNewCustomers(100);

            cancellationTokenSource = new CancellationTokenSource();
            token = cancellationTokenSource.Token;


            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }  
            
            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue(), null));
            }
        }

        public void Start()
        {
            tasks.Add(new Task(() => CreateCarts(10, token)));
            tasks.AddRange(CashDesks.Select(c => new Task(() => CashDeskWork(c, token))));

            var cashDeskTasks = CashDesks.Select(c => new Task(() => CashDeskWork(c, token)));

            foreach (var task in tasks)
            {
                task.Start();
            }

        }

        public void Stop()
        {            
            cancellationTokenSource.Cancel();
        }

        private void CashDeskWork(CashDesk cashDesk, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (cashDesk.Count > 0)
                {
                    cashDesk.Dequeue();
                    Thread.Sleep(CashDeskSpeed);
                }
            }
        }

        private void CreateCarts(int customerCounts, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var customers = Generator.GetNewCustomers(customerCounts);                

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);

                    foreach(var product in Generator.GetRandomProducts(10, 30))
                    {
                        cart.Add(product);
                    }

                    var cash = CashDesks[rnd.Next(CashDesks.Count)];
                    cash.Enqueue(cart);
                }

                Thread.Sleep(CustomersSpeed);
            }

        }
    }
}

