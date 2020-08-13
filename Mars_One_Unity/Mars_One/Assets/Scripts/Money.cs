using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Pooling;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;

public class Money : MonoBehaviour
{
    //현재 돈
    public int curMoney;

    //초당 올라갈 돈
    public int addMoney;

    //건물별 초당 올라갈 돈
    public int baseAddMoney;
    public int labAddMoney;
    public int farmAddMoney;
    public int houseAddMoney;

    //기지별 업그레이드에 필요한 돈
    public int baseUpMoney;
    public int baseUpMoneyX10;
    public int labUpMoney;
    public int labUpMoneyX10;
    public int farmUpMoney;
    public int farmUpMoneyX10;
    public int houseUpMoney;
    public int houseUpMoneyX10;

    //업그레이드 할 때마다 필요한 돈이 늘어날 수치
    public int baseUpUpMoney;
    public int labUpUpMoney;
    public int farmUpUpMoney;
    public int houseUpUpMoney;
    //연구 할 때 마다 필요할 포인트가 늘어날 수치
    public int waterUpUpPoint;

    //업그레이드 할 때마다 벌리는 돈이 늘어날 수치
    public int baseAddUpMoney;
    public int labAddUpMoney;
    public int farmAddUpMoney;
    public int houseAddUpMoney;

    //사람 수
    public int humanCount;

    //건물별 레벨
    public int baseLv;
    public int labLv;
    public int farmLv;
    public int houseLv;

    //현재 보유 중인 연구 포인트
    public int curPoint;

    //연구 포인트 이벤트 발생 시 올라갈 포인트
    public int eventUpPoint;

    //정수 시스템 연구에 필요한 포인트
    public int waterUpPoint;

    //정수 시스템 레벨
    public int waterLv;

    //오프라인 보상
    public int offlineLv;
    //총 오프라인 보상
    public int offlineMoney;

    //돈이 들어올 딜레이
    public float curDelay;
    public float maxDelay;

    //건물별 존재 여부
    public int labOn;
    public int farmOn;
    public int houseOn;

    //현재 돈으로 업그레이드가 가능한지 확인
    public bool baseUpCan;
    public bool labUpCan;
    public bool farmUpCan;
    public bool houseUpCan;

    //첫 플레인지 확인
    public bool isFirstPlay;

    //현재 연구 포인트 이벤트 존재 여부
    public bool isre;

    //10배 버튼이 활성화되었는지 확인
    public bool isX10;

    //현재 돈을 표시할 UI
    public Text curMoneyText;

    //늘어날 돈을 표시할 텍스트 UI
    public Text addMoneyText;

    //건물별 늘어날 돈을 표시할 텍스트 UI
    public Text baseAddMoneyText;
    public Text labAddMoneyText;
    public Text farmAddMoneyText;
    public Text houseAddMoneyText;

    //업그레이드에 필요할 돈을 표시할 텍스트 UI
    public Text baseUpMoneyText;
    public Text labUpMoneyText;
    public Text farmUpMoneyText;
    public Text houseUpMoneyText;
    //연구에 필요할 돈을 필요할 텍스트
    public Text waterUpPointText;

    //건물별 레벨을 표시할 텍스트 UI
    public Text baseLvText;
    public Text labLvText;
    public Text farmLvText;
    public Text houseLvText;
    //연구 레벨 표시
    public Text waterLvText;

    //현재 연구 포인트를 표시할 텍스트 UI
    public Text curPointText;

    //오프라인 보상을 표시할 텍스트 UI
    public Text offlineMoneyText;

    //오프라인 보상 UI
    public Image offlineReward;

    //건물별 업그레이드 버튼
    public Button baseUpButton;
    public Button labUpButton;
    public Button farmUpButton;
    public Button houseUpButton;
    //건물 잠금해제 버튼
    public Button labLockoffButton;
    public Button farmLockoffButton;
    public Button houseLockoffButton;

    //풀링할 사람 오브젝트
    public GameObject humanObj;
    //건물별 오브젝트
    public GameObject farmObj;
    public GameObject labObj;
    public GameObject houseObj;

    //베이스 위에 뜰 돈 버는 이펙트 프리펩
    public GameObject hudMoneyText;
    //돈 이펙트의 위치
    public Transform baseHudPos;
    public Transform labHudPos;
    public Transform farmHudPos;
    public Transform houseHudPos;

