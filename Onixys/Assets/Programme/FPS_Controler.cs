using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controler : MonoBehaviour {

    public float speed = 10f;
    public float sensitivity = 2f;
    private float xAxisClamp = 0.0f;

    CharacterController player;
    public GameObject eyes;
    float FB;
    float LR;

    float rotX;
    float rotY;

    bool Sprint = false;

    private void Awake()
    {
        //LockCursor();
        player = GetComponent<CharacterController>();
    }

   /* public void LockCursor()
    {
        LockCursor.LockState = CursorLockMode.Locked;
    }*/
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Sprint == true)
            {
                Sprint = false;
                speed = 10f;
            }
            else Sprint = true;
        }
        if (Sprint == true) speed = 20f; 

        FB = Input.GetAxis("Horizontal") * speed;
        LR = Input.GetAxis("Vertical") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        xAxisClamp += rotY;
        
        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            rotY = 0.0f;
        }
        if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            rotY = 0.0f;
        }
        Vector3 forwardMovement = transform.forward * LR;
        Vector3 rightMovement = transform.forward * LR;
        charController.SimpleMove(forwardMovement + rightMovement);

        Vector3 Mouvement = new Vector3(FB, 0, LR);
        transform.Rotate(0, rotX, 0);
        eyes.transform.Rotate(-rotY, 0, 0);
        Mouvement = transform.rotation * Mouvement;
        player.Move (Mouvement * Time.deltaTime);
	}
}
