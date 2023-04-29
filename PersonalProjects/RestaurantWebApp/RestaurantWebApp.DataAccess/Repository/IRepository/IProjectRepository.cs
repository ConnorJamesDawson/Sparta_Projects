﻿using RestaurantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApp.DataAccess.Repository.IRepository
{
    public interface IProjectRepository : IRepository<Projects>
    {
        void Update(Projects project);
    }
}
