using AutoMapper;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using DAL.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class SettlementsData : ISettlementsData
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public SettlementsData(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Settlements>> GetAllSettlements(string sortOrder, int pageNumber, int pageSize, string searchString)
        {
            var settlements = from s in _context.Settlements
                              select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                settlements = settlements.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    settlements = settlements.OrderByDescending(s => s.Name);
                    break;
                default:
                    settlements = settlements.OrderBy(s => s.Name);
                    break;
            }

            return await settlements.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Settlements> GetSettlementById(int id)
        {
            return await _context.Settlements.FindAsync(id);
        }


        public async Task<bool> PostSettlements(SettlementsDto settlementsDto)
        {
            var settlementsEntity = _mapper.Map<Settlements>(settlementsDto);
            _context.Settlements.Add(settlementsEntity);
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        //public async Task<bool> PostSettlements(SettlementsDto settlementsDto)
        //{
        //    var settlementsEntity = _mapper.Map<Settlements>(settlementsDto);
        //    _context.Settlements.Add(settlementsEntity);
        //    int changes = await _context.SaveChangesAsync();
        //    return changes > 0;
        //}

        public async Task<bool> PutSettlements(int id, SettlementsDto settlementsDto)
        {
            var settlementsEntity = _mapper.Map<Settlements>(settlementsDto);
            if (id != settlementsEntity.Id)
            {
                return false;
            }

            _context.Entry(settlementsEntity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SettlementExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public async Task<bool> DeleteSettlements(int id)
        {
            var settlements = await _context.Settlements.FindAsync(id);
            if (settlements == null)
            {
                return false;
            }

            _context.Settlements.Remove(settlements);
            int changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        private bool SettlementExists(int id)
        {
            return _context.Settlements.Any(e => e.Id == id);
        }
    }
}


//using AutoMapper;
//using DAL.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using Project.Models;
//using DAL.DTO;

//namespace DAL.Data
//{
//    public class SettlementsData : ISettlementsData
//    {
//        private readonly DBContext _context;
//        private readonly IMapper _mapper;

//        public SettlementsData(DBContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public async Task<List<Settlements>> GetAllSettlements()
//        {
//            return await _context.Settlements.ToListAsync();
//        }

//        public async Task<Settlements> GetSettlementById(int id)
//        {
//            return await _context.Settlements.FindAsync(id);
//        }

//        public async Task<bool> PostSettlements(SettlementsDto settlementsDto)
//        {
//            var settlementsEntity = _mapper.Map<Settlements>(settlementsDto);
//            _context.Settlements.Add(settlementsEntity);
//            int changes = await _context.SaveChangesAsync();
//            return changes > 0;
//        }

//        public async Task<bool> PutSettlements(int id, SettlementsDto settlementsDto)
//        {
//            var settlementsEntity = _mapper.Map<Settlements>(settlementsDto);
//            if (id != settlementsEntity.Id)
//            {
//                return false;
//            }

//            _context.Entry(settlementsEntity).State = EntityState.Modified;
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!SettlementExists(id))
//                {
//                    return false;
//                }
//                else
//                {
//                    throw;
//                }
//            }
//            return true;
//        }

//        public async Task<bool> DeleteSettlements(int id)
//        {
//            var settlements = await _context.Settlements.FindAsync(id);
//            if (settlements == null)
//            {
//                return false;
//            }

//            _context.Settlements.Remove(settlements);
//            int changes = await _context.SaveChangesAsync();
//            return changes > 0;
//        }

//        private bool SettlementExists(int id)
//        {
//            return _context.Settlements.Any(e => e.Id == id);
//        }
//    }
//}
