using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image upgrade;
    public Image researchPoint;
    public Image esc;

    public Button upButton;
    public Button reButton;

    public Button x10Button;

    public Button SFXButton;
    public Button BGMButton;
    public Button ArmButton;


    public Sprite x10OnImg;
    public Sprite x10OffImg;
    public Sprite SFXOnImg;
    public Sprite SFXOffImg;
    public Sprite BGMOnImg;
    public Sprite BGMOffImg;
    public Sprite AlarmOnImg;
    public Sprite AlarmOffImg;

    SaveLoad saveload;
    Money money;

    bool isSFX = true;
    bool isBGM = true;
    bool isArm = true;

    bool isX10 = false;

    //option
    public Image option;
    public Image reset;

    private void Start()
    {
        saveload = GetComponent<SaveLoad>();
        money = GetComponent<Money>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TryQuit();
        }
    }


    public void UpgradeOn()
    {
        upButton.gameObject.SetActive(false);
        reButton.gameObject.SetActive(false);
        upgrade.gameObject.SetActive(true);
    }
    public void ResearchPointOn()
    {
        upButton.gameObject.SetActive(false);
        reButton.gameObject.SetActive(false);
        researchPoint.gameObject.SetActive(true);
    }
    public void Back()
    {
        upgrade.gameObject.SetActive(false);
        researchPoint.gameObject.SetActive(false);
        upButton.gameObject.SetActive(true);
        reButton.gameObject.SetActive(true);
    }

    public void OptionOn()
    {
        option.gameObject.SetActive(true);
        upButton.gameObject.SetActive(false);
        reButton.gameObject.SetActive(false);
        upgrade.gameObject.SetActive(false);
        researchPoint.gameObject.SetActive(false);
    }

    public void OptionOff()
    {
        option.gameObject.SetActive(false);
        upButton.gameObject.SetActive(true);
        reButton.gameObject.SetActive(true);
    }

    public void SFX()
    {
        isSFX = !isSFX;

        if (isSFX) SFXButton.image.sprite = SFXOnImg;
        else SFXButton.image.sprite = SFXOffImg;
    }
    
    public void Alarm()
    {
        isArm = !isArm;

        if (isArm) ArmButton.image.sprite = AlarmOnImg;
        else ArmButton.image.sprite = AlarmOffImg;
    }

    public void BGM()
    {
        isBGM = !isBGM;

        if (isBGM) BGMButton.image.sprite = BGMOnImg;
        else BGMButton.image.sprite = BGMOffImg;
    }

    public void X10()
    {
        isX10 = !isX10;

        if (isX10) x10Button.image.sprite = x10OnImg;
        else x10Button.image.sprite = x10OffImg;
    }
    public void TryQuit()
    {
        esc.gameObject.SetActive(true);
        upButton.gameObject.SetActive(false);
        reButton.gameObject.SetActive(false);
        upgrade.gameObject.SetActive(false);
        researchPoint.gameObject.SetActive(false);
    }

    public void NoQuit()
    {
        esc.gameObject.SetActive(false);
        upButton.gameObject.SetActive(true);
        reButton.gameObject.SetActive(true);
    }
    public void Quit()
    {
        money.GameSave();
        Application.Quit();
    }
    public void TryReset()
    {
        reset.gameObject.SetActive(true);
        option.gameObject.SetActive(false);
    }
    public void NoReset()
    {
        reset.gameObject.SetActive(false);
        option.gameObject.SetActive(true);
    }


}
