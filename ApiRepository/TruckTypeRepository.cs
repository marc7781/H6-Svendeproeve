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
            try
            {
                dtoTruckType = await db.TruckTypes.FirstOrDefaultAsync(x => x.Id == trucktypeId);
            }
            catch
            {
                return null;
            }
            if(dtoTruckType != null)
            {
                TruckType truckType = new TruckType
                {
                    Id = dtoTruckType.Id,
                    Trucktype = dtoTruckType.Trucktype
                };
                return truckType;
            }
            return null;
        }
        public async Task<List<TruckType>> GetAllTruckTypesAsync()
        {
            List<DtoTruckType> dtoTruckTypes = new List<DtoTruckType>();
            try
            {
                dtoTruckTypes = await db.TruckTypes.ToListAsync();

            }
            catch
            {
                return null;
            }
            if(dtoTruckTypes != null)
            {
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
            return null;
        }
    }
}
