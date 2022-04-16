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


    public void ShowScreen(ScreenType screen)
    {

        for (int i = 0; i < _Screens.Count; i++)
        {
            _Screens[i].SetActive(i == (int)screen);
        }

    }


    public void CloseScreen()
    {
        ShowScreen(_StartingScreen);
    }


}
