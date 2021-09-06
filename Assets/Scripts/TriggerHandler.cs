using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerHandler : MonoBehaviour
{
    public List<GameObject> triggerZones;
    public Text areaText;
    public bool isInMainRoom;
    // Start is called before the first frame update
    void Start()
    {
        areaText.text = "Current location: Main Hall";
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ding");
        if (other.gameObject == triggerZones[0] && isInMainRoom)
        {
            areaText.text = "Current location: Portrait Hall";
            StartCoroutine(WaitToSetFalse());
        }
        else if (other.gameObject == triggerZones[1] && isInMainRoom)
        {
            areaText.text = "Current location: Landscape Hall";
            StartCoroutine(WaitToSetFalse());
        }
        else if (other.gameObject == triggerZones[2] && isInMainRoom)
        {
            areaText.text = "Current location: Jail :(";
            StartCoroutine(WaitToSetFalse());
        }
        else
        {
            areaText.text = "Current location: Main Hall";
            StartCoroutine(WaitToSetTrue());
        }
    }

    IEnumerator WaitToSetFalse()
    {
        yield return new WaitForSeconds(1);
        isInMainRoom = false;
    }
    IEnumerator WaitToSetTrue()
    {
        yield return new WaitForSeconds(1);
        isInMainRoom = true;
    }
}
