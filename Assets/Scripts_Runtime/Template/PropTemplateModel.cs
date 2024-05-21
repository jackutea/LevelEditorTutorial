using System;
using UnityEngine;

namespace LevelEditorTutorial {

    // Prop 原型
    [CreateAssetMenu(fileName = "TM_Prop_", menuName = "LevelEditorTutorial/PropTemplateModel")]
    public class PropTemplateModel : ScriptableObject {

        public int typeID;

        public GameObject modPrefab;

    }

}