using UnityEngine;

namespace Y00 {

  public class InputManager : Singleton<InputManager> {
    public Action GetInput() {
      Action action = new Action();
      action.horizontal = Input.GetAxis("Horizontal");
      action.vertical = Input.GetAxis("Vertical");
      action.jump = Input.GetButtonDown("Jump");
      action.dash = Input.GetButton("Dash");
      action.skill_0 = Input.GetButton("Skill 0");
      action.skill_1 = Input.GetButton("Skill 1");
      action.skill_2 = Input.GetButton("Skill 2");
      return action;
    }
  }

} // namespace Y00
