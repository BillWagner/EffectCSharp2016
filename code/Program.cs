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
                catch (InvalidOperationException e)
                {
                    if (count < 5)
                    {
                        Console.WriteLine("You went backwards in the alphabet");
                        count++;
                    }
                    else
                        throw;
                }
            } while (!done);

            Console.WriteLine($"The last key was: {engine.PreviousKey}");
            Console.WriteLine("writing keys");
            foreach (var c in engine.AllKeys)
                Console.WriteLine(c);
        }
    }
}
