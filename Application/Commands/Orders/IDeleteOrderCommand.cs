﻿using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Orders
{
    public interface IDeleteOrderCommand:ICommand<int>
    {
    }
}
