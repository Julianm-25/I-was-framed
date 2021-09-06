using UnityEngine;
/// <summary>
/// Disables the player character’s ragdoll on start, and changes the camera to third person and allows the player to dance while the F key is held.
/// </summary>
public class RagDoller : MonoBehaviour
{
    /// <summary>
    /// The first person camera
    /// </summary>
    public GameObject camera1;
    /// <summary>
    /// Third Person camera
    /// </summary>
    public GameObject camera2;
    /// <summary>
    /// The animator in charge of the 'dance' animation
    /// </summary>
    public Animator anim;
    
    void Start()
    {
        var anim = GetComponent<Animator>();
        anim.enabled = false;
        DisableRagdoll();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            Dance();
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            anim.enabled = false;
        }
    }

    void DisableRagdoll()
    {
        var bodies = GetComponentsInChildren<Rigidbody>();

        foreach (var body in bodies)
        {
            body.isKinematic = true;
        }
    }

    void Dance()
    {
        anim.enabled = true;
        anim.Play("Gangnam Style", -1, 0f);
    }
}
