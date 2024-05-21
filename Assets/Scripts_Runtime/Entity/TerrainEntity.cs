using UnityEngine;

namespace LevelEditorTutorial {

    public class TerrainEntity : MonoBehaviour {

        public int id;

        Terrain terrain;

        public void Ctor(GameObject mod) {
            this.terrain = mod.GetComponent<Terrain>();
        }

    }

}