using ECommerce.Helpers;
using ECommerce.SqlCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ECommerce
{
    public class Factory
    {
        //Only 2 classes needed right now, as mentioned in HomeController we will be adding many more, this will be the best way to keep them all together.
        public DataHelper DataHelper;
        public TableCommands TableCommands;

        public Factory([Optional] DataHelper dataHelper, [Optional] TableCommands tableCommands)
        {
            DataHelper = dataHelper;
            TableCommands = tableCommands;
        }
    }
}
