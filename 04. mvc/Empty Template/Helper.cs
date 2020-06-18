using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empty_Template
{
    public class Helper
    {
        // I want to use this method in the index view, how do I do that?
        // 1. in the view inject it
        // 2. in the dependency injection, inject the class

        // this is called injectable services
        public string GetabcString()
        {
            return "abc";
        }
    }
}
