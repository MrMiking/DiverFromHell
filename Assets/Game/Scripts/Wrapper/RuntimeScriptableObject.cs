using System;
using UnityEngine;

namespace BT.ScriptablesObject
{
    public class RuntimeScriptableObject<T> : ScriptableObject
    {
        private T _value = default;
        public T Value 
        { 
            get => _value;
            set 
            {
                OnChanged?.Invoke();
                _value = value;
            } 
        }

        public event Action OnChanged;
    }
}