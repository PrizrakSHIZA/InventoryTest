using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    public static EquipmentSystem Singleton;

    [SerializeField] TextMeshProUGUI attackStat;
    [SerializeField] TextMeshProUGUI defenceStat;
    [SerializeField] TextMeshProUGUI energyStat;
    [SerializeField] TextMeshProUGUI randStat;

    int attack = 1;
    int defence = 1;
    int energy = 1;
    int rand = 1;

    private void Start()
    {
        Singleton = this;
        DisplayStats();
    }

    public void Equip(ItemData item)
    {
        attack += item.attack;
        defence += item.defence;
        energy += item.energy;
        rand += item.rand;
        DisplayStats();
    }

    public void Unequip(ItemData item)
    {
        attack -= item.attack;
        defence -= item.defence;
        energy -= item.energy;
        rand -= item.rand;
        DisplayStats();
    }

    void DisplayStats()
    {
        attackStat.text = attack.ToString();
        defenceStat.text = defence.ToString();
        energyStat.text = energy.ToString();
        randStat.text = rand.ToString();
    }
}
