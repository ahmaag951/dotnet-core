using FoolProof.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_foolproof
{
    public class MyDto
    {
        public int StartNumber { get; set; }

        [GreaterThanOrEqualTo("StartNumber")]
        public int EndNumber { get; set; }

        [RequiredIf("Other", 5)]
        public string Other1 { get; set; }

        public int Other { get; set; }
    }
}
