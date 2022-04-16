using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScreen : MonoBehaviour
{


    [SerializeField] private ScreenManager _screenManager = null;
    [SerializeField] private GameManager _GameManager = null;


    public void OnClose()
    {

        _screenManager.CloseScreen();

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
