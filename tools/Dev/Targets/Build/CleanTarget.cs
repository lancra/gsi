namespace GitStatusInteractive.Dev.Targets.Build;

internal sealed class CleanTarget : ITarget
{
    public void Setup(Bullseye.Targets targets)
        => targets.Add(
            BuildTargets.Clean,
            "Cleans .NET build artifacts from prior executions.",
            Execute);

    private static async Task Execute()
        => await DotnetCli.Run("clean")
        .ConfigureAwait(false);
}
