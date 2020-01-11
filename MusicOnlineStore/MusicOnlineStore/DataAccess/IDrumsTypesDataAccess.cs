﻿using MusicOnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicOnlineStore.DataAccess
{
    public interface IDrumsTypesDataAccess
    {
        Task<List<DrumsTypes>> GetDrumsTypes();

    }
}
