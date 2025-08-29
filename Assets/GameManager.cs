
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
        UserName = "�̸�",
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


    // �̺�Ʈ ���� ����(HookUserDataEvents)
    void OnEnable() //������Ʈ Ȱ��ȭ �� ��
    {
        if (!Application.isPlaying) //�÷��̸�尡 �ƴҶ�(�����͸��)
            RefreshUI();
    }


    // �̺�Ʈ ���� ���� (HookUserDataEvents)
    void OnDisable() // ������Ʈ�� ��Ȱ��ȭ �� ��
    {
        if (Application.isPlaying)  // �÷��̸���� ��
            HookUserDataEvents(false); // HookUserDataEvents ����
    }


    private void HookUserDataEvents(bool add) // bool add ��/���� �߰�
    {
        if (userData == null)
        {
            return; // null�϶� ����(����X)
        }


        if (add)
        {
            userData.Changed += RefreshUI;  // �̺�Ʈ�� RefreshUI ���� (+=)
            userData.Changed += SaveUserData;
        }

        else
        {
            userData.Changed -= RefreshUI;
            userData.Changed -= SaveUserData;// �̺�Ʈ�� RefreshUI ���� (-=)
        }
    }
    public void RefreshUI()
    {
        if (userData == null)
        {
            return;  // �����Ͱ� ������ ����
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
        Debug.Log("������ ���̺���");

        PlayerPrefs.SetString(KEY_USER_NAME, userData.UserName);

        PlayerPrefs.SetInt(KEY_BALANCE, userData.Balance);

        PlayerPrefs.SetInt(KEY_CASH, userData.Cash);
 
    }

    public void LoadUserData()
    {
        Debug.Log("������ �ε���");

        userData.UserName = PlayerPrefs.GetString(KEY_USER_NAME, userData.UserName);

        userData.Balance = PlayerPrefs.GetInt(KEY_BALANCE, userData.Balance);

        userData.Cash = PlayerPrefs.GetInt(KEY_CASH, userData.Cash);
       
    }
}


