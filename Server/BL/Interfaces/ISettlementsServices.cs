using DAL.DTO;
using Project.Models;

namespace BL.Interfaces
{
    public interface ISettlementsServices
    {
        Task<List<Settlements>> GetAllSettlements(string? nameFilter, int pageNumber, int pageSize, string? sortOrder);
        Task<Settlements> GetSettlementById(int id);
        Task<bool> PostSettlements(SettlementsDto settlementsDto);
        Task<bool> PutSettlements(int id, SettlementsDto settlementsDto);
        Task<bool> DeleteSettlements(int id);
    }
}


//using DAL.DTO;
//using Project.Models;

//namespace BL.Interfaces
//{
//    public interface ISettlementsServices
//    {
//        Task<List<Settlements>> GetAllSettlements();
//        Task<Settlements> GetSettlementById(int id);
//        Task<bool> PostSettlements(SettlementsDto settlementsDto);
//        Task<bool> PutSettlements(int id, SettlementsDto settlementsDto);
//        Task<bool> DeleteSettlements(int id);
//    }
//}
