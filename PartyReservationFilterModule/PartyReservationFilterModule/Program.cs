using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var dictionary = new Dictionary<string, Predicate<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Print")
                {
                    break;
                }
                var commands = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var action = commands[0];
                var predicate = commands[1];
                var value = commands[2];

                if (action == "Add filter")
                {
                    dictionary.Add(predicate+";"+value, getPredicate(predicate,value));
                }
                else
                {
                    dictionary.Remove(predicate + ";" + value);
                }
            }

            foreach (var p in dictionary)
            {
                names.RemoveAll(p.Value);
            }

            foreach (var name in names)
            {
                Console.Write(name+" ");
            }
            
        }

        

        public static  Predicate<string> getPredicate(string predicate, string value)
        {
            if (predicate == "Starts with")
            {
                return new Predicate<string>(str => str.StartsWith(value));
            }else if (predicate == "Ends with")
            {
                return new Predicate<string>(str => str.EndsWith(value));
            }else if (predicate == "Length")
            {
                return new Predicate<string>(str => str.Length == int.Parse(value));
            }
            else
            {
                return new Predicate<string>(str => str.Contains(value));
            }
        }

        
    }
}