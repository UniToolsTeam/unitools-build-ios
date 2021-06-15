using System;
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