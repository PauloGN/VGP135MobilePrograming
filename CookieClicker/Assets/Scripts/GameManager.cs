using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float  _TimePerAutoUpdate = 1.0f;
    [SerializeField] private TMP_Text _CoinAmountText = null;
    private int _CoinAmount = 0;

    //Variables of control: Controls the amount of points per click and also the amount automatically computed.
    private int _PointsPerClick = 1;
    private int _AutoPoints = 0;

    private float _TimeUntilNextUpdate = 0.0f;

    //Keep track of upgrades costs
    private int _ClickUpgradeCost = 0;
    private int _AutoUpgradeCost = 0;

    private int _ClickUpgradeAmount = 0;
    private int _AutoUpgradeAmount = 0;

    private int _ClickUpgradeLevel = 0;
    private int _AutoUpgradeLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Set initial values to upgrades
        _ClickUpgradeCost = 10;
        _AutoUpgradeCost = 10;
        _ClickUpgradeAmount = 1;
        _AutoUpgradeAmount = 1;

        UpdateCoinCountDisplay();
    }


     void Update()
    {
        //It only works if the player has automatic points to be computed
        if (_AutoPoints > 0)
        {
            _TimeUntilNextUpdate -= Time.deltaTime;

            //checks the time till next auto point(1 sec by default)
            while (_TimeUntilNextUpdate <= 0.0f)
            {
                AddCoins(_AutoPoints);
                _TimeUntilNextUpdate += _TimePerAutoUpdate;
            }

        }

    }

    //Updates the screen information to tell how many points the user has.
    private void UpdateCoinCountDisplay()
    {

        _CoinAmountText.text = _CoinAmount.ToString();

    }


    public int GetCoinAmount()
    {
        return _CoinAmount;
    }


    public bool CanAffordClickUpgrade()
    {
        return _CoinAmount >= _ClickUpgradeCost;
    }

    public bool CanAffordAutoUpgrade()
    {
        return _CoinAmount >= _AutoUpgradeCost;
    }

    public int GetClickUpgradeCost()
    {
        return _ClickUpgradeCost;
    }

    public int GetAutoUpgradeCost()
    {
        return _AutoUpgradeCost;
    }


    public int GetPointsPerClick()
    {
        return _PointsPerClick;
    }

    public int GetAutoPoints()
    {
        return _AutoPoints;
    }

    public int GetClickLevel()
    {
        return _ClickUpgradeLevel;
    }

    public int GetAutoLevel()
    {
        return _AutoUpgradeLevel;
    }



    public bool UpgradeClicks()
    {
        if (CanAffordClickUpgrade())
        {
            AddCoins(-_ClickUpgradeCost);
            _PointsPerClick += _ClickUpgradeAmount;

            ++_ClickUpgradeLevel;

            _ClickUpgradeCost = (_ClickUpgradeLevel * 10) + (Mathf.FloorToInt((float)_ClickUpgradeLevel / 5) * 5);
            _ClickUpgradeAmount = Mathf.Max((Mathf.FloorToInt((float)_ClickUpgradeLevel / 3.0f) * 5),1);

            return true;
        }

        return false;
    }

    public bool UpgradeAuto()
    {
        if (CanAffordAutoUpgrade())
        {
            AddCoins(-_AutoUpgradeCost);
            _AutoPoints += _AutoUpgradeAmount;

            ++_AutoUpgradeLevel;

            _AutoUpgradeCost = (_AutoUpgradeLevel * 15) + (Mathf.FloorToInt((float)_AutoUpgradeLevel / 5) * 12);
            _AutoUpgradeAmount = _AutoUpgradeLevel + (Mathf.FloorToInt((float)_AutoUpgradeLevel / 10.0f) * 5);

            return true;
        }

        return false;
    }

    //Called every time that on fire event is triggered from the main screen by being clicked.
    public void AddClickPoints()
    {
        AddCoins(_PointsPerClick);
    }

    //Simple addition based on the parameter
    public void AddCoins(int amount)
    {

        _CoinAmount += amount;
        UpdateCoinCountDisplay();

    }

    //Called every time we want to increase the amount of points per click.
    public void IncreaseClickPoints(int amount)
    {

        _PointsPerClick += amount;

    }

    //Called every time we want to increase the amount of auto points per second.
    public void IncreaseAutoPoints(int amount)
    {

        _AutoPoints += amount;

    }




}
