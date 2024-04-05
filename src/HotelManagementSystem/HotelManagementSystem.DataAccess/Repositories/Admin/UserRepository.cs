﻿using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Library.Services.Data.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DataAccess.Repositories.Admin
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<User> _dbSet;
        public UserRepository(DbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }

        public async Task<User> GetUserByUsernameAsync(string username, int branchId)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.UserName == username && x.HotelBranchId == branchId);
        }
    }
}
