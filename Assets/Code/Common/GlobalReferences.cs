using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Code.UI;
using UnityEngine;

namespace Assets.Code.Common
{
    public static class GlobalReferences
    {
        public static CaveMap CaveMap
        {
            get { return GameObject.Find("CaveMap").GetComponent<CaveMap>(); }
        }
    }
}
