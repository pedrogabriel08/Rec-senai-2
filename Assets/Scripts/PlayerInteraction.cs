using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public TMP_Text interactionText;

    void Update()
    {
        if (interactionText != null)
            interactionText.text = "";

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            Interaçao interactable = hit.collider.GetComponent<Interaçao>();

            if (interactable != null)
            {
                if (interactionText != null)
                    interactionText.text = "[E] Interagir";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
    }
}

public enum InteractionType
{
    Cama,
    Remedios,
    ComidadeCachorro
}
