using System;
using UnityEngine;

namespace LevelEditorTutorial {

    public static class GameDomain {

        public static void EnterStage(Context ctx, int stageID) {

            // 读取关卡配置
            bool has = ctx.assetManager.Map_TryGet(stageID, out MapTemplateModel mapTM);
            if (!has) {
                Debug.LogError($"MapTemplateModel not found for stageID: {stageID}");
                return;
            }

            // 加载 Terrain
            if (mapTM.terrainTMs != null) {
                for (int i = 0; i < mapTM.terrainTMs.Length; i += 1) {
                    var terrainTM = mapTM.terrainTMs[i];
                    SpawnTerrain(ctx, terrainTM);
                }
            }

            // TODO 加载 Role

            // 加载 Prop
            if (mapTM.propSpawners != null) {
                for (int i = 0; i < mapTM.propSpawners.Length; i += 1) {
                    var propSpawner = mapTM.propSpawners[i];
                    PropDomain.Spawn(ctx, propSpawner.propTypeID, propSpawner.pos, propSpawner.rot, propSpawner.scale);
                }
            }

        }

        static TerrainEntity SpawnTerrain(Context ctx, TerrainTM tm) {

            TerrainEntity terrain = new GameObject("Terrain").AddComponent<TerrainEntity>();
            var mod = GameObject.Instantiate(tm.modPrefab, terrain.transform);
            terrain.Ctor(mod);

            terrain.id = ctx.idService.terrainIDRecord++;

            // TODO 设置位置, 需要 * TerrainWidth和Height 来计算实际位置
            terrain.transform.position = new Vector3(tm.terrainGridPos.x, 0, tm.terrainGridPos.y);

            // 存到仓库
            ctx.terrainRepository.Add(terrain);

            return terrain;
        }

    }

}