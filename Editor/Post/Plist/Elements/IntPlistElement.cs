using System;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;

namespace UniTools.Build.iOS
{
    [Serializable]
    public sealed class IntPlistElement : SerializablePlistElement<int>
    {
        public override void AddTo(PlistElementDict plistElementDict)
        {
            plistElementDict.SetInteger(Key, Value);
        }
    }
}
#endif