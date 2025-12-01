using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float xBound = 4;
    public const float speed = 5.0f;
    public IPlayerInput PlayerInput = new GamePlayerInput();
    

    void Update()
    {
        MovePlayer();
    }
    
    //https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Mathf.Clamp.html
    void MovePlayer()
    {
        float horizontalInput = PlayerInput.HorizontalInput;
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        float clampedX = Mathf.Clamp(transform.position.x, -xBound, xBound);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}

