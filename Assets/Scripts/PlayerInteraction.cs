using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interação")]
    [SerializeField] private float interactionDistance = 3f;

    [Header("Referências")]
    [SerializeField] private TMP_Text interactionText;

    private void Update()
    {
        if (interactionText != null)
            interactionText.text = "";

        Ray ray = new Ray(
            transform.position,
            transform.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            Interaçao interactable =
                hit.collider.GetComponent<Interaçao>();

            if (interactable != null)
            {
                if (interactionText != null)
                {
                    interactionText.text =
                        "[E] " + interactable.InteractionText;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
    }
}