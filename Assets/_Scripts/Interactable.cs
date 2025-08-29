using System;
using UnityEngine;

public class Interactable : MonoBehaviour, IInterractable
{
    public event Action OnInteract;
    public SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            // Debug.Log("Enter Interact area");
            player.interactablesInRange.Add(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            // Debug.Log("Exit interact area");
            if (player.interactablesInRange.Contains(this))
            {
                player.interactablesInRange.Remove(this);
            }
        }
    }

    public virtual void Interact(Player player)
    {
        if (spriteRenderer != null)
        {
            if (spriteRenderer.color == Color.red)
                spriteRenderer.color = Color.white;
            else
                spriteRenderer.color = Color.red;
        }

        OnInteract?.Invoke();
    }

    public float GetDistance(GameObject other)
    {
        Vector2 distanceVector = other.transform.position - transform.position;
        return distanceVector.magnitude;
    }
}