    //버튼 꺼짐 스프라이트
    public Sprite cantUpSprite;
    public Sprite canUpSprite;
    //연구 버튼 꺼짐 스프라이트
    public Sprite canResearchSprite;
    public Sprite cantResearchSprite;

    //건물 생성 이펙트
    public ParticleSystem particleSystem;
    

    ObjectPool<HumanObj> human = new ObjectPool<HumanObj>();

    void Start()
    {
        human.Init(humanObj, 1, null, null, transform, false);
        GameLoad();

        human.Spawn(new Vector3(Random.Range(-3, 3), 1, Random.Range(-3, 3)), Quaternion.Euler(0, 0, 0));
    }

    void Update()
    {
        TextSet();
        addMoneyText.text = addMoney.ToString();
        //10배 업그레이드시 필요한 돈 계산
        baseUpMoneyX10 = (baseUpMoney * 10) + (baseUpUpMoney * 45);
        labUpMoneyX10 = (labUpMoney * 10) + (labUpUpMoney * 45);
        farmUpMoneyX10 = (farmUpMoney * 10) + (farmUpUpMoney * 45);
        houseUpMoneyX10 = (houseUpMoney * 10) + (houseUpMoney * 45);

        //클릭시 실행
        if (Input.GetButton("Fire1")) OnClick();
        //딜레이 계산을 위해 현재 시간 더해주기
        curDelay += Time.deltaTime;
        //늘어나는 돈 표시
        addMoneyText.text = addMoney.ToString();
        //설정한 딜레이 시간마다 실행
        if (curDelay>=maxDelay)
        {
            MakeMoney();

            //딜레이 초기화
            curDelay = 0;
        }
        if(isX10)
        {
            if (curMoney >= baseUpMoneyX10) baseUpCan = true;
            else baseUpCan = false;
            if (curMoney >= labUpMoneyX10) labUpCan = true;
            else labUpCan = false;
            if (curMoney >= farmUpMoneyX10) farmUpCan = true;
            else farmUpCan = false;
        }
        else if(!isX10)
        {
            if (curMoney >= baseUpMoney) baseUpCan = true;
            else baseUpCan = false;
            if (curMoney >= labUpMoney) labUpCan = true;
            else labUpCan = false;
            if (curMoney >= farmUpMoney) farmUpCan = true;
            else farmUpCan = false;
        }
        if (!baseUpCan) baseUpButton.image.sprite = cantUpSprite;
        else baseUpButton.image.sprite = canUpSprite;
        if (!labUpCan) labUpButton.image.sprite = cantUpSprite;
        else labUpButton.image.sprite = canUpSprite;
        if (!farmUpCan) farmUpButton.image.sprite = cantUpSprite;
        else farmUpButton.image.sprite = canUpSprite;
        addMoneyText.text += "/ 초";
    }


    public void MakeMoneyEffect()
    {
        BaseMakeMoneyEffect();
        LabMakeMoneyEffect();
        FarmMakeMoneyEffect();
        HouseMakeMoneyEffect();
    }

    //벌리는 돈 계산
    public void MakeMoney()
    {
        addMoney = baseAddMoney + labAddMoney + farmAddMoney;
        curMoney += addMoney;
        curMoneyText.text = curMoney.ToString();
        MakeMoneyEffect();
    }

    //건물별 돈 생산 이펙트
    public void BaseMakeMoneyEffect()
    {
        GameObject hudText = Instantiate(hudMoneyText);
        hudText.transform.position = baseHudPos.position;
        hudText.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        hudText.GetComponent<AddMoneyText>().addMoney = baseAddMoney;
    }
    public void LabMakeMoneyEffect()
    {
        if (labOn == 0) return;
        GameObject hudText = Instantiate(hudMoneyText);
        hudText.transform.position = labHudPos.position;
        hudText.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        hudText.GetComponent<AddMoneyText>().addMoney = labAddMoney;
    }
    public void FarmMakeMoneyEffect()
    {
        if (farmOn == 0) return;
        GameObject hudText = Instantiate(hudMoneyText);
        hudText.transform.position = farmHudPos.position;
        hudText.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        hudText.GetComponent<AddMoneyText>().addMoney = farmAddMoney;
    }

    public void HouseMakeMoneyEffect()
    {
        if (houseOn == 0) return;
        GameObject hudText = Instantiate(hudMoneyText);
        hudText.transform.position = houseHudPos.position;
        hudText.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        hudText.GetComponent<AddMoneyText>().addMoney = houseAddMoney;
    }


