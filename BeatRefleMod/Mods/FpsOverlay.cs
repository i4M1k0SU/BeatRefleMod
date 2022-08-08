using UnityEngine;

namespace BeatRefleMod.Mods
{
    internal class FpsOverlay : MonoBehaviour
    {
        private float fps = 0f;

        public void Start()
        {
        }

        public void Update()
        {
            fps = 1f / Time.deltaTime;
        }
        public void LateUpdate()
        {
        }

        public void OnGUI()
        {
            var style = new GUIStyle();
            style.normal.textColor = Color.black;
            style.fontSize = 15;
            GUI.Label(new Rect(Screen.width - 100, 0, 100, style.fontSize), "FPS :" + fps.ToString(), style);
        }

        public void FixedUpdate()
        {
        }
    }
}
