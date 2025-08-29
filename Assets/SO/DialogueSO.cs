using UnityEngine;

[CreateAssetMenu(fileName = "DialogueS0", menuName = "Scriptable Objects/DialogueS0")]
public class DialogueSO : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;

    [SerializeField] private Respond[] responds;
    public string[] Dialogue => dialogue;

    public bool HasResponses => Responds != null && Responds.Length >0;
    public Respond[] Responds => responds;
}
