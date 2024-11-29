using BackendModels;
using FrontendModels;
using MauiDBlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiRepository
{
    public class TruckRepository
    {
        DBAccess db;
        public TruckRepository() 
        {
            db = new DBAccess();
        }
        public async Task<List<TruckType>> GetAllTrucksAsync()
        {
            List<DtoTruckType> dtoTruckTypes = await db.GetAllTruckAsync();
            List<TruckType> truckTypes = new List<TruckType>();
            foreach (DtoTruckType dtoTruckType in dtoTruckTypes)
            {
                TruckType truckType = new TruckType
                {
                    Id = dtoTruckType.Id,
                    Trucktype = dtoTruckType.Trucktype,
                };
                truckTypes.Add(truckType);
            }
            return truckTypes;
        }
    }
}
