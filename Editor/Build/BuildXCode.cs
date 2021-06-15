using System;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace UniTools.Build.iOS
{
    [CreateAssetMenu(
        fileName = nameof(BuildXCode),
        menuName = nameof(UniTools) + "/Build/Steps/" + nameof(iOS) + "/" + nameof(BuildXCode)
    )]
    public sealed class BuildXCode : ScriptableBuildStepWithOptions
    {
        [SerializeField] private bool m_symlinkUnityLibraries = true;
        [SerializeField] private bool m_tryAppend = true;

        public override BuildTarget Target => BuildTarget.iOS;

        public override async Task<BuildReport> Execute()
        {
            BuildPlayerOptions buildPlayerOptions = Options;

            if (m_symlinkUnityLibraries)
            {
                buildPlayerOptions.options |= BuildOptions.SymlinkLibraries;
            }

            if (m_tryAppend)
            {
                switch (UnityEditor.BuildPipeline.BuildCanBeAppended(buildPlayerOptions.target, buildPlayerOptions.locationPathName))
                {
                    case CanAppendBuild.Unsupported:
                        throw new InvalidOperationException($"The build target {buildPlayerOptions.target} does not support build appending.");
                    case CanAppendBuild.No:
                        Debug.Log($"{nameof(BuildXCode)}: the build can not be appended, it will be replaced.");

                        break;
                    case CanAppendBuild.Yes:
                        buildPlayerOptions.options |= BuildOptions.AcceptExternalModificationsToPlayer;

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            BuildReport report = UnityEditor.BuildPipeline.BuildPlayer(buildPlayerOptions);

            await Task.CompletedTask;

            return report;
        }
    }
}