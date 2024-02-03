using CSMS.Data;
using CSMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Repositories
{
    public class ManagerRepository
    {
        private CleaningServiceContext _context = new CleaningServiceContext();

        public async Task<List<Order>> GetConfirmedOrders()
        {
            return await _context.Orders.Include(x => x._driver).ThenInclude(x => x._employee).ThenInclude(x => x._person).Include(x => x._cleaners).ThenInclude(x => x._employee).ThenInclude(x => x._person).Include(x => x._client).ThenInclude(x => x._person).Where(x => x._cleaners.Count != 0 && x._driver != null).ToListAsync();
        }

        public async Task<List<Cleaner>> GetAvailableCleaners(DateTime date)
        {
            return await _context.Cleaners.Include(x => x._employee).ThenInclude(x => x._person).Where(x => x._assignedOrders.All(x => x.JobDate != date)).ToListAsync();
        }

        public async Task AssignCleanerToOrder(int orderID, Cleaner cleaner)
        {
            _context.Orders.Where(x => x.OrderID == orderID).First().AddCleaner(cleaner);

            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrder(int orderID)
        {
            return await _context.Orders.Include(x => x._driver).ThenInclude(x => x._employee).ThenInclude(x => x._person).Include(x => x._cleaners).ThenInclude(x => x._employee).ThenInclude(x => x._person).Include(x => x._client).ThenInclude(x => x._person).Where(x => x.OrderID == orderID).FirstAsync();
        }
    }
}
