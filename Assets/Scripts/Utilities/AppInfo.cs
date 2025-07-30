using TMPro;
using UnityEditor;
using UnityEngine;

namespace GameFinder
{
    /// <summary> 1. Show the version in a TextMeshProUGUI
    /// 2. Invoke Application.Quit </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class AppInfo : MonoBehaviour
    {
        /// <summary> automatically find text that will hold the version string </summary>
        private TextMeshProUGUI versionLabel
        {
            get
            {
                return _versionLabel ??= this.GetComponent<TextMeshProUGUI>();
            }
        }
        private TextMeshProUGUI _versionLabel;

        void Start()
        {
            OnValidate();
        }

        void OnValidate()
        {
            versionLabel.text = Application.version;
        }

        /// <summary> Called by button's UnityEvent </summary>
        public void OnExit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#elif UNITY_WEBGL
            // Application.OpenURL(webplayerQuitURL);
#else
            Application.Quit();
#endif
        }
    }
}
