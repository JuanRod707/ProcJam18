﻿using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    [RequireComponent(typeof(Text))]
    public class DynamicLabel: MonoBehaviour
    {
        public string LabelFormat;

        private Text mytext;

        void Start()
        {
            mytext = GetComponent<Text>();
        }

        public void SetLabel(params string[] parameters)
        {
            mytext.text = string.Format(LabelFormat, parameters);
        }
    }
}
