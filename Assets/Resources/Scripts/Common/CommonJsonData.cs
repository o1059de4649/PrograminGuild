using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;

namespace Common 
{
    public class CommonJsonData : MonoBehaviour
    {
        const string PLAYER_MODELS_FILENAME = "PLAYER_MODELS_FILENAME";
        const string DUNGEON_NUMBER = "DUNGEON_NUMBER";
        /// <summary>
        /// プレイヤーを取得(毎回ここから取得する)
        /// </summary>
        static public List<PlayerModel> GetPlayerModels()
        {
            var result = new List<PlayerModel>();
            ObjectExpend.LoadObject<List<PlayerModel>>(nameof(PLAYER_MODELS_FILENAME));
            return result;
        }

        /// <summary>
        /// プレイヤーを取得(毎回ここから取得する)
        /// </summary>
        static public int GetDungeonNumber()
        {
            var result = 0;
            ObjectExpend.LoadObject<int>(nameof(DUNGEON_NUMBER));
            return result;
        }

        /// <summary>
        /// プレイヤーのすべてを保存
        /// </summary>
        /// <param name="playerModels"></param>
        static public void SavePlayerModels(List<PlayerModel> playerModels)
        {
            ObjectExpend.SaveObject(playerModels,nameof(PLAYER_MODELS_FILENAME));
        }


    }
}
