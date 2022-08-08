using Atup.InGame;
using UnityEngine;

namespace BeatRefleMod.Mods
{
    internal class JudgeOverlay : MonoBehaviour
    {
        private ScoreManager? scoreManager;
        private Font? font;

        public void Start()
        {
            // This function is called once for each instance of this class,
            // when it starts execution (in this case, attached to an object)
        }

        public void Update()
        {
            // This function is called once per frame, it's frequency depends on the frame rate.
            // This is at the beginning of the game logic cycle.
            scoreManager = FindObjectOfType<ScoreManager>();
            if (font == null)
            {
                // This function is called once per frame, it's frequency depends on the frame rate.
                // This is at the end of the game logic cycle.
                var appMain = FindObjectOfType<Orgesta.AppMain>();
                if (appMain != null)
                {
                    font = appMain.localizeModel.GetFont(Orgesta.AppMain.currentLanguage);
                }
            }
            
        }
        public void LateUpdate()
        {
            // This function is called once per frame, it's frequency depends on the frame rate.
            // This is at the end of the game logic cycle.
        }

        public void OnGUI()
        {
            // This function is called at the end of the frame, after all game logic.
            // It is called twice per frame: Once for rendering, and once for GUI Events
            // This is where we do all drawing operations
            if (scoreManager == null)
            {
                return;
            }
            int[] judgeNotesNum = scoreManager.GetJudgeNotesNum();
            var style = new GUIStyle();
            if (font != null)
            {
                style.font = font;
                style.fontSize = 30;
            }
            else
            {
                style.fontStyle = FontStyle.Bold;
                style.fontSize = 40;
            }
            int x = 30;
            int y = 170;
            int width = 300;
            int padding = style.fontSize + 12;
            style.normal.textColor = new Color(24f / 255f, 190f / 255f, 100f / 255f);
            GUI.Label(new Rect(x, y, width, style.fontSize), "COOL\t: " + judgeNotesNum[0].ToString(), style);
            style.normal.textColor = new Color(255f / 255f, 80f /255f, 110f / 255f);
            GUI.Label(new Rect(x, y += padding, width, style.fontSize), "GREAT\t: " + judgeNotesNum[1].ToString(), style);
            style.normal.textColor = new Color(247f / 255f, 116f / 255f, 63f / 255f);
            GUI.Label(new Rect(x, y += padding, width, style.fontSize), "GOOD\t: " + judgeNotesNum[2].ToString(), style);
            style.normal.textColor = new Color(41f / 255f, 166f / 255f, 162f / 255f);
            GUI.Label(new Rect(x, y += padding, width, style.fontSize), "POOR\t: " + judgeNotesNum[3].ToString(), style);
            style.normal.textColor = new Color(74f / 255f, 85f / 255f, 90f / 255f);
            GUI.Label(new Rect(x, y += padding, width, style.fontSize), "BAD\t: " + judgeNotesNum[4].ToString(), style);
            switch (scoreManager.Rating)
            {
                case Orgesta.Define.MusicGame.Rating.E:
                    style.normal.textColor = new Color(80f / 255f, 85f / 255f, 90f / 255f);
                    break;
                case Orgesta.Define.MusicGame.Rating.D:
                    style.normal.textColor = new Color(0f / 255f, 89f / 255f, 159f / 255f);
                    break;
                case Orgesta.Define.MusicGame.Rating.C:
                    style.normal.textColor = new Color(0f / 255f, 177f / 255f, 196f / 255f);
                    break;
                case Orgesta.Define.MusicGame.Rating.B:
                    style.normal.textColor = new Color(255f / 255f, 161f / 255f, 39f / 255f);
                    break;
                case Orgesta.Define.MusicGame.Rating.A:
                    style.normal.textColor = new Color(255f / 255f, 74f / 255f, 52f / 255f);
                    break;
                case Orgesta.Define.MusicGame.Rating.S:
                    style.normal.textColor = new Color(255f / 255f, 80f / 255f, 110f / 255f);
                    break;
            }
            GUI.Label(new Rect(x, y += padding, width, style.fontSize), "RATING\t: " + scoreManager.Rating.ToString(), style);
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(180, 6, width, style.fontSize), "総ノーツ数 : " + scoreManager.NotesCount.ToString(), style);
        }


        /* - Physics Method - */
        public void FixedUpdate()
        {
            // This function is called at a fixed frequency (Typically 100hz) and is independent of the frame rate.
            // For physics operations.
        }
    }
}
