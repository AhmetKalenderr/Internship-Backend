using InternShipApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces.IRepository
{
    public interface ISchoolRepository
    {
        Task<List<School>> getAllSchool();
    }
}
