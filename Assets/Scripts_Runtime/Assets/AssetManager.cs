using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace LevelEditorTutorial {

    public class AssetManager {

        Dictionary<int, MapTemplateModel> maps;
        AsyncOperationHandle mapHandle;

        Dictionary<int, PropTemplateModel> props;
        AsyncOperationHandle propHandle;

        public AssetManager() {
            maps = new Dictionary<int, MapTemplateModel>();
            props = new Dictionary<int, PropTemplateModel>();
        }

        public void LoadAll() {

            {
                var op = Addressables.LoadAssetsAsync<MapTemplateModel>("TM_Map", null);
                var all = op.WaitForCompletion();
                foreach (var obj in all) {
                    maps.Add(obj.stageID, obj);
                }
                this.mapHandle = op;
            }

            {
                var op = Addressables.LoadAssetsAsync<PropTemplateModel>("TM_Prop", null);
                var all = op.WaitForCompletion();
                foreach (var obj in all) {
                    props.Add(obj.typeID, obj);
                }
                this.propHandle = op;
            }

        }

        public void UnloadAll() {
            if (this.mapHandle.IsValid()) {
                Addressables.Release(this.mapHandle);
            }
            if (this.propHandle.IsValid()) {
                Addressables.Release(this.propHandle);
            }
        }

        public bool Map_TryGet(int stageID, out MapTemplateModel tm) {
            return maps.TryGetValue(stageID, out tm);
        }

        public bool Prop_TryGet(int typeID, out PropTemplateModel tm) {
            return props.TryGetValue(typeID, out tm);
        }

    }
}