using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Y00 {

  [RequireComponent(typeof(Animator))]
  [RequireComponent(typeof(SpriteRenderer))]
  [RequireComponent(typeof(Rigidbody2D))]
  [RequireComponent(typeof(Collider2D))]
  public class Creature : MonoBehaviour {

    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected new Rigidbody2D rigidbody2D;
    public float speedFactor = 1.0f;

    protected bool _facingRight;
    public bool facingRight {
      get {
        return _facingRight;
      }

      set {
        spriteRenderer.flipX = !value;
        _facingRight = value;
      }
    }

    public CreatureInfo creatureInfo;

    // Use this for initialization
    protected virtual void Start() {
      animator = GetComponent<Animator>();
      spriteRenderer = GetComponent<SpriteRenderer>();
      rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public virtual void InputAction(Action action) {
      if (Mathf.Abs(action.horizontal) > 0f) {
        if (Input.GetKey("left shift")) {
          animator.SetFloat("Speed", 1.5f); // Run
        } else {
          animator.SetFloat("Speed", 0.5f); // Walk
        }
      } else {
        animator.SetFloat("Speed", 0f);  // Idle
      }
      Vector2 baseVelocity = Vector2.zero;
      if (action.horizontal > 0f) {
        facingRight = true;
        baseVelocity.x = 1.0f;
      } else if (action.horizontal < 0f) {
        facingRight = false;
        baseVelocity.x = -1.0f;
      } else {
        baseVelocity.x = 0f;
      }
      Vector2 realVelocity = speedFactor * baseVelocity;
      rigidbody2D.velocity = realVelocity;
    }

    public void BeDamaged(Damage damage) {

    }

  }
}  // namespace Y00