using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour
{
    //Gets a refence to the script that holds the functionality to swich screens on and off
    [SerializeField] private ScreenManager _screenManager = null;
    [SerializeField] private GameManager _GameManager = null;

    //Tells the screen manager which screen should be active and deactivates the others
    public void OnUpgradeScreenClicked()
    {

        _screenManager.ShowScreen(ScreenType.Upgrade);

    }
    //Tells...active and deactivates the others
    public void OnStoreScreenClicked()
    {

        _screenManager.ShowScreen(ScreenType.Store);

    }


    //OnCookieClicked
    public void OnFireClicked()
    {

        //Add Score
        _GameManager.AddClickPoints();

    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
