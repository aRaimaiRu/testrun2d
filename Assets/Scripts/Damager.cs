using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Damager : MonoBehaviour {
    [Serializable]
    public class DamagableEvent : UnityEvent<Damager, Damageable>
        { }
    protected Collider2D m_LastHit;
    public Collider2D LastHit { get { return m_LastHit; } }

    public int damage = 1;
    public Vector2 offset = new Vector2(1.5f, 1f);
    public Vector2 size = new Vector2(2.5f, 1f);
    public LayerMask hittableLayers;
    protected Transform m_DamagerTransform;
    protected ContactFilter2D m_AttackContactFilter;
    protected Collider2D[] m_AttackOverlapResults = new Collider2D[10];
    public DamagableEvent OnDamageableHit;

    void Awake()
    {
        m_AttackContactFilter.layerMask = hittableLayers;
        m_AttackContactFilter.useLayerMask = true;

        m_DamagerTransform = transform;
    }
    private void FixedUpdate() {
        Vector2 scale = m_DamagerTransform.lossyScale;
        Vector2 facingOffset = Vector2.Scale(offset, scale);
        Vector2 scaledSize = Vector2.Scale(size, scale);
        Vector2 pointA = (Vector2)m_DamagerTransform.position + facingOffset - scaledSize * 0.5f;
        Vector2 pointB = pointA + scaledSize;

        int hitCount = Physics2D.OverlapArea(pointA, pointB, m_AttackContactFilter, m_AttackOverlapResults);

        for (int i = 0; i < hitCount; i++)
        {
            m_LastHit = m_AttackOverlapResults[i];
            Damageable damageable = m_LastHit.GetComponent<Damageable>();

            if (damageable)
            {
                OnDamageableHit.Invoke(this, damageable);
                damageable.TakeDamage(this);
            }
        }
    }
        
}
