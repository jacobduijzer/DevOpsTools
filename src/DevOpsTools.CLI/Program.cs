using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using DevOpsTools.Core;
using DevOpsTools.Core.Models;
using McMaster.Extensions.CommandLineUtils;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Refit;

namespace DevOpsTools.CLI
{
    [Command(Name = "DevOpsTools",  Description = "Get DevOps build, release & deployment information")]
    [HelpOption]
    [VersionOptionFromMember(MemberName = "GetVersion")]
    [Subcommand(
        typeof(Features.Status.Commands.GetBuildStatusCommand),
        typeof(Features.Status.Commands.GetReleasesStatusCommand),
        typeof(Features.Status.Commands.GetDeploymentsStatusCommand))
    ]
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await CreateHostBuilder()
                .RunCommandLineApplicationAsync<Program>(args);
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureHostConfiguration(configHost => configHost.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json"))
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddMediatR(typeof(Program).Assembly)
                        .AddAutoMapper(typeof(Program).Assembly)
                        .Configure<DevOpsSettings>(hostContext.Configuration.GetSection("DevOpsSettings"))
                        .AddLogging(logging =>
                        {
                            logging.ClearProviders();
                            logging.AddConsole();
                        })
                        .Configure<LoggerFilterOptions>(options=>options.MinLevel = LogLevel.Warning);

                    var baseAddress = hostContext.Configuration.GetSection("DevOpsSettings").GetValue<string>("BaseAddress");
                    var pat = hostContext.Configuration.GetSection("DevOpsSettings").GetValue<string>("PersonalAccessToken");

                    services
                        .AddRefitClient<IDevopsApi>()
                        .ConfigureHttpClient(x => x.BaseAddress = new Uri(baseAddress))
                        .AddHttpMessageHandler(() =>  new AuthenticatedHttpClientHandler(pat));
                });

        private int OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine("You must specify a command");
            app.ShowHelp();
            return 1;
        }

        private string GetVersion() =>
            typeof(Program).Assembly
                ?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;
    }
}