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
        public UnityEvent OnDeath;

        private bool Invulnerable;
        public float invulnerabilityDuration=3;

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
                        OnTakeDamage.Invoke(damager,this);
                }else if(currentHealth<0) {
                        OnDeath.Invoke();
                        currentHealth = 0;
                }else{
                   OnTakeDamage.Invoke(damager,this);
                }
                OnHealthSet.Invoke(this);
        }

    
}
