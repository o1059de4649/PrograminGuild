using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;

namespace Models 
{
    public class LanguageModel : MonoBehaviour
    {
        /// <summary>
        /// 使用される言語
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// 能力値
        /// </summary>
        public int abilityPower { get; set; }
    }
}
