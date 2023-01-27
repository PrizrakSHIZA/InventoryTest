using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Scriptable object/Item")]
public class ItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public EquipmentType type;

    //stats
    public int level;
    public int attack;
    public int defence;
    public int energy;
    public int rand;

    public bool equiped;
}


public enum EquipmentType
{ 
    weapon,
    head,
    body
}
