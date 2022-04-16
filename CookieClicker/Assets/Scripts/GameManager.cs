using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float  _TimePerAutoUpdate = 1.0f;
    [SerializeField] private TMP_Text _CoinAmountText = null;
    private int _CoinAmount = 0;

    private int _PointsPerClick = 1;
    private int _AutoPoints = 0;


    private float _TimeUntilNextUpdate = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        UpdateCoinCountDisplay();
    }


     void Update()
    {

        if (_AutoPoints > 0)
        {
            _TimeUntilNextUpdate -= Time.deltaTime;

            while (_TimeUntilNextUpdate <= 0.0f)
            {

                AddCoins(_AutoPoints);
                _TimeUntilNextUpdate += _TimePerAutoUpdate;
            }

        }

    }


    private void UpdateCoinCountDisplay()
    {

        _CoinAmountText.text = _CoinAmount.ToString();

    }




    public void AddClickPoints()
    {


        AddCoins(_PointsPerClick);

    }



    public void AddCoins(int amount)
    {

        _CoinAmount += amount;
        UpdateCoinCountDisplay();

    }

    public void IncreaseClickPoints(int amount)
    {

        _PointsPerClick += amount;

    }


    public void IncreaseAutoPoints(int amount)
    {

        _AutoPoints += amount;

    }




}
