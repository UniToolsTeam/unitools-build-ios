using System;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;

namespace UniTools.Build.iOS
{
    [Serializable]
    public sealed class BoolPlistElement : SerializablePlistElement<bool>
    {
        public override void AddTo(PlistElementDict plistElementDict)
        {
            plistElementDict.SetBoolean(Key, Value);
        }
    }
}
#endif