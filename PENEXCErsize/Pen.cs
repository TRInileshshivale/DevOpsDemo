using System;

namespace PENEXCErsize
{
    [Serializable()]
    public class Pen
    {
        public string color;
        public string brand;
        public double prize;
        public Pen() { }
        public Pen(string color, string brand, double prize)
        {
            this.color = color;
            this.brand = brand;
            this.prize = prize;
        }

        
        public void Pen3(string color, string brand, double prize)
        {
            this.color = color;
            this.brand = brand;
            this.prize = prize;
        }
        public void Pen1(string color, string brand, double prize)
        {
            this.color = color;
            this.brand = brand;
            this.prize = prize;
        }

        public string GetPenInfo()
        {
            return "Pen Info Color: " + color + " Brand :" + brand + " Prize:" + prize;
        }
    }
}
