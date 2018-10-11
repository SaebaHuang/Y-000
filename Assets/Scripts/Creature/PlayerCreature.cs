using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Y00 {

  [RequireComponent(typeof(Animator))]
  [RequireComponent(typeof(SpriteRenderer))]
  [RequireComponent(typeof(Rigidbody2D))]
  [RequireComponent(typeof(Collider2D))]
  public class PlayerCreature : Creature {

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    protected override void Start() {
      base.Start();
      try {
        GameManager.Instance.InputAction += InputAction;
      } catch (System.NullReferenceException e) {
        Debug.LogWarning(e.Message);
      }
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    protected void OnDestroy() {
      try {
        GameManager.Instance.InputAction += InputAction;
      } catch (System.NullReferenceException) {
        // Do nothing
      }
    }

    public override void InputAction(Action action) {
      base.InputAction(action);
    }

  }

}