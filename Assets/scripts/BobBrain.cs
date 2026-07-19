using UnityEngine;

public class BobBrain : MonoBehaviour
{
    // FOR GAMEOBJECT
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // FOR MOVEMENT
    [SerializeField] float moveSpeed = 3f;
    private bool IsMoving = true;
    private int direction = 1;

    private bool grounded;

    [SerializeField]private float jumpForce = 7f;

    // FOR RAYCAST
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float checkDist = 0.43f;

    //FOR GROUND CHECK
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDist;


    // FOR WHISTLE CONTROL
    [SerializeField] private float whistleWindow = 0.25f;
    private bool waitingForSecondWhistle = false;
    private float whistleTimer = 0f;


    //Checking Raycast through external function that returns yes/no     
    private bool IsWallAhead()
    {
        RaycastHit2D hit = Physics2D.Raycast(wallCheck.position, Vector2.right * direction, checkDist, LayerMask.GetMask("Default"));

        Debug.DrawRay(
        wallCheck.position,
        Vector2.right * direction * checkDist,
        Color.red
    );

        return hit.collider != null;

    }

    //Turning Around and flipping the wallCheck
    private void TurnAround()
    {
        direction *= -1;

        spriteRenderer.flipX = direction < 0;

        wallCheck.localPosition = new Vector3(
            -wallCheck.localPosition.x,
            wallCheck.localPosition.y,
            wallCheck.localPosition.z
        );
    }


    // GROUND CHECK
    private bool isGrounded()
    {
        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position,Vector2.down,groundCheckDist,LayerMask.GetMask("Default"));

        Debug.DrawRay(
        groundCheck.position,
        Vector2.down * groundCheckDist,
        Color.green);

        return ground.collider != null;
    }

    // WHEN WHISTLE IS GIVEN BY InputTaker.cs
    public void GotWhistle()
    {
        Debug.Log("GOT WHISTLE WUHUUU");
        // IsMoving = !IsMoving;   //Flipping IsMoving Flag
        if (!waitingForSecondWhistle)
        {
            whistleTimer = whistleWindow;

            Debug.Log("FIRST REGISTERED");

            waitingForSecondWhistle = true;
        }
        else
        {
            Debug.Log("GOT SECOND WHISTLE");
            waitingForSecondWhistle = false;
            OnSecondWhistle(); // GOT THE SECOND WHISTLE
        }

    }

    private void OnSecondWhistle()
    {
        if (!grounded)
        {
            return;
        }
        rb.linearVelocity = new Vector2(rb.linearVelocity.x,jumpForce);
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //initiation the rigidbody component
    }

    public void Die()
    {
        Debug.Log("OH NO BoB DIED");
    }
    void Update()
    {
        grounded = isGrounded();
        animator.SetBool("Moving", IsMoving);
        animator.SetBool("Grounded",grounded);
        if (IsWallAhead())// meaning we need to change direction
        {
            TurnAround();
        }
        if (waitingForSecondWhistle)
        {
            whistleTimer -= Time.deltaTime;


            if (whistleTimer <= 0f)
            {
                waitingForSecondWhistle = false;
                IsMoving =! IsMoving;// GOT THE FIRST WHISTLE BUT NO SECOND...
                Debug.Log("TIMER ENDED");
            }


        }
        
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * (IsMoving ? moveSpeed : 0f), rb.linearVelocity.y);//physics movement ...takes VelX and VelY...Using ternary operator to decide MoveSpeed or zero
    }

}
