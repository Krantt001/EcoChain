using UnityEngine;

public class AIBehaviour : IActionProvider
{
    public Vector2 Direction
    {
        get
        {
            var horizontalInput = Random.Range(-1f, 1f);
            var verticalInput = Random.Range(-1f, 1f);
            return new Vector2(horizontalInput, verticalInput).normalized;
        }
    }

    public bool Interacted => true;
}