using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace UniTools.Build.iOS
{
    [CreateAssetMenu(
        fileName = nameof(ModifyInfoPlist),
        menuName = nameof(UniTools) + "/Build/Steps/" + nameof(iOS) + "/Post/" + nameof(ModifyInfoPlist)
    )]
    public sealed class ModifyInfoPlist : ScriptablePostBuildStep
    {
        [SerializeField] private BoolPlistElement[] m_bool = default;
        [SerializeField] private FloatPlistElement[] m_float = default;
        [SerializeField] private IntPlistElement[] m_int = default;
        [SerializeField] private StringPlistElement[] m_string = default;

        public override async Task Execute(string pathToBuiltProject)
        {
            await Task.CompletedTask;

            List<IPlistElement> elements = new List<IPlistElement>();
            if (m_bool != null)
            {
                elements.AddRange(m_bool);
            }

            if (m_float != null)
            {
                elements.AddRange(m_float);
            }

            if (m_int != null)
            {
                elements.AddRange(m_int);
            }

            if (m_string != null)
            {
                elements.AddRange(m_string);
            }

            string plistPath = Path.Combine(pathToBuiltProject, "Info.plist");
            PlistDocument plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));
            foreach (IPlistElement element in elements)
            {
                element.AddTo(plist.root);
            }

            File.WriteAllText(plistPath, plist.WriteToString());
        }
    }
}