using UnityEngine;

public class BoxInteract : Interactable
{
    public SpriteRenderer spriteRenderer;

    
    public override void Interact(Player player) {
        base.Interact(player);

        if (spriteRenderer != null)
        {
            if (spriteRenderer.color == Color.red)
                spriteRenderer.color = Color.white;
            else
                spriteRenderer.color = Color.red;
        }
    }   

    
}
