﻿namespace Service.Contracts;
public interface IServiceManager
{
    IRecipeService RecipeService { get; }
    IJobService JobService { get; }    
}
