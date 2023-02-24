﻿using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Infrastructure.Repository;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DoctorRepository(ApplicationDbContext dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        return await _dbContext.Doctors.Include(r => r.Status).ToListAsync();
    }


    public async Task<Doctor> GetByIdAsync(Guid id)
    {
        return await _dbContext.Doctors.FirstOrDefaultAsync(r => r.AccountId == id);
    }

    public async Task InsertAsync(Doctor doctor)
    {
        await _dbContext.Doctors.AddAsync(doctor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        _dbContext.Entry(doctor).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateSpecializationNameAsync(Guid specializationId, string specializationName)
    {
        var doctorList = await _dbContext.Doctors.Where(r => r.SpecializationId == specializationId).ToListAsync();

        doctorList.ForEach(r =>
        {
            r.SpecializationName = specializationName;
            _dbContext.Entry(r).State = EntityState.Modified;
        });

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var doctor = await _dbContext.Doctors.FindAsync(id);
        if (doctor != null) _dbContext.Doctors.Remove(doctor);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Doctor>> GetByStatusAsync(string status)
    {
        return await _dbContext.Doctors.Where(r => r.Status.Name == status).ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}