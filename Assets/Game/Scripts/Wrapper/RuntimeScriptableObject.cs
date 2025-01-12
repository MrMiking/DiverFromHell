using System;
using UnityEngine;

namespace BT.ScriptablesObject
{
    public class RuntimeScriptableObject<T> : ScriptableObject
    {
        public event Action OnChanged;

        private T _value;
        public T Value 
        { 
            get { 
                return _value; 
            } 
            set 
            { 
                _value = value; 
                OnChanged?.Invoke(); 
            } 
        }
    }
}
