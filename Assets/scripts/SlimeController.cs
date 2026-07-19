using UnityEngine;

public class SlimeController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float moveSpeed = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnEnable()
    {
        InputTaker.MoveInput += Move;
    }
    void OnDisable()
    {
        InputTaker.MoveInput -= Move;
    }

    void Move(Vector2 vector)
    {
        float x = vector.x;
        animator.SetBool("Moving", x != 0);
        if (x != 0)
        {
            spriteRenderer.flipX = x < 0;
        }
        rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);
    }
}
