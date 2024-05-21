using System;
using UnityEngine;

namespace LevelEditorTutorial {

    public static class PropDomain {

        public static PropEntity Spawn(Context ctx, int typeID, Vector3 pos, Vector3 rot, Vector3 scale) {
            bool has = ctx.assetManager.Prop_TryGet(typeID, out var propTM);
            if (!has) {
                Debug.LogError($"PropTemplateModel not found for typeID: {typeID}");
                return null;
            }

            PropEntity prop = new GameObject("Prop").AddComponent<PropEntity>();
            var mod = GameObject.Instantiate(propTM.modPrefab, prop.transform);
            prop.Ctor(mod);

            prop.id = ctx.idService.propIDRecord++;

            prop.transform.position = pos;
            prop.transform.eulerAngles = rot;
            prop.transform.localScale = scale;

            // 存到仓库
            ctx.propRepository.Add(prop);

            return prop;
        }

        public static void Unspawn(Context ctx, PropEntity prop) {
            ctx.propRepository.Remove(prop);
            GameObject.Destroy(prop.gameObject);
        }

    }
}