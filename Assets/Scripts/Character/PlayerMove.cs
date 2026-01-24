using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5.0f;

    Rigidbody2D rb;
    private float _horizontalDir; // Horizontal move direction value [-1, 1]
    private Animator animator;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = _horizontalDir * Speed;
        rb.linearVelocity = velocity;

        animator.SetFloat("XVelocity", Mathf.Abs(velocity.x));   
    }

    void OnMove(InputValue value)
    {
        var inputVal = value.Get<Vector2>();
        _horizontalDir = inputVal.x;
    }


}
