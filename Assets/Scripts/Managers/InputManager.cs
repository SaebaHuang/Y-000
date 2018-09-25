using UnityEngine;

namespace Y00 {

  public class InputManager : Singleton<InputManager> {
    public Action GetInput() {
      Action action = new Action();
      action.horizontal = Input.GetAxis("Horizontal");
      action.vertical = Input.GetAxis("Vertical");
      action.jump = Input.GetButtonDown("Jump");
      return action;
    }
  }

} // namespace Y00
