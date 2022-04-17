using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeScreen : MonoBehaviour
{


    [SerializeField] private ScreenManager _screenManager = null;
    [SerializeField] private GameManager _GameManager = null;
    [SerializeField] private Button _UpgradeClickButton = null;
    [SerializeField] private Button _UpgradeAutoButton = null;


    [SerializeField] private TMP_Text _UpgradeButtonCostText = null;
    [SerializeField] private TMP_Text _UpgradeAutoButtonCostText = null;
    [SerializeField] private TMP_Text _UpgradeButtonLevelText = null;
    [SerializeField] private TMP_Text _UpgradeAutoButtonLevelText = null;
    [SerializeField] private TMP_Text _UpgradeButtonAmountText = null;
    [SerializeField] private TMP_Text _UpgradeAutoButtonAmountText = null;


    //Get back to the main screen
    public void OnClose()
    {

        _screenManager.CloseScreen();

    }


    // Start is called before the first frame update
    void Start()
    {

        _UpgradeClickButton.interactable = _GameManager.CanAffordClickUpgrade();
        _UpgradeAutoButton.interactable = _GameManager.CanAffordAutoUpgrade();
        UpdateDisplay();

    }

    // Update is called once per frame
    void Update()
    {

        _UpgradeClickButton.interactable = _GameManager.CanAffordClickUpgrade();
        _UpgradeAutoButton.interactable = _GameManager.CanAffordAutoUpgrade();

    }

    private void OnEnable()
    {
        UpdateDisplay();
    }


    public void OnUpgradeClick()
    {
       if(_GameManager.UpgradeClicks())
        {
            UpdateDisplay();
        }
    }

    public void OnUpgradeAuto()
    {
        if (_GameManager.UpgradeAuto())
        {
            UpdateDisplay();
        }
    }


    private void UpdateDisplay()
    {

        _UpgradeButtonCostText.text = "COST " + _GameManager.GetClickUpgradeCost().ToString();
        _UpgradeAutoButtonCostText.text = "COST " + _GameManager.GetAutoUpgradeCost().ToString();

        _UpgradeButtonLevelText.text = "Lvl " + _GameManager.GetClickLevel().ToString();
        _UpgradeAutoButtonLevelText.text = "Lvl " + _GameManager.GetAutoLevel().ToString();

        _UpgradeButtonAmountText.text = "AMT " + _GameManager.GetPointsPerClick().ToString();
        _UpgradeAutoButtonAmountText.text = "AMT " + _GameManager.GetAutoPoints().ToString();

    }

}
