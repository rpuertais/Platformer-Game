using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool Grounded = false;
    public bool ShouldJump = false;

    public float JumpHeight;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;
    public float PressTimeToMaxJump;

    public int JumpCount = 0;
    public int MaxJumps = 2;

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
        if (JumpCount >= MaxJumps)
        {
            return;
        }
        if (Grounded)
        {
            JumpCount = 0;
        }

        Grounded = false;
        JumpCount++;
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
        JumpHeight += powerUp.JumpValue;
    }
    public void GroundHitCallBack()
    {
        Grounded = true;
        JumpCount = 0;
        animator.SetBool("IsJumping", false);
    }

    public void GroundNoHitCallBack()
    {
        Grounded = false;
        animator.SetBool("IsJumping", true);
    }
}
