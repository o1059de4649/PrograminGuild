using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Models;
using System.Text;

public class BattleControl : MonoBehaviour
{
    public string OneTurn(List<PlayerModel> player_list,List<EnemyModel> enemy_list) 
    {
        var character_list = new ArrayList();
        player_list.ForEach(x => character_list.Add(x));
        enemy_list.ForEach(x => character_list.Add(x));
        var _character_list = (from CharacterModelBase character in character_list
                         orderby character.speed descending
                         select character).ToList();
        var result = new StringBuilder();
        //全てのキャラクター
        foreach (var item in _character_list)
        {
            //終了
            if (player_list.Count <= 0 || enemy_list.Count <= 0) break;
            if (item.hp <= 0) continue;
            var isPlayer = (item.GetType() == typeof(PlayerModel));
            //プレイヤーの時
            if (isPlayer)
            {
                var player = (PlayerModel)item;
                var enemy = enemy_list[Random.Range(0,enemy_list.Count)];
                result.AppendLine(player.AttackToEnemy(enemy));
                if (enemy.hp <= 0) enemy_list.Remove(enemy);
            }
            else //敵の時
            {
                var enemy = (EnemyModel)item;
                var player = player_list[Random.Range(0, player_list.Count)];
                result.AppendLine(enemy.AttackToPlayer(player));
                if (player.hp <= 0) player_list.Remove(player);
            }

        }
        
        return result.ToString();
    }

    public string StartMessage(List<PlayerModel> player_list, List<EnemyModel> enemy_list) 
    {
        var character_list = new List<CharacterModelBase>();
        player_list.ForEach(x => character_list.Add(x));
        enemy_list.ForEach(x => character_list.Add(x));

        var sb = new StringBuilder();
        sb.AppendLine($"トラブルシューティング開始");
        foreach (var item in player_list)
        {
            sb.AppendLine($"{item.nickName}:{item.hp}/{item.maxHp}");
        }
        foreach (var item in enemy_list)
        {
            sb.AppendLine($"{item.nickName}が発生しました。");
        }
        sb.AppendLine($"バグを修復します。");
        var result = sb.ToString();
        return result;
    }
}
