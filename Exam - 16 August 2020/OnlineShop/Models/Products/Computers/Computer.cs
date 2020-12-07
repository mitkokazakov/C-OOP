using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;
        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();

            this.CurrentOverall = overallPerformance;
            this.CurrentPrice = price;
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)this.components;
        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public double CurrentOverall { get; private set; }
        public decimal CurrentPrice { get; private set; }
        public override double OverallPerformance => this.components.Count == 0 ? this.CurrentOverall : this.CurrentOverall + this.components.Average(c => c.OverallPerformance);

        public override decimal Price => this.CurrentPrice + this.components.Sum(c => c.Price) + this.peripherals.Sum(p => p.Price);
        public void AddComponent(IComponent component)
        {
        }
        public void AddPeripheral(IPeripheral peripheral)
        {
        }
        public IComponent RemoveComponent(string componentType)
        {
        }
        public IPeripheral RemovePeripheral(string peripheralType)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in this.components)
            {
                sb.AppendLine(component.ToString());
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(p => p.OverallPerformance)}):");

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine(peripheral.ToString());
            }
        }
    }
}
