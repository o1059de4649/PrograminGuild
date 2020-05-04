using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;

namespace Models 
{
    public class EquipMentModelBase : ItemModelBase
    {
        public enum EquipMentType 
        {
            CPU,
            GPU,
            RandomAccessMemory,
            StrageMemory,
            Librarys,
            Other
        }

        public EquipMentType equipMentType;
    }
}
