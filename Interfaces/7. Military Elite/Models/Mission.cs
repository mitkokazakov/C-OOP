using Military.Contracts;
using Military.Enumerations;
using Military.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParseState(state);
        }
        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new ArgumentException("Mission is already comleted!!");
            }

            this.State = State.Finished;
        }

        private State TryParseState(string stateStr)
        {
            State state;

            bool isParsed = Enum.TryParse<State>(stateStr, out state);

            if (!isParsed)
            {
                throw new InvalidStateException();
            }

            return state;
        }

        public override string ToString()
        {
            return $"   Code Name: {this.CodeName} State: {this.State.ToString()}";
        }
    }
}
