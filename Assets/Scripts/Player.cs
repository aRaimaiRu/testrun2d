using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// // PlayerScript requires the GameObject to have a Rigidbody component
// [RequireComponent(typeof(Rigidbody))]
// [RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
  private BoxCollider2D boxCollider2D;
    private Rigidbody2D rb2D;
    private Animator animator;
    public float sppedX =1.0f;
    public float jumpForce = 10.0f;
    public LayerMask groundLayer;
    readonly int groundParameter = Animator.StringToHash("ground");
    readonly int jumpParameter = Animator.StringToHash("Jump");
    readonly int deadParameter = Animator.StringToHash("dead");
    readonly int slideParameter = Animator.StringToHash("slide");
    readonly int velYParameter = Animator.StringToHash("velY");
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator.SetBool(groundParameter,true);

    }

    // Update is called once per frame
    void Update()
    {
      checkforGround();
      setAnimation();
    }
    private void FixedUpdate() {
      run();
      
      
    }

    void run(){
      transform.position += new Vector3(1,0,0)*sppedX*Time.deltaTime;
    }
    public void jump(){
      rb2D.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.layer == groundLayer){
        animator.SetBool(groundParameter,true);
      }
    
    }

    private void checkforGround(){
      Bounds boxBounds = boxCollider2D.bounds;
      Vector2 centerBottom = new Vector2(boxBounds.center.x, boxBounds.center.y - boxBounds.extents.y);
      if(Physics2D.Raycast(centerBottom,Vector2.down,0.1f,groundLayer)){
        animator.SetBool(groundParameter,true);
      }else{
        animator.SetBool(groundParameter,false);
      }

    }
    private void setAnimation(){
      animator.SetFloat(velYParameter,rb2D.velocity.y);
    }



}

