using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpeedItem : MonoBehaviour {
    public float duration;
    public GameObject pickupEffect;
    public float increaseSpeed;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag =="Player"){
            StartCoroutine(CallWhenPickup(other.gameObject));
        }
    }

    IEnumerator CallWhenPickup(GameObject player){
        //playsound ,Effect
        if(pickupEffect){
            Instantiate(pickupEffect,transform.position,transform.rotation);
        }
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        // do something
        player.GetComponent<Player>().speedX +=increaseSpeed;

        yield return new WaitForSeconds(duration);
        player.GetComponent<Player>().speedX -=increaseSpeed;
        Destroy(gameObject);
    }
}
