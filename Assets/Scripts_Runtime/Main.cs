using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditorTutorial {

    public class Main : MonoBehaviour {

        Context ctx;

        bool isTearDown;

        void Awake() {

            isTearDown = false;

            // ==== Instantiate ====
            ctx = new Context();

            // ==== Inject ====

            // ==== Init ====
            ctx.assetManager.LoadAll();

            // ==== Enter ====
            // 1. 加载 Role / Prop / Map(Terrain)
            bool has = ctx.assetManager.Prop_TryGet(100, out var propTM);
            if (!has) {
                Debug.LogError("Prop 100 not found");
                return;
            }

            PropEntity prop = new GameObject("Prop").AddComponent<PropEntity>();
            var mod = GameObject.Instantiate(propTM.modPrefab, prop.transform);
            prop.Ctor(mod);

            prop.transform.position = new Vector3();

            Debug.Log("Enter Game()");
        }

        void Update() {

        }

        void OnApplicationQuit() {
            TearDown();
        }

        void OnDestroy() {
            TearDown();
        }

        void TearDown() {
            if (isTearDown) {
                return;
            }
            isTearDown = true;

            ctx.assetManager.UnloadAll();
        }

    }

}
