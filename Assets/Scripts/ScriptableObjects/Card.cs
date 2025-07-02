using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ScriptableObjects
{
    [Serializable]
    public class Card
    {
        public string NameCard;
        public Sprite Icon;
        [TextArea] public string Description;
        public SceneAsset NameScene;
    }
}
