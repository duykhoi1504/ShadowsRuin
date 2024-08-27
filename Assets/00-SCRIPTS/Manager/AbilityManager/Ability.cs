using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{

    [System.Serializable]
    public class AbilityStats
    {
        public string desceiption;
        public float value;
        public int cost;

    }
    [SerializeField] private string name;
    [SerializeField] private Sprite image;
    [SerializeField] private bool unClock = false;
    [SerializeField] private float coolDown;
    [SerializeField] private float duration;
    [SerializeField] private float damage;
    [SerializeField] protected int level;
    
   [SerializeField] protected AbilityType abilityType;
    [SerializeField] public List<AbilityStats> abilityStats;

    public AbilityType AbilityType { get => abilityType; set => abilityType = value; }
    public string Name { get => name; set => name = value; }
    public Sprite Image { get => image; set => image = value; }
    public bool UnClock { get => unClock; set => unClock = value; }
    public float CoolDown { get => coolDown; set => coolDown = value; }
    public float Duration { get => duration; set => duration = value; }
    public float Damage { get => damage; set => damage = value; }
    public int Level { get => level; set => level = value; }

    protected virtual void OnEnable()
    {
        ResetData();
    }
    public virtual void Use() { }
    public virtual void UpdateCoolDownTimer(float deltaTime) { }
    public virtual void SetStatsForUpGrade() { }
    public virtual void ConfigAbility() { }

    public virtual void ResetData()
    {
        level = 0;
        unClock=false;
    }


    // public abstract bool CanUseSkill();
}
