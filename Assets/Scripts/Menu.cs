using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public bool menuOpen = false;
    public GameObject menu;//Þetta eru UI panel
    public GameObject helpMenu;


    private void Awake()
    {
        Cursor.visible = false;//felur músina
        Cursor.lockState = CursorLockMode.Locked;//Læsir músinni á miðjum skjánum
    }

    void Update()
    {
        if (menu.activeSelf == false && helpMenu.activeSelf == false)//ef menu er ekki opinn er menuOpen false
        {
            menuOpen = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (menuOpen == false && Input.GetKeyDown("escape"))
        {
            menu.SetActive(true);//opnar menu
            menuOpen = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (menuOpen == true && Input.GetKeyDown("escape"))
        {
            menu.SetActive(false);
            menuOpen = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
