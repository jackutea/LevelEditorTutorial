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
            // 进入某一关
            GameDomain.EnterStage(ctx, 1);

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
