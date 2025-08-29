using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject BalanceGroup;
    public GameObject DepositMenu;
    public GameObject WithdrawalMenu;
    public GameObject WarningMenu;

    public InputField depositInputField;
    public InputField withdrawalInputField;


    void Start()
    {
        ResetUI();
    }

    public void OnClickStart()
    {
        ResetUI();
    }

    private void ResetUI()
    {
        BalanceGroup.SetActive(true);
        DepositMenu.SetActive(false);
        WithdrawalMenu.SetActive(false);
        WarningMenu.SetActive(false);
    }

    public void OnDepositButton()
    {
        BalanceGroup.SetActive(false);
        DepositMenu.SetActive(true);
        WithdrawalMenu.SetActive(false);

    }

    public void OnWithdrawalButton()
    {
        BalanceGroup.SetActive(false);
        DepositMenu.SetActive(false);
        WithdrawalMenu.SetActive(true);
    }

    
    public void OnDepositClick(int money)
    {
        Debug.Log("버튼을 눌러서 돈이 들어감: " + money);

        GameManager.Instance.userData.AddBalance(money);


    }

    public void OnWithdrawalClick(int money)
    {
        Debug.Log("버튼을 눌러서 돈이 나감: " + money);

        GameManager.Instance.userData.AddCash(money);
    }

    public void DepositFromInput()
    {
        string raw = depositInputField.text;

        if (int.TryParse(raw, out int money) && money > 0)
        {
            GameManager.Instance.userData.AddBalance(money);
        }
        else
        {
            WarningMenu.SetActive(true);
        }
    }

    public void WithdrawalFromInput()
    {
       string raw = withdrawalInputField.text;

        if (int.TryParse(raw, out int money) && money > 0)

        {
            GameManager.Instance.userData.AddCash(money);
        }

        else 
        
        {
            WarningMenu.SetActive(true);
        }
    }

    public void WarningPopup()
    { 
        WarningMenu.SetActive(false);
       
    }



}
