using System.IO;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace UniTools.Build.iOS
{
    public abstract class DistributeIosApplicationStep : IosPostBuildStep
    {
        [SerializeField] private string m_bundleIdentifier = default;
        [SerializeField] private bool m_uploadBitcode = false;
        [SerializeField] private bool m_uploadSymbols = false;

        protected string ExportOptionsPath(string root)
        {
            const string fileName = "ExportOptions.plist";

            return Path.Combine(root, fileName);
        }

        protected PlistDocument CreateExportOptions()
        {
            PlistDocument plist = new PlistDocument();
            PlistElementDict rootDict = plist.root;

            rootDict.SetBoolean("generateAppStoreInformation", false);

            PlistElementDict provisioningProfiles = rootDict.CreateDict("provisioningProfiles");
            provisioningProfiles.SetString(m_bundleIdentifier, ProvisioningProfileName);
            rootDict.SetString("signingCertificate", "Apple Distribution");
            rootDict.SetString("signingStyle", "manual");
            rootDict.SetString("teamID", TeamId);
            rootDict.SetBoolean("stripSwiftSymbols", true);
            rootDict.SetBoolean("uploadBitcode", m_uploadBitcode);
            rootDict.SetBoolean("uploadSymbols", m_uploadSymbols);

            return plist;
        }
    }
}