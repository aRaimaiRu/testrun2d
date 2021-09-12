using System;
using UnityEngine;
using UnityEngine.Events;
public class TriggerArea : MonoBehaviour {
    [Serializable]
    public class PlayerEvent : UnityEvent<Player>
        { }

    public PlayerEvent OnPlayerEnter;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<Player>()){
            OnPlayerEnter.Invoke(other.gameObject.GetComponent<Player>());
        }
        
    }
    
}
