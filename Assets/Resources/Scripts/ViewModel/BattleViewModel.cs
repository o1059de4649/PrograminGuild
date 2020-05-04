using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using Common;

namespace ViewModels 
{
    public class BattleViewModel : MonoBehaviour
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BattleViewModel() 
        {
            battleLogs = new List<BattleLogModel>();
        }

        public List<PlayerModel> playerModels => CommonData.playerModels;
        public List<EnemyModel> enemyModels 
        {
            get {
                _enemyModels = (_enemyModels == null) ? new CommonData().CreateEnemys(CommonData.DEFAULT_ENEMY_NUMBER) : _enemyModels ;
                return _enemyModels; }
            set { _enemyModels = value; }
        }
        private List<EnemyModel> _enemyModels;

        /// <summary>
        /// バトル１行のリスト
        /// </summary>
        public List<BattleLogModel> battleLogs { get; set; }

    }
}
