namespace Y00 {

[System.Serializable]
public abstract class BaseSkill {
  public abstract void BeInvoked(Creature invoker);
  public int mpCost;
}

}
