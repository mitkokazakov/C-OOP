using Military.Contracts;
using Military.Enumerations;
using Military.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Military.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {
            Corps corps;

            bool isParsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!isParsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps.ToString()}");

            return sb.ToString().TrimEnd();
        }
    }
}
