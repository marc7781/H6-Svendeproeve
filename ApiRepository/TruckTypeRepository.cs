using ApiDBlayer;
using DbModels;
using FrontendModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class TruckTypeRepository
    {
        Database db;
        public TruckTypeRepository()
        {
            db = new Database();
        }
        public async Task<TruckType> GetTruckTypeAsync(int trucktypeId)
        {
            DtoTruckType dtoTruckType = new DtoTruckType();
            dtoTruckType = await db.TruckTypes.FirstOrDefaultAsync(x => x.Id == trucktypeId);
            TruckType truckType = new TruckType
            {
                Id = dtoTruckType.Id,
                Trucktype = dtoTruckType.Trucktype
            };
            return truckType;
        }
        public async Task<List<TruckType>> GetAllTruckTypesAsync()
        {
            List<DtoTruckType> dtoTruckTypes = new List<DtoTruckType>();
            dtoTruckTypes = await db.TruckTypes.ToListAsync();
            List<TruckType> truckTypes = new List<TruckType>();
            foreach (DtoTruckType dtoTruckType in dtoTruckTypes)
            {
                TruckType truckType = new TruckType
                {
                    Id = dtoTruckType.Id,
                    Trucktype = dtoTruckType.Trucktype
                };
                truckTypes.Add(truckType);
            }
            return truckTypes;
        }
    }
}
