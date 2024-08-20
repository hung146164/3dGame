using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string nameMenu;
    public bool isOpen = false;
    
    public void Open()
    {
        gameObject.SetActive(true);
        isOpen = true;
    }
    public void Close()
    {
        gameObject.SetActive(false);
        isOpen = false;
    }
}
