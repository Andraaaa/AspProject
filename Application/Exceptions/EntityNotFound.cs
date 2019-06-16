using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityNotFound:Exception
    {
        public EntityNotFound(string entity) : base($"{entity} doesn't exist.")
        {

        }

        public EntityNotFound()
        {

        }

    }
}
