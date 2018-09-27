namespace Y00 {

  // This may be changed to float
  using StatsUnitType = System.Int32;

  [System.Serializable]
  public class CreatureInfo {
    [System.Serializable]
    public class Stats {
      public StatsUnitType maxHp;
      public StatsUnitType maxMp;
      public StatsUnitType armor;
      public StatsUnitType attack;
    }

    public Stats baseStats;
    public Stats currentStats {
      get {
        // TODO: CurrentStats is calculated with baseStats and other factors
        return baseStats;
      }
    }

    public Weapon weapon;
    public StatsUnitType currentHp;
    public StatsUnitType currentMp;
  }
}