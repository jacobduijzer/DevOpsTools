using AutoMapper;
using DevOpsTools.Core.Models;

namespace DevOpsTools.CLI.Features.Status
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Commands.GetBuildStatusCommand, BaseRequestHandler<Build>.Request>();
            CreateMap<Commands.GetReleasesStatusCommand, BaseRequestHandler<Release>.Request>();
            CreateMap<Commands.GetDeploymentsStatusCommand, BaseRequestHandler<Deployment>.Request>();
        }
    }
}