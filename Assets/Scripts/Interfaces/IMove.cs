using UnityEngine;

public interface IMove
{
    float MoveSpeed { get; }

    void Move(Vector2 dir);
}