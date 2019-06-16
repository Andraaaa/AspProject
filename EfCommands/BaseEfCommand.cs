using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public abstract class BaseEfCommand
    {
        protected AspAppShopContext Context { get; }

        protected BaseEfCommand(AspAppShopContext context)
        {
            Context = context;
        }
    }
}
 