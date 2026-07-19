using UnityEngine;

public class BatController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float FlySpeed = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (vector.x != 0)
        {
            spriteRenderer.flipX = vector.x > 0;
        }
        rb.linearVelocity = vector * FlySpeed;

    }
    void Start()
    {

    }

    void Update()
    {

    }
}
