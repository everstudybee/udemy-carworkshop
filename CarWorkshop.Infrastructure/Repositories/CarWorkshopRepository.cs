using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories;
public class CarWorkshopRepository : ICarWorkshopRepository
{
    private readonly CarWorkshopDbContext _dbContect;

    public CarWorkshopRepository(CarWorkshopDbContext dbContect)
    {
        _dbContect = dbContect;
    }

    public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
    {
        _dbContect.Add(carWorkshop);
        await _dbContect.SaveChangesAsync();
    }

    public Task<Domain.Entities.CarWorkshop?> GetByName(string name) => _dbContect.CarWorkshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
}
