using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common 
{
    public class ObjectExpend : MonoBehaviour
    {
        const string extension = ".txt";
        static public void SaveObject(object save_obj,string filename)
        {
            // JSONにシリアライズ
            var json = JsonUtility.ToJson(save_obj);
            // Assetsフォルダに保存する
            var path = Application.persistentDataPath + "/" + filename + extension;
            var writer = new StreamWriter(path, false); // 上書き
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
        }

        static public T LoadObject<T>(string filename) 
        {
            T result;
            var path = Application.persistentDataPath + "/" + filename + extension;
            if (File.Exists(path))
            {
                StreamReader streamReader;
                streamReader = new StreamReader(path);
                string data = streamReader.ReadToEnd();
                streamReader.Close();

                result = JsonUtility.FromJson<T>(data);
            }
            else { result = default(T); }
            
            return result;    
        }

        /// <summary>
        /// コピーメソッド
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(T target)
        {
            T result;
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            try
            {
                b.Serialize(mem, target);
                mem.Position = 0;
                result = (T)b.Deserialize(mem);
            }
            finally
            {
                mem.Close();
            }
            return result;
        }

        /// <summary>
        /// 幅を返します
        /// </summary>
        static public float GetWidth(RectTransform self)
        {
            return self.sizeDelta.x;
        }

        /// <summary>
        /// 高さを返します
        /// </summary>
        static public float GetHeight(RectTransform self)
        {
            return self.sizeDelta.y;
        }

        /// <summary>
        /// 幅を設定します
        /// </summary>
        static public void SetWidth(RectTransform self, float width)
        {
            var size = self.sizeDelta;
            size.x = width;
            self.sizeDelta = size;
        }

        /// <summary>
        /// 高さを設定します
        /// </summary>
        static public void SetHeight(RectTransform self, float height)
        {
            var size = self.sizeDelta;
            size.y = height;
            self.sizeDelta = size;
        }

        /// <summary>
        /// サイズを設定します
        /// </summary>
        public static void SetSize(RectTransform self, float width, float height)
        {
            self.sizeDelta = new Vector2(width, height);
        }

        /// <summary>
        /// 文字の出現回数をカウント
        /// </summary>
        /// <param name="s">対象文字</param>
        /// <param name="c">数える文字</param>
        /// <returns></returns>
        static public int CountChar(string s, string c)
        {
            return s.Length - s.Replace(c.ToString(), "").Length;
        }

        /// <summary>
        /// 子オブジェクト破壊
        /// </summary>
        /// <param name="game_obj"></param>
        static public void DestroyChildren(GameObject game_obj) 
        {
            //子オブジェクト
            foreach (Transform n in game_obj.transform)
            {
                GameObject.Destroy(n.gameObject);
            }
        }

    }
}
