using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace Y00 {

  public class SkillManager : Singleton<SkillManager> {
    [HideInInspector]
    public Dictionary<string, BaseSkill> itemDict;

    [System.Serializable]
    public class _Skill {
      public string id;
    }

    [System.Serializable]
    public class _Skills {
      public _Skill[] data;
    }

    public BaseSkill GetSkillById(string id) {
      BaseSkill skill = null;
      itemDict.TryGetValue(id, out skill);
      return skill;
    }

    public void LoadFromJson(string path) {
      string json =(Resources.Load(path, typeof(TextAsset)) as TextAsset).text;
      itemDict = new Dictionary<string, BaseSkill>();
      var infos = JsonUtility.FromJson<_Skills>(json);

      foreach (var i in infos.data) {
        // Reflection
        Type t = Type.GetType("Y00." + i.id);
        if (t == null) {
          Debug.LogWarning("Missing skill script: `" + i.id + "`");
          continue;
        }
        BaseSkill skill = Activator.CreateInstance(t) as BaseSkill;
        itemDict.Add(i.id, skill);
      }
    }
  }

} // namespace Y00
