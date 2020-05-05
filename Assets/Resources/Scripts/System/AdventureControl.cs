using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Linq;
using Common;
using Models;
using ViewModels;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AdventureControl : MonoBehaviour
{
    public DateTime old_datetime;
    public const string OLD_DATETIME = "OLD_DATETIME";
    public GameObject log_text_content => CommonData.commonObjects.adventure_Log_content;
    public GameObject log_text_obj => CommonData.commonObjects.log_obj_prefab;
    public GameObject battlelog_text_content => CommonData.commonObjects.battle_Log_content;
    public GameObject battlelog_text_parent => CommonData.commonObjects.battle_Log_parent;
    public GameObject battle_backButton => CommonData.commonObjects.battle_backButton;
    public BattleControl battleControl => GetComponent<BattleControl>();
    int get_all_exp = 0;
    CommonData commonData;
    public enum ActionType 
    {
        Battle,
        Tresure
    }

    ActionType actionType;

    // Start is called before the first frame update
    void Start()
    {
        //セーブデータ呼び出し
        commonData = new CommonData();
        AdventureAction();
        Save();
        UpdateStatusBoard();
    }

    /// <summary>
    /// セーブメソッド
    /// </summary>
    public void Save() 
    {
        //経験値を保存
        commonData.saveData.dungeon_number = 0;
        commonData.saveData.byte_all += get_all_exp;
        CommonJsonData.SaveModels<SaveDataModel>(commonData.saveData,CommonJsonData.SAVE_DATA);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 時間経過によってあふれた時間を消費する
    /// </summary>
    public void AdventureAction() 
    {
        //現在時刻
        var new_datetime = DateTime.UtcNow;
        old_datetime = (PlayerPrefs.HasKey(OLD_DATETIME)) ?
            DateTime.Parse(PlayerPrefs.GetString(nameof(OLD_DATETIME))):new_datetime;
        PlayerPrefs.SetString(nameof(OLD_DATETIME),new_datetime.ToString());
        //古い時刻

        var minutes = (new_datetime - old_datetime).TotalMinutes;

        //分数だけランダムにイベント発火
        //for (int i = 0; i < 10; i++)
        for (int i = 0; i < minutes; i++)
        {
            EventAction(RandomAction());
        }
    }

    /// <summary>
    /// イベント発火
    /// </summary>
    /// <param name="actionType"></param>
    public void EventAction(ActionType actionType) 
    {
        switch (actionType) 
        {
            case ActionType.Battle:
                BattleEvent();
                break;
            case ActionType.Tresure:
                TresureEvent();
                break;
        }
    }

    /// <summary>
    /// ランダムアクション
    /// </summary>
    /// <returns></returns>
    public ActionType RandomAction() 
    {
        actionType = (ActionType)Random.Range(0,Enum.GetNames(typeof(ActionType)).Length);
        return actionType;
    }

    /// <summary>
    /// 戦闘イベント
    /// </summary>
    public void BattleEvent() 
    {
        //冒険ログに表示
        var obj = AdventureLogModel.CreateText("バトル",log_text_obj,log_text_content);
        var a_log = obj.AddComponent<AdventureLogModel>();
        //ボタンを有効
        var v_log = CreateBattleEventDetail(a_log);
        var button = obj.AddComponent<Button>();
        button.onClick.AddListener(a_log.ShowBattleLog);
    }

    public void TresureEvent() 
    {
        AdventureLogModel.CreateText("トレジャー", log_text_obj, log_text_content);
    }

    /// <summary>
    /// 戦闘イベント
    /// </summary>
    public AdventureLogModel CreateBattleEventDetail(AdventureLogModel adventureLogModel)
    {
        var battle_log_view = new BattleViewModel();
        var player_models = CommonData.playerModels;
        int? dungeon_number =  commonData.saveData.dungeon_number;
        var enemy_models = commonData.CreateEnemys(commonData.saveData.dungeon_number);
        var isfinish = false;

        //経験値の合計を保存
        var get_exp = enemy_models.Sum(x => x.exp);

        //開始メッセージ
        var start_text = battleControl.StartMessage(player_models,enemy_models);
        CreateBattleView(adventureLogModel, battle_log_view, start_text);

        //戦闘中
        while (!isfinish) 
        {
            var content_text = battleControl.OneTurn(player_models, enemy_models);
            CreateBattleView(adventureLogModel, battle_log_view, content_text);
            isfinish = (enemy_models.Count <= 0 || player_models.Count <= 0);
        }

        //勝利した場合
        var isWin = (enemy_models.Count <= 0);
        string end_text;
        if (isWin)
        {
            //終了メッセージ
            end_text = $"{get_exp}Bのメモリを獲得した。";
            //蓄積して最後に加算
            get_all_exp += get_exp;
        }
        else 
        {
            //終了メッセージ
            end_text = $"バグは修復できませんでした。";
        }
        CreateBattleView(adventureLogModel, battle_log_view, end_text);

        //最後に結果を渡す
        adventureLogModel.battle_view = battle_log_view;
        return adventureLogModel;
    }

    /// <summary>
    /// バトルビュー１行生成
    /// </summary>
    public void CreateBattleView(AdventureLogModel adventureLogModel,BattleViewModel battleViewModel,string content_text) 
    {
        //ログのモデル作成
        var battle_log_model = adventureLogModel.gameObject.AddComponent<BattleLogModel>();
        battle_log_model.contents = content_text;
        battle_log_model.content_obj = battlelog_text_content;
        battle_log_model.log_obj = adventureLogModel.log_obj;
        battleViewModel.battleLogs.Add(battle_log_model);
    }

    public void UpdateStatusBoard() 
    {
        CommonData.commonObjects.status_board.GetComponent<Text>().text = commonData.saveData.byte_all.ToString() + "B";
    }

}
