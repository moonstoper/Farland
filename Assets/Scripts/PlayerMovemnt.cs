using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{

    // Start is called before the first frame update
    float input, _y;
    Rigidbody2D rb;
    Animator anim;
    public float speed, jumpforce;
    bool faceright = true;

    bool isGrounded;
    public LayerMask whatisground;
    public Transform groundCheck;
    public float checkradius;
    bool isJumping;
    float _jumpcounter;
    public float jumpTime;

    bool isTouchingFront;
    public Transform frontCheck;
    bool wallsliding;
    public float wallslidingspeed;
    bool walljumping;
    public float xwallforce;
    public float ywallforce;
    public float walljumpTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        this.transform.position = FindObjectOfType<GameEngine>().lastcheckpoint;


    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        if (input == 0)
        {

            anim.SetBool("isRunning", false);

        }
        else anim.SetBool("isRunning", true);


        if (input > 0 && faceright == false)
        {
            Flip();
        }

        if (input < 0 && faceright == true)
        {
            Flip();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkradius, whatisground);
        //
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
           
            anim.SetTrigger("takeoff");
            rb.velocity = Vector2.up * jumpforce;
            isJumping = true;
            _jumpcounter = jumpTime;
        }

        if (isGrounded == true)
        {
            
            anim.SetBool("isjumping", false);
            
        }
        else
        {   
            anim.SetBool("isjumping", true);
            
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (_jumpcounter > 0)
            {
                rb.velocity = Vector2.up * jumpforce;
                _jumpcounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkradius, whatisground);
        if(isTouchingFront)
        Debug.Log("touched front");
        if (isTouchingFront == true && isGrounded == false && input != 0)
        {   anim.SetTrigger("onwall");
            anim.SetBool("wallhug",true);
            wallsliding = true;
        }
        else
        {
            wallsliding = false;
            anim.SetBool("wallhug",false);
        }

        if (wallsliding)
        {   
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallslidingspeed, float.MaxValue));

            Flip();
        }

        if (Input.GetKey(KeyCode.Space) && wallsliding == true)
        {
            walljumping = true;

            Invoke("SetWallJumptoFalse", walljumpTime);
        }
        if (walljumping)
        {
            
            rb.velocity = new Vector2(xwallforce * -input, ywallforce); //for zigzag jumping add ;
        }
    }

    public void Flip()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        faceright = !faceright;
    }

    public void SetWallJumptoFalse()
    {
        walljumping = false;
    }
}
