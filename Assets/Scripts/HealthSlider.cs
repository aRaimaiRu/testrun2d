using UnityEngine;
using UnityEngine.UI;
public class HealthSlider : MonoBehaviour {
    public Slider slider;
    public Damageable representDamageable;


    public void change(Damageable damageable){
        slider.maxValue = representDamageable.maxHealth;
        slider.value = representDamageable.currentHealth;

    }


}