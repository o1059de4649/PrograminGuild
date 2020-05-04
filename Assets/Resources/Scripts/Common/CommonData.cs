using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using System.Linq;

namespace Common 
{
    public class CommonData : MonoBehaviour
    {
        public const int DEFAULT_ENEMY_NUMBER = 1;
        const string COMMON_OBJECT = "CommonObjects";
        public static int dungeon_number = 0;
        public static List<string> abc_list => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(ch => ch + "").ToList();
        static public CommonObjects commonObjects 
        {
            get { return _commonObjects =(_commonObjects== null) ? GameObject.Find(COMMON_OBJECT).GetComponent<CommonObjects>() : _commonObjects ; }
            set { _commonObjects = value; }
        }
        static CommonObjects _commonObjects;

        /// <summary>
        /// 共通プレイヤー(毎回ここから取得する)
        /// </summary>
        static public List<PlayerModel> playerModels 
        {
            get {
                if (_playerModels == null)
                {
                    //どうしてもデータがないとき
                    var result = CommonJsonData.GetPlayerModels();
                    _playerModels = (result == null || result.Count <= 0) ? CreateDefaultPlayer() : result ;
                }
                return _playerModels; 
            }
            set { _playerModels = value; }
        }
        static private List<PlayerModel> _playerModels;

        /// <summary>
        /// データが存在しない時のデータ
        /// </summary>
        /// <returns></returns>
        static public List<PlayerModel> CreateDefaultPlayer() 
        {
            var result = new List<PlayerModel>();
            for (int i = 0; i < 1; i++)
            {
                result.Add(new PlayerModel());
            }
            return result;
        }


        /// <summary>
        /// 敵の生成
        /// </summary>
        /// <param name="number">ダンジョン番号</param>
        /// <returns></returns>
        public List<EnemyModel> CreateEnemys(int number)
        {
            var result = new List<EnemyModel>();
            int random_range_some = Random.Range(1, 3);
            int random_range_group = Random.Range(1, 2);
            
            //グループデータ
            for (int i = 0; i < random_range_group; i++)
            {
                //ランダム数
                for (int k = 0; k < random_range_some; k++)
                {
                    int random_range_kind = Random.Range(1,3);
                    var enemy = master_enemy_list[random_range_kind];
                    enemy.nickName += abc_list[k];//アルファベットを追加
                    result.Add(enemy);
                }
            }

            return result;
        }

        
        /// <summary>
        /// 敵の全データ
        /// </summary>
        public readonly List<EnemyModel> master_enemy_list = new List<EnemyModel>()
        {
                new EnemyModel()
                {
                    id = 1,
                    nickName = "初級バグ",
                    hp = 10,
                    maxHp = 10,
                    mp = 10,
                    maxMp = 10,
                    exp = 10,
                    maxExp = 10,
                    min_power = 2,
                    max_power = 5,
                    defence = 1,
                    speed = 1
                },

                new EnemyModel()
                {
                    id = 2,
                    nickName = "CompileError",
                    hp = 5,
                    maxHp = 5,
                    mp = 0,
                    maxMp = 0,
                    exp = 5,
                    maxExp = 5,
                    min_power = 1,
                    max_power = 2,
                    defence = 1,
                    speed = 1
                },

                new EnemyModel()
                {
                    id = 3,
                    nickName = "NullException",
                    hp = 7,
                    maxHp = 7,
                    mp = 0,
                    maxMp = 0,
                    exp = 7,
                    maxExp = 7,
                    min_power = 1,
                    max_power = 3,
                    defence = 1,
                    speed = 1
                },

                new EnemyModel()
                {
                    id = 4,
                    nickName = "OutRangeOfException",
                    hp = 9,
                    maxHp = 9,
                    mp = 0,
                    maxMp = 0,
                    exp = 9,
                    maxExp = 9,
                    min_power = 2,
                    max_power = 3,
                    defence = 2,
                    speed = 1
                }
        };




    }
}
