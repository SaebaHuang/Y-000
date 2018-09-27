namespace Y00 {

  // This may changed to float
  using StatsUnitType = System.Int32;

  [System.Serializable]
  public class Damage {
    public Creature damageSource;
    public StatsUnitType damage;
  }
}