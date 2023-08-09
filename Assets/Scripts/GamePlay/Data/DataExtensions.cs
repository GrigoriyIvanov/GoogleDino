using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public static class DataExtensions
{
    public static T DeserializeTo<T>(this string json) where T : class =>
        JsonUtility.FromJson<T>(json);

    public static string Serialize<T>(this T playerProgress) where T : class =>
        JsonUtility.ToJson(playerProgress);
}
