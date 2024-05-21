using UnityEngine;
using UnityEditor;

namespace LevelEditorTutorial.Editor {

    // 每一个EM对应一个TM
    public class MapEditorModel : MonoBehaviour {

        [SerializeField] MapTemplateModel tm;

        [ContextMenu("Save")]
        public void Save() {
            // 保存到 TM
            PropEM[] props = GetComponentsInChildren<PropEM>();
            tm.propSpawners = new PropSpawnerTM[props.Length];
            for (int i = 0; i < props.Length; i += 1) { 
                var em = props[i];
                tm.propSpawners[i] = new PropSpawnerTM {
                    pos = em.transform.position,
                    rot = em.transform.rotation.eulerAngles,
                    scale = em.transform.localScale,
                    propTypeID = em.tm.typeID
                };
            }

            EditorUtility.SetDirty(tm);
        }

    }

}