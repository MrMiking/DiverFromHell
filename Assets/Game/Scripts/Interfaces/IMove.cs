using UnityEngine;
public interface IMove
{
    void Move(Vector3 direction);
    void Disable();
    void Enable();
}