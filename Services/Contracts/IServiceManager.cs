﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IBookService BookService { get; }
        ICategoryService CategoryService { get; }
        IRentalService RentalService { get; }
        IUserService UserService { get; }
    }
}
