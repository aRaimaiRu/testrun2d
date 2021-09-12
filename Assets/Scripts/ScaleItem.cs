using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class ScaleItem : MonoBehaviour {
    public float duration;
    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag =="Player"){
            StartCoroutine(CallWhenPickup(other.gameObject));
        }
    }
    IEnumerator CallWhenPickup(GameObject player){
        //playsound ,Effect
        if(pickupEffect){
        GameObject effect = Instantiate(pickupEffect,transform.position,transform.rotation) as GameObject;
        
        }
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        // do something
        player.transform.localScale =new Vector3(player.transform.localScale.x*1.5f,player.transform.localScale.y*1.5f,player.transform.localScale.z*1.5f);
        player.GetComponent<Damageable>().EnableInvulnerability();
        yield return new WaitForSeconds(duration);

        player.GetComponent<Damageable>().DisableInvulnerable();
        player.transform.localScale =new Vector3(player.transform.localScale.x/1.5f,player.transform.localScale.y/1.5f,player.transform.localScale.z/1.5f);
        Destroy(gameObject);
        
    }


    
}