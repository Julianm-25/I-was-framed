using UnityEngine;

/// <summary>
/// Allows the player to pick up objects tagged as 'interactable' by pressing the E key.
/// </summary>
public class Interact : MonoBehaviour
{
    public GameObject pickupSpot;
    private GameObject pickupItem;
    private bool isHoldingObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray interact;

            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

            RaycastHit hitInfo;
            
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                if (hitInfo.collider.CompareTag("Interactable"))
                {
                    pickupItem = hitInfo.collider.gameObject;
                    pickupItem.transform.position = pickupSpot.transform.position;
                    pickupItem.transform.parent = pickupSpot.transform;
                    isHoldingObject = true;
                }
            }
        }

        if (isHoldingObject)
        {
            pickupItem.transform.position = pickupSpot.transform.position;
        }
        if (Input.GetKeyUp(KeyCode.E) && isHoldingObject)
        {
            pickupItem.transform.parent = null;
            isHoldingObject = false;
        }
    }
}
