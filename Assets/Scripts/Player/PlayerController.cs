using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float xClamp = 3f;
    [SerializeField] private float zClamp = 3f;
    
    private Rigidbody _rb;
     Vector2 _movement;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    private void HandleMovement()
    {
        Vector3 currPosition = _rb.position;
        Vector3 moveDirection = new Vector3(_movement.x, 0f, _movement.y);
        Vector3 newPosition = currPosition + moveDirection * (Time.fixedDeltaTime * moveSpeed);
        
        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);
        _rb.MovePosition(newPosition);
    }
}

