﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2._2
{
    public abstract class Worker
    {
        private string name;
        private string position;
        private double workDay;
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    name = "Безіменний";
            }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        public double WorkDay
        {
            get { return workDay; }
            set
            {
                if (value < 0)
                    workDay = 0;
                else if (value > 24)
                    workDay = 24;
                else 
                    workDay = value;
            }
        }
        
        public Worker(string Name)
        {
            this.Name = Name;
        }
        public void Call()
        {
            Console.WriteLine($"{Name} дзвонить до когось.");
        }
        public void WriteCode()
        {
            Console.WriteLine($"{Name} щось кодує.");
        }
        public void Relax()
        {
            Console.WriteLine($"{Name} відпочиває.");
        }
        public abstract void FillWorkDay();
    }
}
