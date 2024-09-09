using System;

using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Objects/GameContent")]

public class GameContentSO : ScriptableObject
{
    [Header("Player")]
    [SerializeField ] private int diamond;
    

    [Header("QuestManager")]
    
    [SerializeField] private DateTime lastResetDate;
    [SerializeField] private int resetHour;
    [SerializeField] private int resetMinute;
    [SerializeField] private int resetSecond;
    [SerializeField] private int currentGoal;
    [SerializeField] private List<Quest> quests;
    [SerializeField] private List<Quest> questValid;
    #region ability
    [SerializeField] private List<Ability> abilities;
    #endregion

    #region getter setter
    public DateTime LastResetDate { get => lastResetDate; set => lastResetDate = value; }
    public int ResetHour { get => resetHour; set => resetHour = value; }
    public int ResetMinute { get => resetMinute; set => resetMinute = value; }
    public int ResetSecond { get => resetSecond; set => resetSecond = value; }
    public List<Quest> Quests { get => quests; set => quests = value; }
    public List<Quest> QuestValid { get => questValid; set => questValid = value; }
    public int CurrentGoal { get => currentGoal; set => currentGoal = value; }
    public int Diamond { get => diamond; set => diamond = value; }
    public List<Ability> Abilities { get => abilities; set => abilities = value; }
    #endregion
}
