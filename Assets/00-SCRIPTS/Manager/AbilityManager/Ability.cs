using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject 
{

    [System.Serializable]
    public class AbilityStats{
        public string desceiption;
        public float value;
    }
    [SerializeField] private string name;
    [SerializeField] private Sprite image;
    [SerializeField] private bool unClock=false;
    [SerializeField] private float coolDown;
    [SerializeField] private float duration;
    [SerializeField] private float damage;
    [SerializeField] protected int level;

    protected virtual void OnEnable() {
        level=0;
    }
    [SerializeField] protected List<AbilityStats> abilityStats;
    
    public string Name { get => name; set => name = value; }
    public Sprite Image { get => image; set => image = value; }
    public bool UnClock { get => unClock; set => unClock = value; }
    public float CoolDown { get => coolDown; set => coolDown = value; }
    public float Duration { get => duration; set => duration = value; }
    public float Damage { get => damage; set => damage = value; }
    public int Level { get => level; set => level = value; }

    public abstract void Use();
    public abstract void UpdateCoolDownTimer(float deltaTime);
    public abstract void SetStatsForUpGrade();

    
    // public abstract bool CanUseSkill();
}
