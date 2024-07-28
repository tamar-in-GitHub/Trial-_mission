using DAL.DTO;
using Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISettlementsData
    {
        Task<List<Settlements>> GetAllSettlements(string sortOrder, int pageNumber, int pageSize, string searchString);
        Task<Settlements> GetSettlementById(int id);
        Task<bool> PostSettlements(SettlementsDto settlementsDto);
        Task<bool> PutSettlements(int id, SettlementsDto settlementsDto);
        Task<bool> DeleteSettlements(int id);
    }
}


//using DAL.DTO;
//using Project.Models;

//namespace DAL.Interfaces
//{
//    public interface ISettlementsData
//    {
//        Task<List<Settlements>> GetAllSettlements();
//        Task<Settlements> GetSettlementById(int id);
//        Task<bool> PostSettlements(SettlementsDto settlementsDto);
//        Task<bool> PutSettlements(int id, SettlementsDto settlementsDto);
//        Task<bool> DeleteSettlements(int id);
//    }
//}
