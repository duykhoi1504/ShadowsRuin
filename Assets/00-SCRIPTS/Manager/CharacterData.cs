using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
[CreateAssetMenu(fileName ="Character Data", menuName ="Scriptable Objects/New Character Data",order =0)]
public class CharacterData :ScriptableObject
{
   public string Name;
   public Sprite Sprite;
   public int PurchasePrice;
   [HorizontalLine]

   [SerializeField] private float attack;
   [SerializeField] private float attackSpeed;

   [SerializeField] private float maxHealth;

   [SerializeField] private float armor;

   [SerializeField] private float luck;


}
