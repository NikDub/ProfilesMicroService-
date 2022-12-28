﻿using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.Services
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ReceptionistRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<Receptionist>> GetAllAsync()
        {
            return await _dbContext.Receptionists.ToListAsync();
        }

        public async Task<Receptionist> GetByIdAsync(string id)
        {
            return await _dbContext.Receptionists.FindAsync(id);
        }

        public async Task InsertAsync(Receptionist receptionist)
        {
            await _dbContext.Receptionists.AddAsync(receptionist);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Receptionist receptionist)
        {
            _dbContext.Entry(receptionist).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var receptionist = await _dbContext.Receptionists.FindAsync(id);
            _dbContext.Receptionists.Remove(receptionist);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
