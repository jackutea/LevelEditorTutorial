using UnityEngine;
using UnityEditor;

namespace LevelEditorTutorial.Editor {

    [ExecuteInEditMode]
    public class PropEM : MonoBehaviour {

        [SerializeField] public PropTemplateModel tm;

        GameObject mod;

        void Update() {
            if (mod == null) {
                mod = Instantiate(tm.modPrefab, transform);
                mod.transform.localPosition = Vector3.zero;
                mod.transform.localRotation = Quaternion.identity;
                mod.transform.localScale = Vector3.one;
            }
        }

    }

}