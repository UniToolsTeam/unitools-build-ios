using System;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace UniTools.Build.iOS
{
    [Serializable]
    public abstract class SerializablePlistElement<TValue> : IPlistElement
    {
        [SerializeField] protected string Key;
        [SerializeField] protected TValue Value;

        public abstract void AddTo(PlistElementDict plistElementDict);
    }
}