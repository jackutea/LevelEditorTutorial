using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditorTutorial {

    // 存储所有 TerrainEntity
    // CRD
    public class TerrainRepository {

        Dictionary<int, TerrainEntity> all;

        public TerrainRepository() {
            all = new Dictionary<int, TerrainEntity>();
        }

        public void Add(TerrainEntity Terrain) {
            all.Add(Terrain.id, Terrain);
        }

        public void Remove(int id) {
            all.Remove(id);
        }

        public void Remove(TerrainEntity Terrain) {
            all.Remove(Terrain.id);
        }

        public bool TryGet(int id, out TerrainEntity Terrain) {
            return all.TryGetValue(id, out Terrain);
        }

        public void Foreach(Action<TerrainEntity> action) {
            foreach (var Terrain in all.Values) {
                action.Invoke(Terrain);
            }
        }

    }
}