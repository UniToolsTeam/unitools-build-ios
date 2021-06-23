using System;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;

namespace UniTools.Build.iOS
{
    [Serializable]
    public sealed class StringPlistElement : SerializablePlistElement<string>
    {
        public override void AddTo(PlistElementDict plistElementDict)
        {
            plistElementDict.SetString(Key, Value);
        }
    }
}
#endif