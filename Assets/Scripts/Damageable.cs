using System;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour {
        public int startingHealth =3;
        public int maxHealth =4;
        public int currentHealth;
        private bool Invulnerable;
        public float invulnerabilityDuration=3;
        public UnityEvent<Damageable> OnHealthSet;
        public UnityEvent<Damager, Damageable> OnTakeDamage;
        public UnityEvent<int, Damageable> OnGainHealth;
        public UnityEvent OnDeath;


        private void OnEnable() {
                currentHealth = startingHealth;
                OnHealthSet.Invoke(this);
                DisableInvulnerable();
        }

        public void DisableInvulnerable(){
                Invulnerable=false;
        }
        public void EnableInvulnerability(){
                Invulnerable=true;
        }

        public void TakeDamage(Damager damager){
                if(Invulnerable || currentHealth <= 0){
                        return;
                }
                currentHealth -= damager.damage;
                if(currentHealth >maxHealth){
                        currentHealth = maxHealth;
                }else if(currentHealth<0) {
                        OnDeath.Invoke();
                        currentHealth = 0;
                }
                OnTakeDamage.Invoke(damager,this);
                OnHealthSet.Invoke(this);
        }

    
}
