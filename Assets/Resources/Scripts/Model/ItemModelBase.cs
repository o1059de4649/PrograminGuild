using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//System.Serializableを設定しないと、データを保持できない(シリアライズできない)ので注意
[System.Serializable]
public class ItemModelBase 
{
    public string item_name;
    public int id;
    public int price;
    public Image image;

}
