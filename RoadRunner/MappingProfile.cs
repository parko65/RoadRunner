using AutoMapper;
using Entities.Models;
using RoadRunner.Models;
using Shared.DataTransferObjects;

namespace RoadRunner;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Recipe, RecipeDto>();
        CreateMap<RecipeForCreationDto, Recipe>();
        CreateMap<RecipeDto, RecipeModel>();

        CreateMap<Aggregate, AggregateDto>();
        CreateMap<AggregateForCreationDto, Aggregate>();
        CreateMap<AggregateDto, AggregateModel>();
        CreateMap<AggregateForCreation, AggregateForCreationDto>();

        CreateMap<Job, JobDto>();
        CreateMap<JobForCreationDto, Job>();
        CreateMap<JobDto, JobModel>();
        CreateMap<JobForCreation, JobForCreationDto>();

        CreateMap<Destination, DestinationDto>();
        CreateMap<DestinationForCreationDto, Destination>();
        CreateMap<DestinationDto, DestinationModel>();
    }
}
