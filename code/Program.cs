﻿using System;
using EffectiveCSharpSamples.Generator;

namespace EffectiveCSharpSamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sequence = ArchimedesSpiral.GenerateSpiral(1, 512);
            foreach (var point in sequence)
                Console.WriteLine(point);
 
        }
    }
}