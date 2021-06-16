using System;
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