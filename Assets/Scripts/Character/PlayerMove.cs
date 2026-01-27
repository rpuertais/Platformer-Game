using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    Rigidbody2D rb;

    private float horizontalDir;

    private Animator animator;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        animator.SetFloat("XVelocity", Mathf.Abs(horizontalDir));
        Vector2 velocity = rb.linearVelocity;
        velocity.x = horizontalDir * speed;
        rb.linearVelocity = velocity;
    }

    void OnMove(InputValue value)
    {
        var inputVal = value.Get<Vector2>();
        horizontalDir = inputVal.x;
    }
}
