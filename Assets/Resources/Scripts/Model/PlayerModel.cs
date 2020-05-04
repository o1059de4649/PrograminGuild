using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using System.Text;

namespace Models 
{
    public class PlayerModel : CharacterModelBase
    {
        public List<LibraryModel> libraryModels;

        public PlayerModel() 
        {
            id = 1;
            nickName = "デフォルトプレイヤー";
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
        /// 味方の攻撃
        /// </summary>
        /// <returns></returns>
        public string AttackToEnemy(EnemyModel enemy)
        {
            var damage = Random.Range(this.min_power, this.max_power);
            enemy.hp -= damage;

            var percent = 100 - ((float)enemy.hp / (float)enemy.maxHp) * 100;

            var sb = new StringBuilder();
            sb.AppendLine($"{ this.nickName}は{ enemy.nickName}を{percent}%解決させた");
            if (enemy.hp <= 0) sb.AppendLine($"{ enemy.nickName}は{this.nickName}によって解決された");
            return sb.ToString();
        }
    }
}
