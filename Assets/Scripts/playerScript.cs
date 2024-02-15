using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public LayerMask whatIsGround;
    public Transform groundCheck;
    private bool Grounded;
    private float h, v;
    private bool jump;

    public float moveSpeed;
    public float jumpForce; 
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    PlayerInputs();

    }
    void FixedUpdate(){
        PlayerJump();
        CheckGround();
        PlayerWalk();
    }
    void CheckGround(){
     Grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround); 
    }
    void PlayerInputs()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && Grounded )
        {
            
            jump = true;
        }
    }
    void PlayerJump(){
        if( jump){
            jump = false;
        playerRb.velocity = Vector2.up * jumpForce;
        }
    }
    void PlayerWalk(){
         playerRb.velocity = new Vector2(h * Time.fixedDeltaTime * moveSpeed, playerRb.velocity.y);
    }
         
}
