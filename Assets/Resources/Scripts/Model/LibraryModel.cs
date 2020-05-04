using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;

namespace Models 
{
    [System.Serializable]
    public class LibraryModel : EquipMentModelBase
    {
        /// <summary>
        /// ライブラリの量
        /// </summary>
        public int bytes { get; set; }

        /// <summary>
        /// 使用された言語
        /// </summary>
        public List<LanguageModel> languages { get; set; }
    }
}
