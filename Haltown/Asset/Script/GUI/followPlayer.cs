using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float moveSenstivity = 100f;
    public Transform playerBody;
   
  

    private void Start()
    {
         
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * moveSenstivity;
        float mouseY = Input.GetAxis("Mouse Y") * moveSenstivity;

        playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
    }

}
