using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveMentSpeed;
    
    CharacterController character;
    Vector3 moveVector;
   
    public float gravity = -9.82f;
   
   
    public FixedJoystick joyStick;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        

       
      
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            //x   

            float x = joyStick.Horizontal;
            float laptopX = Input.GetAxis("Horizontal");
            //Z
            float z = joyStick.Vertical;
            moveVector = new Vector3(x, 0, z);
            float laptopZ = Input.GetAxis("Vertical");

            Vector3 laptopVector = new Vector3(laptopX, 0, laptopZ);

            character.Move(moveVector * Time.deltaTime * moveMentSpeed);
            character.Move(laptopVector * Time.deltaTime * moveMentSpeed);


           
           

        }
    }

    
    public float healthNumber=5;

    
}
