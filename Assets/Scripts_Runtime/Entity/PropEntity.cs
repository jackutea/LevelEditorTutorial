using System;
using UnityEngine;

namespace LevelEditorTutorial {

    public class PropEntity : MonoBehaviour {

        public int id;

        GameObject mod;

        public void Ctor(GameObject mod) {
            this.mod = mod;
        }

    }

}