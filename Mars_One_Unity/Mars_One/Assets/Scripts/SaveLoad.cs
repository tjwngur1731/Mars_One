using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    Money money;


    public void Start()
    {
        money = GetComponent<Money>();
    }

    public void GameSave()
    {

        PlayerPrefs.SetInt("curMoney", money.curMoney);
        PlayerPrefs.SetInt("addMoney", money.addMoney);
        PlayerPrefs.SetInt("baseAddMoney", money.baseAddMoney);
        PlayerPrefs.SetInt("labAddMoney", money.labAddMoney);
        PlayerPrefs.SetInt("farmAddMoney", money.farmAddMoney);
        PlayerPrefs.SetInt("baseUpMoney", money.baseUpMoney);
        PlayerPrefs.SetInt("labUpMoney", money.labUpMoney);
        PlayerPrefs.SetInt("farmUpMoney", money.farmUpMoney);
        PlayerPrefs.SetInt("humanCount", money.humanCount);
        PlayerPrefs.SetInt("baseLv", money.baseLv);
        PlayerPrefs.SetInt("labLv", money.labLv);
        PlayerPrefs.SetInt("farmLv", money.farmLv);
        PlayerPrefs.SetInt("labOn", money.labOn);
        PlayerPrefs.SetInt("farmOn", money.farmOn);
        PlayerPrefs.SetInt("curPoint", money.curPoint);
        PlayerPrefs.SetInt("eventUpPoint", money.eventUpPoint);
        PlayerPrefs.SetInt("waterUpPoint", money.waterUpPoint);
        PlayerPrefs.SetInt("waterLv", money.waterLv);

        PlayerPrefs.SetString("SaveLastTime", System.DateTime.Now.ToString());

        PlayerPrefs.Save();
    }
}
