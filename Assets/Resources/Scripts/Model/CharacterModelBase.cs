using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterModelBase
{
    public int id { get; set; }
    public string nickName { get; set; }
    public int level { get; set; }
    public int hp { get; set; }
    public int maxHp { get; set; }
    public int mp { get; set; }
    public int maxMp { get; set; }
    public int exp { get; set; }
    public int maxExp { get; set; }

    public int min_power { get; set; }
    public int max_power { get; set; }
    public int defence { get; set; }
    public int speed { get; set; }
}
