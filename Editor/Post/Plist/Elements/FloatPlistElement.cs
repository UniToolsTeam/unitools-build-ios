using System;
using UnityEditor.iOS.Xcode;

namespace UniTools.Build.iOS
{
    [Serializable]
    public sealed class FloatPlistElement : SerializablePlistElement<float>
    {
        public override void AddTo(PlistElementDict plistElementDict)
        {
            plistElementDict.SetReal(Key, Value);
        }
    }
}