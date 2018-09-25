using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Y00 {

  [RequireComponent(typeof(Animator))]
  [RequireComponent(typeof(SpriteRenderer))]
  [RequireComponent(typeof(Rigidbody2D))]
  [RequireComponent(typeof(Collider2D))]
  public class PlayerControllable : Controllable {

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    protected override void Start() {
      base.Start();
      GameManager.Instance.InputAction += InputAction;
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    protected void OnDestroy() {
      GameManager.Instance.InputAction -= InputAction;
    }

  }

}