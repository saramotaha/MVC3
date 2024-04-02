using AutoMapper;
using MVC3.DAL.Models;
using MVC3.PL.ViewModels;

namespace MVC3.PL.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmpViewModel,Employee>().ReverseMap();
        }
    }
}
