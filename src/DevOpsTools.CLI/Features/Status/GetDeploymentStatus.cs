using System.Threading;
using System.Threading.Tasks;
using DevOpsTools.Core;
using DevOpsTools.Core.Models;
using MediatR;

namespace DevOpsTools.CLI.Features.Status
{
    public static class GetDeploymentStatus 
    {
        public class Handler : BaseRequestHandler<Deployment>, 
            IRequestHandler<BaseRequestHandler<Deployment>.Request, BaseRequestHandler<Deployment>.Response>
        {
            public Handler(IDevopsApi api) : base(api) { }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var deployments = await Api
                    .GetDeploymentsAsync("VAA IenR en RasWeb",10)
                    .ConfigureAwait(false);
                
                return await RespondWith(deployments).ConfigureAwait(false);
            }
        } 
    }
}