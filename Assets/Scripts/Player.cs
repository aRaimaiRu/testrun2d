using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// // PlayerScript requires the GameObject to have a Rigidbody component
// [RequireComponent(typeof(Rigidbody))]
// [RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    public float sppedX =1.0f;
    public float jumpForce = 10.0f;
    readonly int groundParameter = Animator.StringToHash("ground");
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator.SetBool(groundParameter,true);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate() {
      run();
      
    }

    void run(){
      transform.position += new Vector3(1,0,0)*sppedX*Time.deltaTime;
    }


}

