using AutoMapper;
using BL.Interfaces;
using BL.Utilities;
using DAL.Interfaces;
using Project.Models;
using DAL.DTO;

namespace BL.Services
{
    public class SettlementsServices : ISettlementsServices
    {
        private readonly ISettlementsData _settlementsData;
        private readonly IMapper _mapper;

        public SettlementsServices(ISettlementsData settlementsData, IMapper mapper)
        {
            _settlementsData = settlementsData;
            _mapper = mapper;
        }

        public async Task<List<Settlements>> GetAllSettlements(string? nameFilter, int pageNumber, int pageSize, string? sortOrder)
        {
            // המרת הטקסט מאנגלית לעברית במידה ונדרש
            if (!string.IsNullOrEmpty(nameFilter))
            {
                nameFilter = HebrewKeyboardConverter.ConvertEngToHeb(nameFilter);
            }
            return await _settlementsData.GetAllSettlements(nameFilter, pageNumber, pageSize, sortOrder);
        }

        public async Task<Settlements> GetSettlementById(int id)
        {
            return await _settlementsData.GetSettlementById(id);
        }

        public async Task<bool> PostSettlements(SettlementsDto settlementsDto)
        {
            return await _settlementsData.PostSettlements(settlementsDto);
        }

        public async Task<bool> PutSettlements(int id, SettlementsDto settlementsDto)
        {
            return await _settlementsData.PutSettlements(id, settlementsDto);
        }

        public async Task<bool> DeleteSettlements(int id)
        {
            return await _settlementsData.DeleteSettlements(id);
        }
    }
}



//using AutoMapper;
//using BL.Interfaces;
//using DAL.Interfaces;
//using Project.Models;
//using DAL.DTO;

//namespace BL.Services
//{
//    public class SettlementsServices : ISettlementsServices
//    {
//        private readonly ISettlementsData _settlementsData;
//        private readonly IMapper _mapper;

//        public SettlementsServices(ISettlementsData settlementsData, IMapper mapper)
//        {
//            _settlementsData = settlementsData;
//            _mapper = mapper;
//        }

//        public async Task<List<Settlements>> GetAllSettlements(string? nameFilter, int pageNumber, int pageSize, string? sortOrder)
//        {
//            return await _settlementsData.GetAllSettlements(nameFilter, pageNumber, pageSize, sortOrder);
//        }

//        public async Task<Settlements> GetSettlementById(int id)
//        {
//            return await _settlementsData.GetSettlementById(id);
//        }

//        public async Task<bool> PostSettlements(SettlementsDto settlementsDto)
//        {
//            return await _settlementsData.PostSettlements(settlementsDto);
//        }

//        public async Task<bool> PutSettlements(int id, SettlementsDto settlementsDto)
//        {
//            return await _settlementsData.PutSettlements(id, settlementsDto);
//        }

//        public async Task<bool> DeleteSettlements(int id)
//        {
//            return await _settlementsData.DeleteSettlements(id);
//        }
//    }
//}


//using AutoMapper;
//using BL.Interfaces;
//using DAL.Interfaces;
//using Project.Models;
//using DAL.DTO;

//namespace BL.Services
//{
//    public class SettlementsServices : ISettlementsServices
//    {
//        private readonly ISettlementsData _settlementsData;
//        private readonly IMapper _mapper;

//        public SettlementsServices(ISettlementsData settlementsData, IMapper mapper)
//        {
//            _settlementsData = settlementsData;
//            _mapper = mapper;
//        }

//        public async Task<List<Settlements>> GetAllSettlements()
//        {
//            return await _settlementsData.GetAllSettlements();
//        }

//        public async Task<Settlements> GetSettlementById(int id)
//        {
//            return await _settlementsData.GetSettlementById(id);
//        }

//        public async Task<bool> PostSettlements(SettlementsDto settlementsDto)
//        {
//            return await _settlementsData.PostSettlements(settlementsDto);
//        }

//        public async Task<bool> PutSettlements(int id, SettlementsDto settlementsDto)
//        {
//            return await _settlementsData.PutSettlements(id, settlementsDto);
//        }

//        public async Task<bool> DeleteSettlements(int id)
//        {
//            return await _settlementsData.DeleteSettlements(id);
//        }
//    }
//}
