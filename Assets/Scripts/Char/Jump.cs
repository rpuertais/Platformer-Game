using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    public bool grounded = false;
    public bool shouldJump = false;

    public float JumpHeight;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;
    public float PressTimeToMaxJump;

    private float jumpStartedTime;

    private float lastVelocityY;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (IsPeakReached()) TweakGravity();
    }

    public void OnJumpStarted()
    {
        var velocity = new Vector2(rigidbody.linearVelocity.x, GetJumpForce());
        rigidbody.linearVelocity = velocity;
        jumpStartedTime = Time.time;
    }

    public void OnJumpFinished()
    {
        float fractionOfTimePressed = 1 / Mathf.Clamp01((Time.time - jumpStartedTime) / PressTimeToMaxJump);
        rigidbody.gravityScale *= fractionOfTimePressed;
    }

    /*
    public void GroundHitCallBack()
    {
        grounded = true;
    }

    public void GroundNoHitCallBack()
    {
        grounded = false;
    }*/

    private void TweakGravity()
    {
        rigidbody.gravityScale *= 1.2f;
    }

    private bool IsPeakReached()
    {
        bool reached = ((lastVelocityY * rigidbody.linearVelocity.y) < 0);
        lastVelocityY = rigidbody.linearVelocity.y;

        return reached;
    }

    private float GetJumpForce()
    {
        return 2 * JumpHeight * SpeedHorizontal / DistanceToMaxHeight;
    }
}
