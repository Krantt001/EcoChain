using UnityEngine;

public class PlayerBehaviour : IActionProvider
{
    public Vector2 Direction
    {
        get
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            var verticalInput = Input.GetAxisRaw("Vertical");
            return new Vector2(horizontalInput, verticalInput).normalized;
        }
    }

    public bool Interacted => Input.GetKeyDown(KeyCode.E);
}