using UnityEngine;

[CreateAssetMenu(fileName = "DialogueS0", menuName = "Scriptable Objects/DialogueS0")]
public class DialogueS0 : ScriptableObject
{
    [SerializeField][TextArea] private string[] Dialogue;
    public string[] dialogue => Dialogue;
}
