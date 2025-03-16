using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using GitStatusInteractive.Cli;
using GitStatusInteractive.Cli.Commands;
using GitStatusInteractive.Cli.IO;
using GitStatusInteractive.Core;
using Microsoft.Extensions.DependencyInjection;

return await new CommandLineBuilder(new GitStatusInteractiveRootCommand())
    .UseVersionOption()
    .UseHelp()
    .UseEnvironmentVariableDirective()
    .UseParseDirective()
    .UseSuggestDirective()
    .RegisterWithDotnetSuggest()
    .UseTypoCorrections()
    .UseParseErrorReporting()
    .UseExceptionHandler()
    .CancelOnProcessTermination()
    .UseDependencyInjection(services => services
        .AddSingleton(ApplicationConsole.Console)
        .AddSingleton<IPrinter, ApplicationConsolePrinter>()
        .AddCore())
    .Build()
    .InvokeAsync(args)
    .ConfigureAwait(false);
