using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// // PlayerScript requires the GameObject to have a Rigidbody component
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
  public float speedX =1.0f;

  // Start is called before the first frame update
  void Start()
  {

  }

    // Update is called once per frame
  void Update()
  {

  }
  private void FixedUpdate() {
    run();
  }
  void run(){
    transform.position += new Vector3(1,0,0)*speedX*Time.deltaTime;
  }

}

