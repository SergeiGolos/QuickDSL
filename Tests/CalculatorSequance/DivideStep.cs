﻿using QuickDSL.Scanning;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CalculatorSequance
{
    [Verb("divide")]
    public class DivideStep : NumberStep
    {
        public override int Act(int current, int value)
        {
            return current / value;
        }
    }
}