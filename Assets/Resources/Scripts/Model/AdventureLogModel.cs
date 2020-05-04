using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using ViewModels;
using Common;

public class AdventureLogModel : MonoBehaviour
{
    public GameObject content;
    public GameObject log_obj => CommonData.commonObjects.log_obj_prefab;
    public GameObject battlelog_text_parent => CommonData.commonObjects.battle_Log_parent;

    public BattleViewModel battle_view;

    /// <summary>
    /// メッセージログの作成
    /// </summary>
    /// <param name="result"></param>
    static public GameObject CreateText(string result, GameObject log_text_obj, GameObject log_text_content)
    {
        var obj = Instantiate(log_text_obj, log_text_obj.transform.position, Quaternion.identity);
        obj.transform.SetParent(log_text_content.transform, false);
        var log_text = obj.GetComponentInChildren<Text>();
        log_text.text = result;
        return obj;
    }

    /// <summary>
    /// 全文表示
    /// </summary>
    public void ShowBattleLog() 
    {
        battle_view.battleLogs.ForEach(x => x.CreateDetailText());
        battlelog_text_parent.SetActive(true);
        //削除ボタンの参照先を設定
        CommonData.commonObjects.battle_backButton.GetComponent<Button>().onClick.AddListener(this.HideBattleLog);
    }

    /// <summary>
    /// メッセージは隠す
    /// </summary>
    public void HideBattleLog()
    {
        battle_view.battleLogs.ForEach(x => x.DeleteDetailText());
        battlelog_text_parent.SetActive(false);
    }
}
