using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using System.Text;

public class EnemyModel : CharacterModelBase
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public EnemyModel() 
    {
        id = 1;
        nickName = "初級バグ";
        hp = 10;
        maxHp = 10;
        mp = 10;
        maxMp = 10;
        exp = 10;
        maxExp = 10;
        min_power = 2;
        max_power = 5;
        defence = 1;
        speed = 1;
    }

    /// <summary>
    /// 敵の攻撃
    /// </summary>
    /// <returns></returns>
    public string AttackToPlayer(PlayerModel player)
    {
        var damage = Random.Range(this.min_power, this.max_power);
        player.hp -= damage;
        var sb = new StringBuilder();
        sb.AppendLine($"{ this.nickName}は{ player.nickName}に{ damage}ポイントの負荷を与えた");
        if (player.hp <= 0) sb.AppendLine($"{ player.nickName}は{this.nickName}によってクラッシュした");
        return sb.ToString();
    }
}
