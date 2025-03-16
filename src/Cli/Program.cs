using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using GitStatusInteractive.Cli;
using GitStatusInteractive.Cli.Commands;

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
    .UseDependencyInjection(services => { })
    .Build()
    .InvokeAsync(args)
    .ConfigureAwait(false);
