using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using System;
using System.Linq;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main() => Execute<Build>(x => x.RunIntegrationTests);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;
    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            GlobDirectories(Solution.Directory, "src/**/bin", "src/**/obj").ForEach(DeleteDirectory);
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(a => a.SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(a => a.SetProjectFile(Solution).EnableNoRestore());
        });
    Target RunUnitTests => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            var testProjects = Solution.AllProjects
                .Where(a =>
                    a.Name.EndsWith("test.unit", StringComparison.OrdinalIgnoreCase))
                .ToList();

            Logger.Info($"{testProjects.Count} unit test projects have found");

            foreach (var testProject in testProjects)
            {
                DotNetTest(a =>
                    a.SetProjectFile(testProject)
                        .EnableNoBuild()
                        .EnableNoRestore());
            }
        });

    Target RunIntegrationTests => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() =>
        {
            var testProjects = Solution.AllProjects
                .Where(a =>
                    a.Name.EndsWith("test.Integration", StringComparison.OrdinalIgnoreCase))
                .ToList();

            Logger.Info($"{testProjects.Count} integration test projects have found");

            foreach (var testProject in testProjects)
            {
                DotNetTest(a =>
                    a.SetProjectFile(testProject)
                        .EnableNoBuild()
                        .EnableNoRestore());
            }
        });

}