    //건물별 업그레이드
    public void BaseUp()
    {
        if (isX10) BaseUpgradeX10();
        else BaseUpgrade();
    }

    public void LabUP()
    {
        if (isX10) LabUpgradeX10();
        else LabUpgrade();
    }

    public void FarmUp()
    {
        if (isX10) FarmUpgradeX10();
        else FarmUpgrade();
    }
    public void HouseUp()
    {
        if (isX10) HouseUpgradeX10();
        else HouseUpgrade();
    }


    public void BaseUpgrade()
    {
        if(curMoney>=baseUpMoney)
        {
            curMoney -= baseUpMoney;
            baseUpMoney += baseUpUpMoney;
            baseUpMoneyText.text = baseUpMoney.ToString();
            curMoneyText.text = curMoney.ToString();
            baseLv++;
            baseAddMoney+=baseAddUpMoney;
            baseLvText.text = baseLv.ToString();
            baseAddMoneyText.text = baseAddMoney.ToString();
            if (baseLv % 10 == 0)
            {
                human.Spawn(new Vector3(Random.Range(-3, 3), 1, Random.Range(-3, 3)), Quaternion.Euler(0, 0, 0));
                humanCount++;
            }

        }

        //레벨 50이 되면 다음 건물인 연구소 버튼 활성화
        if (baseLv >= 50 && labOn == 0)
        {
            labLockoffButton.gameObject.SetActive(true);
            labOn = 1;
        }

    }
    public void BaseUpgradeX10()
    {
        if(curMoney>= baseUpMoneyX10)
        {
            for(int i=0;i<10;i++)
            {
                BaseUpgrade();
            }
        }

        if (baseLv >= 50 && labOn == 0)
        {
            labLockoffButton.gameObject.SetActive(true);
            labOn = 1;
        }

        baseUpMoneyText.text = baseUpMoneyX10.ToString();
    }

    public void LabUpgrade()
    {
        if (curMoney >= labUpMoney)
        {
            curMoney -= labUpMoney;
            labUpMoney += labUpUpMoney;
            labUpMoneyText.text = labUpMoney.ToString();
            curMoneyText.text = curMoney.ToString();
            labLv++;
            labAddMoney += labAddUpMoney;
            labAddMoneyText.text = labAddMoney.ToString();
            labLvText.text = labLv.ToString();
        }

        if (labLv >= 50 && farmOn == 0) farmLockoffButton.gameObject.SetActive(true);
    }
    public void LabUpgradeX10()
    {
        if (curMoney >= labUpMoneyX10)
        {
            for(int i=0;i<10;i++)
            {
                LabUpgrade();
            }
        }

        if (labLv >= 50 && farmOn == 0) farmLockoffButton.gameObject.SetActive(true);

        labUpMoneyText.text = labUpMoneyX10.ToString();
    }

    public void FarmUpgrade()
    {
        if (curMoney >= farmUpMoney)
        {
            curMoney -= farmUpMoney;
            farmUpMoney += farmUpUpMoney;
            farmUpMoneyText.text = farmUpMoney.ToString();
            curMoneyText.text = curMoney.ToString();
            farmLv++;
            farmAddMoney += farmAddUpMoney;
            farmAddMoneyText.text = farmAddMoney.ToString();
            farmLvText.text = farmLv.ToString();
        }

        if (farmLv >= 50 && houseOn == 0) houseLockoffButton.gameObject.SetActive(true);
    }
    public void FarmUpgradeX10()
    {
        if (curMoney >= farmUpMoneyX10)
        {
            for(int i=0;i<10;i++)
            {
                FarmUpgrade();
            }
            
        }
        if (farmLv >= 50 && houseOn == 0) houseLockoffButton.gameObject.SetActive(true);
        farmUpMoneyText.text = farmUpMoneyX10.ToString();
    }
    public void HouseUpgrade()
    {
        if (curMoney >= houseUpMoney)
        {
            curMoney -= houseUpMoney;
            houseUpMoney += houseUpUpMoney;
            houseUpMoneyText.text = houseUpMoney.ToString();
            curMoneyText.text = curMoney.ToString();
            houseLv++;
            houseAddMoney += houseAddUpMoney;
            houseAddMoneyText.text = houseAddMoney.ToString();
            houseLvText.text = houseLv.ToString();
        }
    }


