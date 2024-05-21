using System;
using UnityEngine;

namespace LevelEditorTutorial {

    [CreateAssetMenu(fileName = "TM_Terrain_", menuName = "LevelEditorTutorial/TerrainTM")]
    public class TerrainTM : ScriptableObject {

        public Vector2Int terrainGridPos;

        public GameObject modPrefab;

    }
}