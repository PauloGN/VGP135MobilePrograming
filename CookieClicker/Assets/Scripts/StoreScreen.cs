using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScreen : MonoBehaviour
{


    [SerializeField] private ScreenManager _screenManager = null;
    [SerializeField] private GameManager _GameManager = null;

    public void OnClose()
    {

        _screenManager.CloseScreen();

    }


    public void OnPurchaseClickBonus(int amount)
    {

        _GameManager.IncreaseClickPoints(amount);

    }

    public void OnPurchaseAutoBonus(int amount)
    {

        _GameManager.IncreaseAutoPoints(amount);

    }




}
