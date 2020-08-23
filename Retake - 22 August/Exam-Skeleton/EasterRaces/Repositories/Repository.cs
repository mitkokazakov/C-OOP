using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models => this.models.AsReadOnly();
        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models;
        }

        public T GetByName(string name)
        {
            T targetModel = this.models.FirstOrDefault(m => m.GetType().Name == name);

            return targetModel;
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
