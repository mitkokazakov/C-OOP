﻿using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private Aquarium()
        {
            this.Fish = new List<IFish>();
            this.Decorations = new List<IDecoration>();
        }
        public Aquarium(string name, int capacity) : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }
        public int Capacity { get; }
        public int Comfort => this.Decorations.Sum(com => com.Comfort);
        public ICollection<IDecoration> Decorations { get; }
        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }
        public void AddFish(IFish fish)
        {
            if (this.Fish.Count >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.Fish.Add(fish);
        }
        public void Feed() 
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }
        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string fishResult = this.Fish.Any() ? String.Join(", ", this.Fish.Select(f => f.Name)) : "none";

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fishResult}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
        public bool RemoveFish(IFish fish)
        {
            if (this.Fish.Contains(fish))
            {
                this.Fish.Remove(fish);
                return true;
            }

            return false;
        }
    }
}
