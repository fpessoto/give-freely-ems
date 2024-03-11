using Ardalis.Result;
using Ardalis.SharedKernel;

namespace GiveFreely.EMS.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
