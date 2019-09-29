using System;
using System.Collections.Generic;

namespace Q3
{
    class Program
    {
        static bool Validate(string input, out uint validatedvalue)
        {       
            validatedvalue = 0;     
            uint value;
            if(input.Length != 7)
            {
                Console.WriteLine("That's not 7 characters");
                return false;   
            }
            if(!uint.TryParse(input, out value))
            {   
                Console.WriteLine("That's not an integer");
                return false;
            } 
        
            uint testing = value;
            while(testing > 0){
                if(testing % 10 > 7)
                {
                   Console.WriteLine("That has a digit higher than 7 in it");
                   return false;
                }
                testing /= 10;
            }
            validatedvalue = value;
            return true;            
        
        }
        static void Main(string[] args)
        {
            uint value;
            string input; 
            if(args.GetLength(0) > 0)
            {
                input = args[0];
            }
            else
            {
                Console.WriteLine("Give me a 7 digit number: ");
                input = Console.ReadLine();            
            }
            
            if(!Validate(input, out value))
            {
                Console.WriteLine("Invalid Input: ", input);
                return;
            }

            Console.WriteLine(Search(value));
        }

        static uint Search(uint root)
        {
            Queue<Change> q = new Queue<Change>();
            q.Enqueue(new Change(root));
            IList<uint> alreadyChecked = new List<uint>();
            while(q.Count > 0)
            {
                Change head = q.Dequeue();
                if(head.Value == 1234567)
                    return head.Level;
                
                foreach(Change c in head.Generate())
                {
                    if(!alreadyChecked.Contains(c.Value))
                    {
                        q.Enqueue(c);
                        alreadyChecked.Add(c.Value);
                    }
                }
            }
            return 0;
        }
    }
}
