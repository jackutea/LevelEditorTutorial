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

            // TODO 加载 Terrain
            // TODO 加载 Role

            // 加载 Prop
            if (mapTM.propSpawners != null) {
                for (int i = 0; i < mapTM.propSpawners.Length; i += 1) {
                    var propSpawner = mapTM.propSpawners[i];
                    SpawnProp(ctx, propSpawner.propTypeID, propSpawner.pos, propSpawner.rot, propSpawner.scale);
                }
            }

        }

        static PropEntity SpawnProp(Context ctx, int typeID, Vector3 pos, Vector3 rot, Vector3 scale) {
            bool has = ctx.assetManager.Prop_TryGet(typeID, out var propTM);
            if (!has) {
                Debug.LogError($"PropTemplateModel not found for typeID: {typeID}");
                return null;
            }

            PropEntity prop = new GameObject("Prop").AddComponent<PropEntity>();
            var mod = GameObject.Instantiate(propTM.modPrefab, prop.transform);
            prop.Ctor(mod);

            prop.transform.position = pos;
            prop.transform.eulerAngles = rot;
            prop.transform.localScale = scale;

            return prop;
        }

    }

}