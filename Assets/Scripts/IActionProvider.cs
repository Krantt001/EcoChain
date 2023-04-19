using UnityEngine;

public interface IActionProvider
{
    public Vector2 Direction { get; }
    public bool Interacted { get; }
}