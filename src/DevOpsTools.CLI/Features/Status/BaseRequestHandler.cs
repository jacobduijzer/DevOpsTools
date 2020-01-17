using System.Threading.Tasks;
using DevOpsTools.Core;
using DevOpsTools.Core.Models;
using MediatR;

namespace DevOpsTools.CLI.Features.Status
{
    public class BaseRequestHandler<T> 
    {
        protected IDevopsApi Api;

        public BaseRequestHandler(IDevopsApi api) => Api = api;
        
        public class Request : IRequest<Response>
        {
        }
        
        public class Response
        {
            public CollectionResponse<T> Result { get; set; }
        }
        
        protected async Task<Response> RespondWith(CollectionResponse<T> result) =>
            await Task.FromResult(new Response {Result = result});
    }
}