    public void HouseUpgradeX10()
    {
        if (curMoney >= houseUpMoneyX10)
        {
            for(int i=0;i<10;i++)
            {
                HouseUpgrade();
            }
            
        }
        houseUpMoneyText.text = houseUpMoneyX10.ToString();
    }

    //건물 생성
    public void LabLockOff()
    {
        if(curMoney>=50)
        {
            labObj.SetActive(true);
            labUpButton.gameObject.SetActive(true);
            labOn = 1;
            curMoney -= 50;
            labUpMoney += labUpUpMoney;
            labUpMoneyText.text = labUpMoney.ToString();
            SpawnEffect(labObj);
            labLv++;
            labAddMoney += labAddUpMoney;
            labLvText.text = labLv.ToString();
            labAddMoneyText.text = labAddMoney.ToString();
            labLockoffButton.gameObject.SetActive(false);
        }
    }
    public void FarmLockOff()
    {
        if(curMoney>=150)
        {
            farmObj.SetActive(true);
            farmUpButton.gameObject.SetActive(true);
            farmOn = 1;
            curMoney -= 150;
            farmUpMoney += farmUpUpMoney;
            farmUpMoneyText.text = farmUpMoney.ToString();
            SpawnEffect(farmObj);
            farmLv++;
            farmAddMoney += farmAddUpMoney;
            farmLvText.text = farmLv.ToString();
            farmAddMoneyText.text = farmAddMoney.ToString();
            farmLockoffButton.gameObject.SetActive(false);
        }
    }

    public void HouseLockOff()
    {
        if (curMoney >= 500)
        {
            houseObj.SetActive(true);
            houseUpButton.gameObject.SetActive(true);
            houseOn = 1;
            curMoney -= 500;
            houseUpMoney += houseUpUpMoney;
            houseUpMoneyText.text = houseUpMoney.ToString();
            SpawnEffect(houseObj);
            houseLv++;
            houseAddMoney += houseAddUpMoney;
            houseLvText.text = houseLv.ToString();
            houseAddMoneyText.text = houseAddMoney.ToString();
            houseLockoffButton.gameObject.SetActive(false);
        }
    }


    //건물 생성 이펙트
    public void SpawnEffect(GameObject target)
    {
        ParticleSystem obj = Instantiate(particleSystem, target.transform.position, target.transform.rotation);

        target.SetActive(true);
    }

    //연구
    public void WaterUpgrade()
    {
        if(curPoint >= waterUpPoint)
        {
            curPoint -= waterUpPoint;
            waterLv++;
            offlineLv++;
            waterUpPoint += waterUpUpPoint;
            //SpawnEffect(labObj);

            waterLvText.text = waterLv.ToString();
            curPointText.text = curPoint.ToString();
            waterUpPointText.text = waterUpPoint.ToString();
        }
    }

    //연구 포인트 팝업 이벤트
    public void ResearchEvent(RaycastHit hit)
    {
        curPoint += eventUpPoint;
        Destroy(hit.transform.gameObject);
        isre = false;

        curPointText.text = curPoint.ToString();
    }

    //오프라인 보상
    public void GetOfflineReward()
    {
        curMoney += offlineMoney;
        offlineReward.gameObject.SetActive(false);
        curMoneyText.text = curMoney.ToString();
    }

