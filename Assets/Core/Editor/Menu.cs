using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    public class Menu
    {
        [MenuItem("Template/Reset Data")]
        static void ResetData() =>
            PlayerPrefs.DeleteAll();
    }
}
