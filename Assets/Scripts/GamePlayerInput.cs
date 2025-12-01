using UnityEngine;

public class GamePlayerInput : IPlayerInput
{
    public float HorizontalInput
    {
        get { return Input.GetAxis("Horizontal"); }
    }
}