using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteract : MonoBehaviour
{
    public Interactable interactable;
    

    private void Start()
    {
        if (interactable == null)
        {
            interactable = GetComponent<Interactable>();
        }
        interactable.OnInteract += OpenDoor;
    }

    private void OpenDoor()
    {
        // Trigger some sort of screen transition here
        SceneManager.LoadScene("ZippyScene2");
    }
}
