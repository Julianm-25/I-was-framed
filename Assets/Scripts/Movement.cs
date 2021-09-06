using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController playerChar;
    private Rigidbody playerBody;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        playerChar = GetComponent<CharacterController>();
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerChar.Move(move * Time.deltaTime * speed);
        float cameraRotation = Camera.main.transform.rotation.eulerAngles.y;
        playerBody.position += Quaternion.Euler(0, cameraRotation, 0) * move * speed * Time.deltaTime;*/
        
        Vector3 move = Quaternion.Euler (0, playerChar.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        playerChar.Move(move * Time.deltaTime * speed);
        
    }
}
