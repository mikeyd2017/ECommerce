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
        //In the future I want to make this so that we set certain session or cookie values for the Factory, so we only need to load the classes specific to the session or cookie.
        //That way we don't have to remake the whole factory every time the controller is called, it's not too intensive either way.
        public DataHelper DataHelper;
        public TableCommands TableCommands;
        public DepartmentCommands DepartmentCommands;
        public AccountCommands AccountCommands;
        public ItemCommands ItemCommands;
        public CategoryCommands CategoryCommands;
        public ShopCommands ShopCommands;
        public AccountHelper AccountHelper;

        public Factory()
        {

        }
        public Factory(DataHelper dataHelper, [Optional] TableCommands tableCommands, [Optional] DepartmentCommands departmentCommands, [Optional] AccountCommands accountCommands, [Optional] ItemCommands itemCommands, [Optional] CategoryCommands categoryCommands, [Optional] ShopCommands shopCommands, [Optional] AccountHelper accountHelper)
        {
            DataHelper = dataHelper;
            TableCommands = tableCommands;
            DepartmentCommands = departmentCommands;
            AccountCommands = accountCommands;
            ItemCommands = itemCommands;
            CategoryCommands = categoryCommands;
            ShopCommands = shopCommands;
            AccountHelper = accountHelper;
        }
    }
}
