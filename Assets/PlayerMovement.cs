using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //variable to improve performance by not making you load Rigid over and over.  Put outside start and Update so accessable by inner code
    private Rigidbody2D rigid;
    private Animator ani;
    private SpriteRenderer sprite;
    private float directionX = 0f;
    private float moveSpeed = 7f; 
    private float jumpForce = 14f;

    // Start is called before the first frame update we private as they are only useful in the script
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame we private as they are only useful in the script
    private void Update()
    {
        //Joystick or sensitivity support.  GetAxis has sliding, get axis raw does not
        directionX = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(directionX * 7f, rigid.velocity.y);




        //using GetButton uses Unity's input manager
        if (Input.GetButtonDown("Jump"))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 14f);
        }

        UpdateAnimation();


    }
    //making a new method for better organization
    private void UpdateAnimation()
    {
        //left right movement
        if (directionX > 0f)
        {
            ani.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (directionX < 0f)
        {
            ani.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            ani.SetBool("running", false);
        }
    }
}
