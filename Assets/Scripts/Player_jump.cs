using UnityEngine;
using UnityEngine.InputSystem;

public class Player_jump : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpPower;
    private InputAction jumpAction;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jumpAction = new InputAction("Jump", InputActionType.Button, "<Keyboard>/space");
        jumpAction.Enable();
    }

    private void Update()
    {
        if (jumpAction.triggered && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }
}