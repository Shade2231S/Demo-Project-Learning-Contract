using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControllerV2 : MonoBehaviour
{
    public CharacterController con;
    private float currentspeed;
    public float walkspeed = 4.5f;
    public float runspeed = 8f;
    public float lookspeed = 4f;
    public float lookxlimit = 85f;
    public float gravity = 10f;
    private float lookrotation;
    Vector3 velocity;
    public Camera camera;
    public bool isrunning = false;
    public void Start()
    {
        con = GetComponent<CharacterController>();
        currentspeed = walkspeed;       
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * y;
        con.Move(move * currentspeed * Time.deltaTime);
        move *= currentspeed;
        velocity.y -= gravity * Time.deltaTime;
        con.Move(velocity * Time.deltaTime); ;       
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isrunning = true;
            currentspeed = runspeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isrunning = false;
            currentspeed = walkspeed;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            isrunning = false;
            currentspeed = walkspeed;
        }
    }
    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookspeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookspeed;
        lookrotation -= mouseY;
        lookrotation = Mathf.Clamp(lookrotation, -lookxlimit, lookxlimit);
        camera.transform.localRotation = Quaternion.Euler(lookrotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
