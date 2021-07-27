using Microsoft.EntityFrameworkCore;
using Notepad.Domain.Cities;
using Notepad.EntityFramework.Repository;

namespace Notepad.Repository.EntityFramework.Repositories.Cities
{
    public class CityEfRepository: EfRepositoryBase<City>, ICityRepository
    {
        public CityEfRepository(DbContext context) : base(context)
        {
        }
    }
}