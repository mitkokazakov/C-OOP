using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => this.models.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration foundType;

            foundType = this.models.First(t => t.GetType().Name == type);

            return foundType;
        }

        public bool Remove(IDecoration model)
        {
            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
