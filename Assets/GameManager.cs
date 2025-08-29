
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    const string KEY_USER_NAME = "USER_NAME";
    const string KEY_BALANCE = "USER_BALANCE";
    const string KEY_CASH = "USER_CASH";


    public static GameManager Instance;

    [SerializeField]

    public UserData userData = new UserData
    {
        UserName = "이름",
        Balance = 100000,
        Cash = 50000
    };

    public Text nameText;
    public Text balanceText;
    public Text cashText;

    


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            LoadUserData();
            HookUserDataEvents(true);
            RefreshUI();
        }

        else
        {
            Destroy(gameObject);
            return;
        }
    }


    // 이벤트 구독 시작(HookUserDataEvents)
    void OnEnable() //컴포넌트 활성화 될 때
    {
        if (!Application.isPlaying) //플레이모드가 아닐때(에디터모드)
            RefreshUI();
    }


    // 이벤트 구족 해제 (HookUserDataEvents)
    void OnDisable() // 컴포넌트가 비활성화 될 때
    {
        if (Application.isPlaying)  // 플레이모드일 때
            HookUserDataEvents(false); // HookUserDataEvents 종료
    }


    private void HookUserDataEvents(bool add) // bool add 참/거짓 추가
    {
        if (userData == null)
        {
            return; // null일때 리턴(동작X)
        }


        if (add)
        {
            userData.Changed += RefreshUI;  // 이벤트에 RefreshUI 시작 (+=)
            userData.Changed += SaveUserData;
        }

        else
        {
            userData.Changed -= RefreshUI;
            userData.Changed -= SaveUserData;// 이벤트에 RefreshUI 종료 (-=)
        }
    }
    public void RefreshUI()
    {
        if (userData == null)
        {
            return;  // 데이터가 없으면 리턴
        }

        if (nameText)
        {
            nameText.text = userData.UserName;
        }

        if (balanceText)
        {
            balanceText.text = userData.Balance.ToString("N0");
        }

        if (cashText)
        {
            cashText.text = userData.Cash.ToString("N0");
        }
    }

    public void SaveUserData()
    {
        Debug.Log("데이터 세이브중");

        PlayerPrefs.SetString(KEY_USER_NAME, userData.UserName);

        PlayerPrefs.SetInt(KEY_BALANCE, userData.Balance);

        PlayerPrefs.SetInt(KEY_CASH, userData.Cash);
 
    }

    public void LoadUserData()
    {
        Debug.Log("데이터 로드중");

        userData.UserName = PlayerPrefs.GetString(KEY_USER_NAME, userData.UserName);

        userData.Balance = PlayerPrefs.GetInt(KEY_BALANCE, userData.Balance);

        userData.Cash = PlayerPrefs.GetInt(KEY_CASH, userData.Cash);
       
    }
}


