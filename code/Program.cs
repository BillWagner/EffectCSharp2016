using System;
using EffectiveCSharpSamples.Generator;
using EffectiveCSharpSamples.EventInvoke;

namespace EffectiveCSharpSamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var sequence = ArchimedesSpiral.GenerateSpiral(0.5, 512);
            
            //foreach (var point in sequence)
            //    Console.WriteLine(point);
                
            var engine = new KeyboardReader();
            engine.OnKeyPress += (_, keyArgs) => Console.WriteLine($"Key: {keyArgs.Key}, Alt: {keyArgs.IsAlt}, Ctrl: {keyArgs.IsCtrl}");

            int count = 0;
            var done = false;
            do
            {
                try
                {
                    engine.ReadKeys('e');
                    done = true;
                }
                catch (Exception e) when (logException(e)) { }
                catch (InvalidOperationException e)when (count < 5)
                {
                    Console.WriteLine("You went backwards in the alphabet");
                    count++;
                }
            } while (!done);

            Console.WriteLine($"The last key was: {engine.PreviousKey}");
            Console.WriteLine("writing keys");
            foreach (var c in engine.AllKeys)
                Console.WriteLine(c);
        }
   
        private static bool logException(Exception e)
        { 
            var oldColor = Console.ForegroundColor; 
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine("Error: {0}", e); 
            Console.ForegroundColor = oldColor; 
            return false; 
        }
    }
}
