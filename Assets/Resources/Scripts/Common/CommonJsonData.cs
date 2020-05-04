using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using System;

namespace Common 
{
    public class CommonJsonData : MonoBehaviour
    {
        const string PLAYER_MODELS_FILENAME = "PLAYER_MODELS_FILENAME";
        const string SAVE_DATA = "SAVE_DATA";
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
        static public SaveDataModel GetSaveDataModel()
        {
            SaveDataModel model;
            try
            {
                model = ObjectExpend.LoadObject<SaveDataModel>(nameof(SAVE_DATA));
                if (null == model) return new SaveDataModel();
            }
            catch (Exception e)
            {
                model = new SaveDataModel();
            }

            return model;
        }

        /// <summary>
        /// オブジェクトの保存
        /// </summary>
        /// <param name="Models">保存対象</param>
        static public void SaveModels<T>(T Models)
        {
            ObjectExpend.SaveObject(Models,nameof(PLAYER_MODELS_FILENAME));
        }


    }
}
