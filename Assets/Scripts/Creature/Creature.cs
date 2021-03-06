﻿using System.Collections;
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

    public Transform groundCheckTransform;

    public float jumpForce = 300f;

    public delegate void OnDeadHandler(Creature creature, Damage damage);
    public event OnDeadHandler OnDead;

    protected new Collider2D collider2D;
    public Collider2D hitBoxCollider2D;

    public int maxJumpTimes = 1;

    public bool initFacingRight;

    protected bool _facingRight;
    public bool facingRight {
      get {
        return _facingRight;
      }

      set {
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        _facingRight = value;
      }
    }

    public bool isGrounded {
      get {
        var grounded = Physics2D.Linecast(transform.position, groundCheckTransform.position, 1 << LayerMask.NameToLayer("Ground"));
        return grounded;
      }
    }

    public CreatureInfo creatureInfo;

    public string[] skillIds;

    [HideInInspector]
    public BaseSkill[] skills;

    // Use this for initialization
    protected virtual void Start() {
      animator = GetComponent<Animator>();
      spriteRenderer = GetComponent<SpriteRenderer>();
      rigidbody2D = GetComponent<Rigidbody2D>();

      collider2D = GetComponent<Collider2D>();

      _facingRight = initFacingRight;

      // Load skills
      if (skillIds != null && skillIds.Length > 0) {
        skills = new BaseSkill[skillIds.Length];
      } else {
        skills = null;
      }
      for (int i = 0; i < skillIds.Length; ++i) {
        skills[i] = SkillManager.Instance.GetSkillById(skillIds[i]);
      }
    }

    // TODO: Only for test
    public GameObject attackObj;

    public virtual void InputAction(Action action) {
      /* Move Begin */
      float dashFactor = 1.0f;
      if (Mathf.Abs(action.horizontal) > 0f) {
        if (action.dash) {
          animator.SetFloat("Speed", 1.5f); // Run
          dashFactor = 2.0f;
        } else {
          animator.SetFloat("Speed", 0.5f); // Walk
        }
      } else {
        animator.SetFloat("Speed", 0f);  // Idle
      }
      Vector2 baseVelocity = Vector2.zero;
      if (action.horizontal > 0f) {
        if (!facingRight)
          facingRight = true;
        baseVelocity.x = 1.0f;
      } else if (action.horizontal < 0f) {
        if (facingRight)
          facingRight = false;
        baseVelocity.x = -1.0f;
      } else {
        baseVelocity.x = 0f;
      }
      Vector2 realVelocity = speedFactor * baseVelocity * dashFactor;
      realVelocity.y = rigidbody2D.velocity.y;
      rigidbody2D.velocity = realVelocity;
      /* Move End */

      /* Attack Begin */
      if (action.skill_0) {
        skills[0].BeInvoked(this);
      }
      if (action.skill_1) {
        skills[1].BeInvoked(this);
      }
      if (action.skill_2) {
        skills[2].BeInvoked(this);
      }
      /* Attack End */

      if (action.jump && isGrounded) {
        animator.SetTrigger("Jump");
        rigidbody2D.AddForce(new Vector2(0, jumpForce));
      }
    }

    public void BeDamaged(Damage damage) {
      // TODO: 具体的伤害计算公式
      if (creatureInfo.currentHp - damage.damage <= 0) {
        creatureInfo.currentHp = 0;
        if (OnDead != null) {
          this.OnDead(this, damage);
        }
      } else {
        Debug.Log("BeDamaged " + damage.damage);
        creatureInfo.currentHp -= damage.damage;
      }
    }
  }
}  // namespace Y00