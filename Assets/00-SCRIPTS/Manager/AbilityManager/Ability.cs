using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject 
{
    [SerializeField] private string name;
    [SerializeField] private Sprite image;
    [SerializeField] private bool unClock=false;

 
    public string Name { get => name; set => name = value; }
    public Sprite Image { get => image; set => image = value; }
    public bool UnClock { get => unClock; set => unClock = value; }

    public abstract void Use();
    public abstract void UpdateCoolDownTimer(float deltaTime);

}
