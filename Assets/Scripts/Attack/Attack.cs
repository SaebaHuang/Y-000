using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Y00 {

  [RequireComponent(typeof(Collider2D))]
  [RequireComponent(typeof(Rigidbody2D))]
  public class Attack : MonoBehaviour {
    public Damage damage = null;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    public virtual void OnTriggerEnter2D(Collider2D other) {
      var creature = other.GetComponent<Creature>();
      if (creature != null) {
        Debug.Log(gameObject.name + " hit " + other.gameObject.name);
        HitCreature(creature);
      }
    }

    protected virtual void HitCreature(Creature creature) {
      if (damage != null && damage.damageSource != creature) {
        creature.BeDamaged(damage);
      }
    }

    protected void DestroySelf() {
      // TODO: 播放攻击消失的动画再 Destroy 自己
      // Destroy(gameObject);
      this.enabled = false;
    }
  }
}