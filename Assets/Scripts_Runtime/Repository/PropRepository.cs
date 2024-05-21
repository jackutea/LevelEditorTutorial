using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditorTutorial {

    // 存储所有 PropEntity
    // CRD
    public class PropRepository {

        Dictionary<int, PropEntity> all;

        public PropRepository() {
            all = new Dictionary<int, PropEntity>();
        }

        public void Add(PropEntity prop) {
            all.Add(prop.id, prop);
        }

        public void Remove(int id) {
            all.Remove(id);
        }

        public void Remove(PropEntity prop) {
            all.Remove(prop.id);
        }

        public bool TryGet(int id, out PropEntity prop) {
            return all.TryGetValue(id, out prop);
        }

        public void Foreach(Action<PropEntity> action) {
            foreach (var prop in all.Values) {
                action.Invoke(prop);
            }
        }
 
    }
}