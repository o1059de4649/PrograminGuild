using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleLogModel : MonoBehaviour
{
    /// <summary>
    /// ビューオブジェクトのcontentオブジェクト
    /// </summary>
    public GameObject content_obj;
    /// <summary>
    /// 複製Prefab
    /// </summary>
    public GameObject log_obj;
    /// <summary>
    /// 実際の文字データ
    /// </summary>
    public string contents;

    public BattleLogModel(GameObject con)
    {
        content_obj = con;
    }

    /// <summary>
    /// メッセージログの作成
    /// </summary>
    /// <param name="result"></param>
    public void CreateDetailText()
    {
        var obj = Instantiate(log_obj, this.transform.position, Quaternion.identity);
        obj.transform.SetParent(content_obj.transform, false);
        var log_text = obj.GetComponentInChildren<Text>();
        log_text.text = contents;

        //高さの決定
        var crlf_number = ObjectExpend.CountChar(this.contents, "\r\n");
        ObjectExpend.SetHeight(obj.gameObject.GetComponent<RectTransform>(), 100 + 10 * crlf_number);
    }

    /// <summary>
    /// メッセージログを消す
    /// </summary>
    public void DeleteDetailText() 
    {
        ObjectExpend.DestroyChildren(content_obj);
    }
}
