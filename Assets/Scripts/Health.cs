using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public GameObject HeartPrefab;
    public float HeartIconWidth=10f;
    public Damageable representDamageable;
    private GameObject[] allIcon;

    void Start(){
        for(int i =0;i<representDamageable.maxHealth;i++){
            GameObject healthIcon = Instantiate(HeartPrefab);
            Debug.Log(healthIcon);
            healthIcon.transform.SetParent(transform);
            RectTransform healthIconRect = healthIcon.transform as RectTransform;
            healthIconRect.anchoredPosition = Vector2.zero;
            healthIconRect.sizeDelta = new Vector2(100,100);
  
            healthIconRect.anchorMin += new Vector2(HeartIconWidth, 0f) * i;
            healthIconRect.anchorMax += new Vector2(HeartIconWidth, 0f) * i;
            allIcon[i] = healthIcon.gameObject;
        }
        activeHeart(representDamageable.currentHealth);
        
    }
    public void activeHeart(int curHealth){
        for(int i =0;i<representDamageable.maxHealth;i++){
            if(i<curHealth){
                allIcon[i].SetActive(true);
            }else{
                allIcon[i].SetActive(false);
            }
        }

        
    }

    public void ChangeHitPointUI(Damageable damageable){
        activeHeart(damageable.currentHealth);

    }

}