using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 200.0f;

    public Rigidbody2D playerBody;
    // Don't need Jumping
    // private bool isJumping;
    // public bool isGrounded;
    // public float jumpStrength;

    private Animator animator;
    private float jumpTime;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        playerBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        playerBody.freezeRotation = true;    
        jumpTime = 0;
    }

    // Update is called once per frame
    void Update()
    {    
        //isGrounded = gameObject.GetComponentInChildren<GroundCheck>().isGrounded;    
        // if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
        //     isJumping = true;
        // }
        // if(Input.GetKeyDown(KeyCode.W)){
        //     isDucking = true;
        // }
    }
    void FixedUpdate()
    {
        /* MOVEMENT */
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Debug.Log(x);
        Vector3 movement = new Vector3(x, y, 0);
        transform.Translate(movement * speed * Time.fixedDeltaTime);
        // if(x != 0){
        //    animator.Play("PlayerWalk");
        // }
        // if(x == 0){
        //     animator.Play("PlayerIdle");
        //     // gameObject.GetComponent<AudioSource>().Pause();
        // }
        if(x < 0){
            transform.localScale = new Vector3(-0.25f, transform.localScale.y, transform.localScale.z);
            //rotateCharacter(2);
        }
        if(x > 0){
            transform.localScale = new Vector3(0.25f, transform.localScale.y, transform.localScale.z);
            //rotateCharacter(1);
        }
        if(y < 0){
            transform.localScale = new Vector3(transform.localScale.x, -0.25f,  transform.localScale.z);
        }
        if(y > 0){
            transform.localScale = new Vector3(transform.localScale.x, 0.25f,  transform.localScale.z);
        }
        // Jump
        // if(isJumping){
        //     playerBody.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        //     isJumping = false;
        //     //gameObject.GetComponentInChildren<GroundCheck>().isGrounded = false;
        //     jumpTime += Time.deltaTime;
        //     Debug.Log("Jump" + jumpTime);
        //     if(jumpTime > 3){
        //         isGrounded = true;
        //         jumpTime = 0;
        //     }
        // }
    }
    private void rotateCharacter(int dir){
        bool isRotated = false;
        if(dir == 1 && !isRotated){
            transform.Rotate(new Vector3(0,0,90));
            isRotated = true;
        }
        if(dir == 2 && !isRotated){
            transform.Rotate(new Vector3(0,0,-90));
            isRotated = true;
        }
    }

    // void Controls(){

    // }
}
