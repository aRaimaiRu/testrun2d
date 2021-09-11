using System;
using UnityEngine;
using UnityEngine.Events;




public class Damageable : MonoBehaviour {
        [Serializable]
        public class HealthEvent : UnityEvent<Damageable>
        { }

        [Serializable]
        public class DamageEvent : UnityEvent<Damager, Damageable>
        { }

        [Serializable]
        public class HealEvent : UnityEvent<int, Damageable>
        { }

        public int startingHealth =3;
        public int maxHealth =4;
        public int currentHealth;

        public HealthEvent OnHealthSet;
        public DamageEvent OnTakeDamage;
        public HealEvent OnGainHealth;

        private bool Invulnerable;
        public float invulnerabilityDuration=3;

        private void OnEnable() {
                currentHealth = startingHealth;
                OnHealthSet.Invoke(this);
                DisableInvulnerable();
        }

        private void DisableInvulnerable(){
                Invulnerable=false;
        }

        public void TakeDamage(Damager damager){
                if(Invulnerable || currentHealth <= 0){
                        return;
                }
                currentHealth -= damager.damage;
                if(currentHealth >maxHealth){
                        currentHealth = maxHealth;
                }else if(currentHealth<0) {
                        currentHealth = 0;
                }
                OnTakeDamage.Invoke(damager,this);
                OnHealthSet.Invoke(this);
        }

    
}
