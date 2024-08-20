using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Menu[] menus;

    public void OpenMenu(string _name)
    {
        foreach (var menu in menus)
        {
            if (menu.nameMenu == _name) {
                menu.Open();
                continue;
            }
            if(menu.isOpen) menu.Close();
        }
    }
}
