using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [field: SerializeField]
    [field: RenameField("遷移先シーンのパス")]
    string ScenePath { get; set; }

    /// <summary>
    /// ボタン専用イベントハンドラ
    /// </summary>
    private void LoadScene() 
    {
        SceneManager.LoadScene(ScenePath);
    }

    /// <summary>
    /// 全クラスで使用可能なロードメソッド
    /// </summary>
    /// <param name="path"></param>
    static public void LoadSceneStatic(string path) 
    {
        SceneManager.LoadScene(path);
    }
}
