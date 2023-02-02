using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

#if UNITY_EDITOR

[CustomEditor(typeof(SfxSO))]
public class SfxEditor : Editor
{
    public VisualTreeAsset uxml;
    public Button PlayButton, StopButton;

    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();

        uxml.CloneTree(root);

        return root;
    }
}

#endif
