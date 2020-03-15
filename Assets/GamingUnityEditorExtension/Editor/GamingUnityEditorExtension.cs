using UnityEditor;
using UnityEngine;

namespace EditorExtension
{
    public class GamingUnityEditorExtension : EditorWindow
    {
        private static readonly string _imagePath = "Assets/GamingUnityEditorExtension/Editor/GamingImage.png";
        private static Texture2D _texture;
        private Vector2 ShiftPosition = Vector2.zero;

        [MenuItem(itemName: "Tools/GamingUnity")]
        public static void Open()
        {
            var window = CreateInstance<GamingUnityEditorExtension>();

            _texture = AssetDatabase.LoadAssetAtPath<Texture2D>(assetPath: _imagePath);

            window.titleContent.text = "Gaming Unity";
            window.minSize = Vector2.one * 10;
            window.position = new Rect(100, 100, 100, 10);
            window.Show();
        }

        void Update()
        {
            Repaint();
        }

        void OnGUI()
        {
            var area = new Rect(Vector2.zero, new Vector2(Screen.width, Screen.height));

            var scrollSpeed = Screen.width / 200f;

            ShiftPosition.x += scrollSpeed * Time.deltaTime;
            if (ShiftPosition.x >= Screen.width)
                ShiftPosition.x = 0;

            var firstRect = area;
            firstRect.position = ShiftPosition;
            GUI.DrawTexture(position: firstRect, image: _texture, scaleMode: ScaleMode.StretchToFill, alphaBlend: true);

            var secondRect = area;
            secondRect.position = ShiftPosition - new Vector2(Screen.width, 0);
            GUI.DrawTexture(position: secondRect, image: _texture, scaleMode: ScaleMode.StretchToFill, alphaBlend: true);
        }
    }
}
