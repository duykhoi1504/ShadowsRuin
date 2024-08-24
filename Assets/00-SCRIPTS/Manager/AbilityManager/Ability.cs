using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject 
{
    [SerializeField] private string name;
    [SerializeField] private Sprite image;
    [SerializeField] private bool unClock=false;
    [SerializeField] private float coolDown;
    [SerializeField] private float duration;
 
    public string Name { get => name; set => name = value; }
    public Sprite Image { get => image; set => image = value; }
    public bool UnClock { get => unClock; set => unClock = value; }
    public float CoolDown { get => coolDown; set => coolDown = value; }
    public float Duration { get => duration; set => duration = value; }

    public abstract void Use();
    public abstract void UpdateCoolDownTimer(float deltaTime);
    // public abstract bool CanUseSkill();
}
