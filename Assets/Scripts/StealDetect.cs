using System.Collections;
using UnityEngine;

public class StealDetect : MonoBehaviour
{
    public GameObject guard;
    public GameObject player;
    public GameObject jailArea;

    // Update is called once per frame
    void Update()
    {
        Vector3 detect = guard.transform.position;

        RaycastHit hit;

        if (Physics.Raycast(detect, guard.transform.forward ,out hit, 10))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                Debug.Log("DING");
                player.transform.position = jailArea.transform.position;
                player.GetComponent<Movement>().enabled = false;
                StartCoroutine(FixPlayerMovement());
            }
        }
    }

    /// <summary>
    /// Fixes the issue where the player would teleport back to their original location after being teleported to the jail
    /// </summary>
    /// <returns>Return is used here to wait a second before allowing the player to move again.</returns>
    IEnumerator FixPlayerMovement()
    {
        yield return new WaitForSeconds(1);
        player.GetComponent<Movement>().enabled = true;
    }
}
