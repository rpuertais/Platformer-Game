using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool grounded = false;
    public bool shouldJump = false;

    public float JumpHeight;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;
    public float PressTimeToMaxJump;
    public int jumpCount = 0;
    public int maxJumps = 2;
    private float jumpStartedTime;

    private float lastVelocityY;
    private Animator animator;


    private void OnEnable()
    {
        PowerUp.OnPowerCollected += UpdateJump;
    }

    private void OnDisable()
    {
        PowerUp.OnPowerCollected -= UpdateJump;
    }


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (IsPeakReached()) TweakGravity();
    }

    public void OnJumpStarted()
    {
        if (jumpCount >= maxJumps)
        {
            return;
        }
        if (grounded)
        {
            jumpCount = 0;
        }


        grounded = false;
        jumpCount++;
        SetGravity();
        var velocity = new Vector2(rb.linearVelocity.x, GetJumpForce());
        rb.linearVelocity = velocity;
        jumpStartedTime = Time.time;

        GetComponent<PlayerAudio>().PlayJump();
    }

    public void OnJumpFinished()
    {
        float fractionOfTimePressed = 1 / Mathf.Clamp01((Time.time - jumpStartedTime) / PressTimeToMaxJump);
        rb.gravityScale *= fractionOfTimePressed;
    }

    private void TweakGravity()
    {
        rb.gravityScale *= 1.2f;
    }

    private bool IsPeakReached()
    {
        bool reached = ((lastVelocityY * rb.linearVelocity.y) < 0);
        lastVelocityY = rb.linearVelocity.y;

        return reached;
    }

    private float GetJumpForce()
    {
        return 2 * JumpHeight * SpeedHorizontal / DistanceToMaxHeight;
    }

    private void SetGravity()
    {
        var grav = 2 * JumpHeight * (SpeedHorizontal * SpeedHorizontal) / (DistanceToMaxHeight * DistanceToMaxHeight);
        rb.gravityScale = grav / 9.81f;
    }

    private void UpdateJump(PowerUp powerUp)
    {
        JumpHeight += powerUp.jumpValue;
    }
    public void GroundHitCallBack()
    {
        grounded = true;
        jumpCount = 0;
        animator.SetBool("IsJumping", false);
    }

    public void GroundNoHitCallBack()
    {
        grounded = false;
        animator.SetBool("IsJumping", true);
    }
}
