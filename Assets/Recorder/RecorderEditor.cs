using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RecorderEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/RecorderEditor")]
    public static void ShowExample()
    {
        RecorderEditor wnd = GetWindow<RecorderEditor>();
        wnd.titleContent = new GUIContent("RecorderEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
    }
}
