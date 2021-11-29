using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class WeaponHandler : MonoBehaviour
{
    public int selectedWeapon = 0;
    InputAction switching;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {

        switching = new InputAction("Scroll", binding: "<mouse>/scroll");
        switching.AddBinding("Gamepad/Dpad");
        switching.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        Gun currentGun = FindObjectOfType<Gun>();
        text.text = currentGun.currentAmmo + " /" + currentGun.magazineSize;
        /*  float scrollValue = switching.ReadValue<Vector2>().y;
          int prevousSelected = selectedWeapon;
          if (scrollValue > 0)
          {
              selectedWeapon++;
              if (selectedWeapon == 3)
              {
                  selectedWeapon = 0;
              }

              else if (scrollValue < 0)
              {
                  selectedWeapon--;
                  if (selectedWeapon == -1)
                  {
                      selectedWeapon = 2;
                  }
              }
          }

  if(prevousSelected !=selectedWeapon)

          Selected();
      }
      private void Selected()
      {
          foreach (Transform weapon in transform)
          {
              weapon.gameObject.SetActive(false);
          }

          transform.GetChild(selectedWeapon).gameObject.SetActive(true);
      }*/
    }
}

