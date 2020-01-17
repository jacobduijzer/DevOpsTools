using System;
using System.Threading.Tasks;
using AutoMapper;
using DevOpsTools.Core.Models;
using McMaster.Extensions.CommandLineUtils;
using MediatR;

namespace DevOpsTools.CLI.Features.Status
{
    public static class Commands
    {
        [Command("builds", Description = "Get the status of DevOps builds")]
        public class GetBuildStatusCommand
        {
            [Option("-o|--output", CommandOptionType.SingleValue, Description = "How to output the information")]
            public OutputOptions Output { get; set; }
            
            private async Task OnExecuteAsync(IMediator mediator, IMapper mapper, IConsole console)
            {
                var command = mapper.Map<BaseRequestHandler<Build>.Request>(this);

                var response = await mediator.Send(command);

                switch (Output)
                {
                    case OutputOptions.AmountOnly:
                        Console.WriteLine($"{response.Result.Count}");
                        break;
    
                    default:
                        console.WriteLine($@"
Builds report
Running builds: {response.Result.Count}
");
                        foreach (var build in response.Result.Value)
                        {
                            Console.WriteLine($"{build.Description} {build.Text} {build.SourceBranch} {build.Status}"); 
                        } 
                        break;
                }
            }
        }
        
        [Command("releases", Description = "Get the status of DevOps builds")]
        public class GetReleasesStatusCommand
        {
            [Option("-o|--output", CommandOptionType.SingleValue, Description = "How to output the information")]
            public OutputOptions Output { get; set; }
            
            private async Task OnExecuteAsync(IMediator mediator, IMapper mapper, IConsole console)
            {
                var command = mapper.Map<BaseRequestHandler<Release>.Request>(this);
                

                var response = await mediator.Send(command);

                switch (Output)
                {
                    case OutputOptions.AmountOnly:
                        Console.WriteLine($"{response.Result.Count}");
                        break;
    
                    default:
                        console.WriteLine($@"TODO");
                        break;
                }
            }
        }
        
        [Command("deployments", Description = "Get the status of DevOps deployments")]
        public class GetDeploymentsStatusCommand
        {
            [Option("-o|--output", CommandOptionType.SingleValue, Description = "How to output the information")]
            public OutputOptions Output { get; set; }
            
            private async Task OnExecuteAsync(IMediator mediator, IMapper mapper, IConsole console)
            {
                var command = mapper.Map<BaseRequestHandler<Deployment>.Request>(this);

                var response = await mediator.Send(command);

                switch (Output)
                {
                    case OutputOptions.AmountOnly:
                        Console.WriteLine($"{response.Result.Count}");
                        break;
    
                    default:
                        console.WriteLine($@"TODO");
                        break;
                }
            }
        }
    }
}