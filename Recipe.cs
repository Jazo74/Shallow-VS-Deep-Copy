using System;
using System.Collections.Generic;

namespace ShallowVSDeepCopy
{
    public class Recipe : IClonable
    {
        private static int ID = 0;
        public int id { get; set; }
        public string Name { get; set; }
        public  Dictionary<string, string> Ingredients = new Dictionary<string, string>();

        public Recipe() { }
        public Recipe(string name, Dictionary<string, string> ingredients)
        {
            ID += 1;
            id = ID;
            Name = name;
            Ingredients = ingredients;
        }
        public override string ToString()
        {
            string toString = id.ToString();
            toString += "|" + Name;
            foreach (KeyValuePair<string, string> item in Ingredients)
            {
                toString += "|" + item.Key;
                toString += "-" + item.Value;
            }
            return toString;
        }
        public Recipe Clone()
        {
            return (Recipe) this.MemberwiseClone();
        }
    }
}
