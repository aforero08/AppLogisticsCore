using AppLogistics.DataContext.Models;
using AppLogistics.WebApp.Models.AccountViewModels;
using AppLogistics.WebApp.Models.ApplicationUserViewModel;
using AutoMapper;

namespace AppLogistics.WebApp.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserEditViewModel>();
            CreateMap<ApplicationUser, ApplicationUserDetailsViewModel>();
        }
    }
}