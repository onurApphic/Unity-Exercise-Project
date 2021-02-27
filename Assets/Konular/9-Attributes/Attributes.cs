using UnityEngine;
using UnityEditor;

public class Attributes : MonoBehaviour
{
    [Range(0, 100)] public float rangeSpeed = 2f;
    [Min(1.0f)] public float minSpeed = 2.0f;
    [Multiline(4)] public string multiLine = "";
    [TextArea] public string textArea = "";
    [ColorUsage(true, false)] public Color color = Color.white;
    [GradientUsage(true)] public Gradient gradient;
    [Space(10)]
    public int Space;
    [Space(10)]
    [Header("Stats")]
    public bool header;
    [Tooltip("Information about this field")] public string readMe = "Tooltip";
    public ModelImporterIndexFormat myEnum;
    public string disableMultiAdd = "[DisallowMultipleComponent] Add to Above Class";
    public string MustBeThisComponent = "[RequireComponent(typeof(RigidBody))] Add to Above Class";
    public string executeInEditMode = "[ExecuteInEditMode] Add to Above Class";

   
    [ContextMenu("Reset Score")] // Hamburg Button --> Reset Score // Like Reset or Copy Values
    public void ResetScore()
    {
        rangeSpeed = 1000000;
        minSpeed = 1000000;
    }

    [MenuItem("MyMenu/Do Something")]
    static void DoSomething()
    {

    }
    //[InitializeOnLoadMethod]
    //static void OnProjectLoadedInEditor()
    //{
    //    Debug.Log("Project loaded in Unity Editor");
    //}

}
public enum ModelImporterIndexFormat
{
    Auto = 0,
    [InspectorName("16 bits")]
    UInt16 = 1,
    [InspectorName("32 bits")]
    UInt32 = 2,
}

