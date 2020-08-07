using Military.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly ICollection<ISoldier> privates;
        
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>)this.privates;

        public void AddPrivates(ISoldier @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine("Privates:");

            foreach (var prvt in this.privates)
            {
                sb.AppendLine($"{prvt}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
