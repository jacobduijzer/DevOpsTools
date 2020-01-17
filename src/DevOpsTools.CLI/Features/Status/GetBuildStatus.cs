using System.Threading;
using System.Threading.Tasks;
using DevOpsTools.Core;
using DevOpsTools.Core.Models;
using MediatR;

namespace DevOpsTools.CLI.Features.Status
{
    public static class GetBuildStatus 
    {
        public class Handler : BaseRequestHandler<Build>, 
            IRequestHandler<BaseRequestHandler<Build>.Request, BaseRequestHandler<Build>.Response>
        {
            public Handler(IDevopsApi api) : base(api) { }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var builds = await Api
                    .GetBuildsAsync("VAA IenR en RasWeb",10)
                    .ConfigureAwait(false);

                return await RespondWith(builds).ConfigureAwait(false);
            }
        }
    }
}