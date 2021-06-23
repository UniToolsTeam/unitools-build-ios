#if UNITY_IOS
using UnityEditor.iOS.Xcode;

namespace UniTools.Build.iOS
{
    public interface IPlistElement
    {
        void AddTo(PlistElementDict plistElementDict);
    }
}
#endif