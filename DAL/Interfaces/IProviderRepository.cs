﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProviderRepository
    {
        public Task Insert(ProviderDTO provider);

    }
}
