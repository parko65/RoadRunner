using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace RoadRunner;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Recipe, RecipeDto>();
        CreateMap<RecipeForCreationDto, Recipe>();
    }
}
