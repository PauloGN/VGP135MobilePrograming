using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ScreenType : int
{
    Main,
    Upgrade,
    Store
}




public class ScreenManager : MonoBehaviour
{
    [SerializeField] private ScreenType _StartingScreen = ScreenType.Main;
    [SerializeField] private List<GameObject> _Screens = null;

    // Start is called before the first frame update
    void Start()
    {
        ShowScreen(_StartingScreen);
  
    }

    //By default only the initial screen is active.
    public void ShowScreen(ScreenType screen)
    {

        for (int i = 0; i < _Screens.Count; i++)
        {
            //return true to the correspondent screen
            _Screens[i].SetActive(i == (int)screen);
        }

    }


    public void CloseScreen()
    {
        //Get back to the main screen and set false to the others
        ShowScreen(_StartingScreen);
    }


}
