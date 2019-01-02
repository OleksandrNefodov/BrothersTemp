using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brothers.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>()
            {
                "sasha",
                "sasha",
                "sasha",
                "sasha",
                "sasha",
                "sasha",
                "sasha",
                "sasha",
                "sasha",
                "sasha"
            };

            var namesCount = GetNamesCount(names);

            foreach (var i in namesCount)
            {
                Console.WriteLine($"name : {i.Key}, count : {i.Value}");
            }

            Console.ReadKey();
        }

        public static Dictionary<string, int> GetNamesCount(List<string> names)
        {
            var result = new Dictionary<string, int>();
            foreach (var name in names)
            {
                if (result.ContainsKey(name))

                {
                    int count;
                    result.TryGetValue(name, out count);
                    
                    result[name] = ++count;
                }
                else
                {
                    result.Add(name, 1);
                }
            }

            return result;
        }
    }
}
