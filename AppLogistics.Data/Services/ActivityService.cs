using AppLogistics.Data.Interfaces;
using AppLogistics.DataContext.Context;
using AppLogistics.DataContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppLogistics.Data.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IAppLogisticsContext _context;

        public ActivityService(IAppLogisticsContext context)
        {
            _context = context;
        }

        public async Task<Activity> GetActivity(int id)
        {
            return await _context.Activity
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
