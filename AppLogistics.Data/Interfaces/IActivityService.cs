using AppLogistics.DataContext.Models;
using System.Threading.Tasks;

namespace AppLogistics.Data.Interfaces
{
    public interface IActivityService
    {
        Task<Activity> GetActivity(int id);
    }
}
