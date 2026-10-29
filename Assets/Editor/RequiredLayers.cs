using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class RequiredLayers
{
    private static readonly (int index, string name)[] Layers = { (8, "Interactable"), (9, "Player") };

    static RequiredLayers()
    {
        EditorApplication.delayCall += EnsureLayers;
    }

    [MenuItem("Modular Assets/Add Required Layers")]
    private static void EnsureLayers()
    {
        var tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty layers = tagManager.FindProperty("layers");
        bool changed = false;

        foreach (var (index, name) in Layers)
        {
            SerializedProperty slot = layers.GetArrayElementAtIndex(index);
            if (slot.stringValue == name) continue;

            if (string.IsNullOrEmpty(slot.stringValue))
            {
                slot.stringValue = name;
                changed = true;
                Debug.Log($"Added layer {index}: {name}");
            }
            else
            {
                Debug.LogWarning($"Layer {index} is already '{slot.stringValue}', but {name} needs it.");
            }
        }

        if (changed) tagManager.ApplyModifiedProperties();
    }
}
