using UnityEngine;

namespace LevelEditorTutorial {

    [CreateAssetMenu(fileName = "TM_Map_", menuName = "LevelEditorTutorial/MapTemplateModel")]
    public class MapTemplateModel : ScriptableObject {

        public int stageID; // 关卡ID

        // Terrain
        public TerrainTM[] terrainTMs;

        // PropSpawner
        public PropSpawnerTM[] propSpawners;

    }

}