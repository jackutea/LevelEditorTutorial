using System;
using UnityEngine;

namespace LevelEditorTutorial {

    public class PropEntity : MonoBehaviour {

        GameObject mod;

        public void Ctor(GameObject mod) {
            this.mod = mod;
        }

    }

}