    //클릭시 실행될 함수
    void OnClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform.gameObject.tag == "ResearchEvent")
            {
                ResearchEvent(hit);
            }
        }
    }

    //연구 포인트 오브젝트 풀링을 위해 존재 여부 컨트롤
    public bool GetRe()
    {
        return isre;
    }
    public void SetRe(bool re)
    {
        isre = re;
    }

    public void X10()
    {
        isX10 = !isX10;

        if (isX10)
        {
            baseUpMoneyText.text = baseUpMoneyX10.ToString();
            labUpMoneyText.text = labUpMoneyX10.ToString();
            farmUpMoneyText.text = farmUpMoneyX10.ToString();
        }
        else
        {
            baseUpMoneyText.text = baseUpMoney.ToString();
            labUpMoneyText.text = labUpMoney.ToString();
            farmUpMoneyText.text = farmUpMoney.ToString();
        }
    }

    //저장
    public void GameSave()
    {
        PlayerPrefs.SetInt("curMoney", curMoney);
        PlayerPrefs.SetInt("addMoney", addMoney);
        PlayerPrefs.SetInt("baseAddMoney", baseAddMoney);
        PlayerPrefs.SetInt("labAddMoney", labAddMoney);
        PlayerPrefs.SetInt("farmAddMoney", farmAddMoney);
        PlayerPrefs.SetInt("baseAddUpMoney", baseAddUpMoney);
        PlayerPrefs.SetInt("labAddUpMoney", labAddUpMoney);
        PlayerPrefs.SetInt("farmAddUpMoney", farmAddUpMoney);
        PlayerPrefs.SetInt("baseUpMoney", baseUpMoney);
        PlayerPrefs.SetInt("labUpMoney", labUpMoney);
        PlayerPrefs.SetInt("farmUpMoney", farmUpMoney);
        PlayerPrefs.SetInt("baseUpUpMoney", baseUpUpMoney);
        PlayerPrefs.SetInt("labUpUpMoney", labUpUpMoney);
        PlayerPrefs.SetInt("farmUpUpMoney", farmUpUpMoney);
        PlayerPrefs.SetInt("humanCount", humanCount);
        PlayerPrefs.SetInt("baseLv", baseLv);
        PlayerPrefs.SetInt("labLv", labLv);
        PlayerPrefs.SetInt("farmLv", farmLv);
        PlayerPrefs.SetInt("labOn", labOn);
        PlayerPrefs.SetInt("farmOn", farmOn);
        PlayerPrefs.SetInt("curPoint", curPoint);
        PlayerPrefs.SetInt("eventUpPoint", eventUpPoint);
        PlayerPrefs.SetInt("waterUpPoint", waterUpPoint);
        PlayerPrefs.SetInt("waterLv", waterLv);
        PlayerPrefs.SetInt("offlineLv", offlineLv);
        PlayerPrefs.SetInt("offlineMoney", offlineMoney);

        PlayerPrefs.SetString("SaveLastTime", System.DateTime.Now.ToString());

        PlayerPrefs.Save();
    }

    //게임 초기화
    public void GAMERESET()
    {
        PlayerPrefs.SetInt("curMoney", 0);
        PlayerPrefs.SetInt("addMoney", 0);
        PlayerPrefs.SetInt("baseAddMoney", 1);
        PlayerPrefs.SetInt("labAddMoney", 0);
        PlayerPrefs.SetInt("farmAddMoney", 0);
        PlayerPrefs.SetInt("houseAddMoney", 0);
        PlayerPrefs.SetInt("baseAddUpMoney", 1);
        PlayerPrefs.SetInt("labAddUpMoney", 2);
        PlayerPrefs.SetInt("farmAddUpMoney", 3);
        PlayerPrefs.SetInt("houseAddUpMoney", 4);
        PlayerPrefs.SetInt("baseUpMoney", 2);
        PlayerPrefs.SetInt("labUpMoney", 5);
        PlayerPrefs.SetInt("farmUpMoney", 10);
        PlayerPrefs.SetInt("houseUpMoney", 20);
        PlayerPrefs.SetInt("baseUpUpMoney", 2);
        PlayerPrefs.SetInt("labUpUpMoney", 5);
        PlayerPrefs.SetInt("farmUpUpMoney", 10);
        PlayerPrefs.SetInt("houseUpUpMoney", 20);
        PlayerPrefs.SetInt("humanCount", 0);
        PlayerPrefs.SetInt("baseLv", 1);
        PlayerPrefs.SetInt("labLv", 0);
        PlayerPrefs.SetInt("farmLv", 0);
        PlayerPrefs.SetInt("labOn", 0);
        PlayerPrefs.SetInt("houseOn", 0);
        PlayerPrefs.SetInt("farmOn", 0);
        PlayerPrefs.SetInt("curPoint", 0);
        PlayerPrefs.SetInt("eventUpPoint", 5);
        PlayerPrefs.SetInt("waterUpPoint", 1);
        PlayerPrefs.SetInt("waterLv", 0);
        PlayerPrefs.SetInt("offlineLv", 1);
        PlayerPrefs.SetInt("offlineMoney", 1);



        PlayerPrefs.Save();

        Application.Quit();
    }
    public void GameLoad()
    {
        if (PlayerPrefs.GetInt("curMoney") == 0) isFirstPlay = true;

        if (isFirstPlay) return;

        curMoney = PlayerPrefs.GetInt("curMoney");
        addMoney = PlayerPrefs.GetInt("addMoney");
        baseAddMoney = PlayerPrefs.GetInt("baseAddMoney");
        labAddMoney = PlayerPrefs.GetInt("labAddMoney");
        farmAddMoney = PlayerPrefs.GetInt("farmAddMoney");
        houseAddMoney = PlayerPrefs.GetInt("houseAddMoney");
        baseAddUpMoney = PlayerPrefs.GetInt("baseAddUpMoney");
        labAddUpMoney = PlayerPrefs.GetInt("labAddUpMoney");
        farmAddUpMoney = PlayerPrefs.GetInt("farmAddUpMoney");
        houseAddUpMoney = PlayerPrefs.GetInt("houseAddUpMoney");
        baseUpMoney = PlayerPrefs.GetInt("baseUpMoney");
        labUpMoney = PlayerPrefs.GetInt("labUpMoney");
        farmUpMoney = PlayerPrefs.GetInt("farmUpMoney");
        houseUpMoney = PlayerPrefs.GetInt("houseUpMoney");
        baseUpUpMoney = PlayerPrefs.GetInt("baseUpUpMoney");
        labUpUpMoney = PlayerPrefs.GetInt("labUpUpMoney");
        farmUpUpMoney = PlayerPrefs.GetInt("farmUpUpMoney");
        houseUpUpMoney = PlayerPrefs.GetInt("houseUpUpMoney");
        humanCount = PlayerPrefs.GetInt("humanCount");
        baseLv = PlayerPrefs.GetInt("baseLv");
        labLv = PlayerPrefs.GetInt("labLv");
        farmLv = PlayerPrefs.GetInt("farmLv");
        houseLv = PlayerPrefs.GetInt("houseLv");
        labOn = PlayerPrefs.GetInt("labOn");
        farmOn = PlayerPrefs.GetInt("farmOn");
        houseOn = PlayerPrefs.GetInt("houseOn");
        curPoint = PlayerPrefs.GetInt("curPoint");
        eventUpPoint = PlayerPrefs.GetInt("eventUpPoint");
        waterUpPoint = PlayerPrefs.GetInt("waterUpPoint");
        waterLv = PlayerPrefs.GetInt("waterLv");
        offlineLv = PlayerPrefs.GetInt("offlineLv");

        if (labOn != 0) labObj.SetActive(true);
        if (farmOn != 0) farmObj.SetActive(true);
        if (houseOn != 0) houseObj.SetActive(true);

        if(humanCount>0)
        {
            for(int i=0;i<humanCount;i++)
            {
                human.Spawn(new Vector3(Random.Range(-3, 3), 1, Random.Range(-3, 3)), Quaternion.Euler(0, 0, 0));
            }
        }

        curMoneyText.text = curMoney.ToString();
        waterLvText.text = waterLv.ToString();
        waterUpPointText.text = waterUpPoint.ToString();
        curPointText.text = curPoint.ToString();
        farmLvText.text = farmLv.ToString();
        labLvText.text = labLv.ToString();
        baseLvText.text = baseLv.ToString();
        baseUpMoneyText.text = baseUpMoney.ToString();
        labUpMoneyText.text = labUpMoney.ToString();
        farmUpMoneyText.text = farmUpMoney.ToString();
        baseAddMoneyText.text = baseAddMoney.ToString();
        labAddMoneyText.text = labAddMoney.ToString();
        farmAddMoneyText.text = farmAddMoney.ToString();

        string lastTime = PlayerPrefs.GetString("SaveLastTime");
        System.DateTime lastDateTime = System.DateTime.Parse(lastTime);
        System.TimeSpan offlineTime = System.DateTime.Now - lastDateTime;

        offlineMoney = ((int)offlineTime.TotalSeconds * offlineLv);
        if(!isFirstPlay)
        {
            offlineReward.gameObject.SetActive(true);
            offlineMoneyText.text = offlineMoney.ToString();
        }
    }
    public void TextSet()
    {
        curMoneyText.text = curMoney.ToString();
        addMoneyText.text = addMoney.ToString();
        baseAddMoneyText.text = baseAddMoney.ToString();
        labAddMoneyText.text = labAddMoney.ToString();
        farmAddMoneyText.text = farmAddMoney.ToString();
        houseAddMoneyText.text = houseAddMoney.ToString();
        waterUpPointText.text = waterUpPoint.ToString();
        baseLvText.text = baseLv.ToString();
        labLvText.text = labLv.ToString();
        farmLvText.text = farmLv.ToString();
        houseLvText.text = houseLv.ToString();
        waterLvText.text = waterLv.ToString();
        curPointText.text = curPoint.ToString();
    }
}
