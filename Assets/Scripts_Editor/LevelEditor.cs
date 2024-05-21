using UnityEngine;
using UnityEditor;

namespace LevelEditorTutorial.Editor {

    public class LevelEditor : MonoBehaviour {

        [ContextMenu("Save")]
        public void Save() {
            Debug.Log("Save");
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }

}