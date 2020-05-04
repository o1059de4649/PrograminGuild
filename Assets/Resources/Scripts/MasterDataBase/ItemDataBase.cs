using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using System;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "ItemDataBaseTable", menuName = "ItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    //ListステータスのList
    public List<ItemModel> item_list = new List<ItemModel>();
    public List<LibraryModel> library_item_list = new List<LibraryModel>();
}


