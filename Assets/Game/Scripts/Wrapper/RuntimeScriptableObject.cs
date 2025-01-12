using System;
using UnityEngine;

namespace BT.ScriptablesObject
{
    public class RuntimeScriptableObject<T> : ScriptableObject
    {
        private T _value;
        public T Value { get { return _value; } set { _value = value; OnChanged?.Invoke(); } }
        public void UpdateValue(Action<T> updateAction)
        {
            updateAction.Invoke(_value);
            OnChanged?.Invoke();
        }

        public event Action OnChanged;
    }
}
