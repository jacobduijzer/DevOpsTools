using System.Threading;
using System.Threading.Tasks;
using DevOpsTools.Core;
using DevOpsTools.Core.Models;
using MediatR;

namespace DevOpsTools.CLI.Features.Status
{
    public static class GetReleaseStatus
    {
        public class Handler : BaseRequestHandler<Release>,
            IRequestHandler<BaseRequestHandler<Release>.Request, BaseRequestHandler<Release>.Response>
        {
            public Handler(IDevopsApi api) : base(api)
            {
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var releases = await Api
                    .GetReleasesAsync("VAA IenR en RasWeb", 10)
                    .ConfigureAwait(false);

                return await RespondWith(releases).ConfigureAwait(false);
            }
        }
    }
}