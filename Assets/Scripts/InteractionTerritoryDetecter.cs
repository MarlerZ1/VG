using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTerritoryDetecter : MonoBehaviour
{
    [SerializeField] private Interaction _interaction;
    [SerializeField] private InteractionHandler _interactionHandler;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _interaction.OnInteract += _interactionHandler.Interaction;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _interaction.OnInteract -= _interactionHandler.Interaction;
        }
    }
}
