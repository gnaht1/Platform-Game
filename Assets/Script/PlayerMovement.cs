using UnityEngine;

public class PlayerControllerSimple : MonoBehaviour
{


    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer; // Boxcast
    [SerializeField] private LayerMask wallLayer;
    // Thành phần Animator
    private Animator anim;
    // Thành phần Rigidbody2D
    private Rigidbody2D body;
    // Thành phần Boxcollider2D
    private BoxCollider2D boxCollider;
    //Create delay for each wall jump
    private float wallJumpCooldown;
    private float horizontalInput;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");

        // Thay đổi hướng của nhân vật mà không thay đổi chiều cao (y) hoặc độ sâu (z)
        if (horizontalInput > 0.01f)
        {
            // Đảm bảo nhân vật luôn nhìn về bên phải (x là số dương)
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            // Đảm bảo nhân vật luôn nhìn về bên trái (x là số âm)
            transform.localScale = new Vector3(-1,1,1);
        }

        
        //Wall jump logic
        if (wallJumpCooldown > 0.2f)
        {
            
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                //If the player jump on a wall, he will get stuck and not be able to fall down
                body.gravityScale = 0;
                body.velocity = Vector2.zero;

            }
            else
            {
                body.gravityScale = 3;
            }

            if (Input.GetKey(KeyCode.Space) && isGrounded()) // allow player to jump only if grounded
            {
                Jump();
            }
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if(onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                //10: the power which the player will be pushed away from the wall
                //0: the power which the player will be pushed up
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                //flip the player
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }
      
            wallJumpCooldown = 0;

            

        }

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
