using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// // PlayerScript requires the GameObject to have a Rigidbody component
// [RequireComponent(typeof(Rigidbody))]
// [RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
  private BoxCollider2D boxCollider2D;
  private SpriteRenderer sr;
  private Rigidbody2D rb2D;
  private Animator animator;
  public float speedX =1.0f;
  public float jumpForce = 10.0f;
  public LayerMask groundLayer;
  public int jumpCount = 2;
  public float flickeringDuration =0.25f;
  readonly int groundParameter = Animator.StringToHash("ground");
  readonly int jumpParameter = Animator.StringToHash("Jump");
  readonly int deadParameter = Animator.StringToHash("dead");
  readonly int slideParameter = Animator.StringToHash("slide");
  readonly int hurtParameter = Animator.StringToHash("hurt");
  protected WaitForSeconds flickeringWait;
  // Start is called before the first frame update
  void Start()
  {
      sr = GetComponent<SpriteRenderer>();
      boxCollider2D = GetComponent<BoxCollider2D>();
      animator = GetComponent<Animator>();
      rb2D = gameObject.GetComponent<Rigidbody2D>();
      animator.SetBool(groundParameter,true);
      flickeringWait = new WaitForSeconds(flickeringDuration);

  }

    // Update is called once per frame
  void Update()
  {
    checkforGround();
  }
  private void FixedUpdate() {
    run();
    
    
  }

  void run(){
    transform.position += new Vector3(1,0,0)*speedX*Time.deltaTime;
  }
  public void jump(){
    if(animator.GetBool(groundParameter) || jumpCount >0){
      rb2D.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
      jumpCount -=1;
    }
    
  }

  // private void OnCollisionEnter2D(Collision2D other) {
  //   if(other.gameObject.layer == groundLayer){
  //     animator.SetBool(groundParameter,true);
  //   }
  
  // }

  private void checkforGround(){
    Bounds boxBounds = boxCollider2D.bounds;
    Vector2 centerBottom = new Vector2(boxBounds.center.x, boxBounds.center.y - boxBounds.extents.y);
    if(Physics2D.Raycast(centerBottom,Vector2.down,0.1f,groundLayer)){
      jumpCount =2;
      animator.SetBool(groundParameter,true);
    }else{
      animator.SetBool(groundParameter,false);
    }

  }

  public void slide(){
    if(animator.GetBool(groundParameter)){
      this.transform.localScale = new Vector3(this.transform.localScale.x*1,this.transform.localScale.y*0.7f,this.transform.localScale.z*1);
      boxCollider2D.size=  new Vector3(boxCollider2D.size.x*1,boxCollider2D.size.y*0.7f);
      animator.SetBool(slideParameter,true);
    }
    
  }
  
  public void noslide(){
    if(animator.GetBool(slideParameter)){
      this.transform.localScale = new Vector3(this.transform.localScale.x*1,this.transform.localScale.y/0.7f,this.transform.localScale.z*1);
      boxCollider2D.size=  new Vector3(boxCollider2D.size.x*1,boxCollider2D.size.y/0.7f);
      animator.SetBool(slideParameter,false);
    }
    
  }

  public void OnHurt(Damager damager, Damageable damageable){
    animator.SetTrigger(hurtParameter);
    damageable.EnableInvulnerability();
    StartCoroutine(Flicker(damageable));
  }

  public void OnDeath(){
    animator.SetTrigger(deadParameter);
  }
  IEnumerator Flicker(Damageable damageable){
      float timer = 0f;

      while (timer < damageable.invulnerabilityDuration)
      {
          sr.enabled = !sr.enabled;
          yield return flickeringWait;
          timer += flickeringDuration;
      }

      sr.enabled = true;
  }










}

