using System;
using UnityEngine;

[Serializable]
public class UserData
{
    public string UserName;
    public int Balance;
    public int Cash;

    public event Action Changed; //외부 클래스나 스크립트에서도 접근하고 구독


    public UserData() 
    {
        // public UserData userData = new UserData 용
        // 빈 껍데기가 있어야 게임매니저에서 에러없음
    }
    public UserData(string _userName, int _balance, int _cash) 
    { 
        UserName = _userName;
        Balance = _balance;
        Cash = _cash;
    }

    public void Inputname(string inputname)
    {
        UserName = inputname;
        Changed?.Invoke();
    }
    public void AddBalance(int addbalance)
    {
        if (addbalance <= 0)
        {
            return;
        }

        if (Cash < addbalance)
        {
            return;
        }

        Balance += addbalance;
        Cash -= addbalance;
        Changed?.Invoke();
    }

    public void AddCash(int addcash)
    {

        if (addcash <= 0)
        {
            return;
        }

        if (Balance < addcash)
        {
            return;
        }
        Cash += addcash;
        Balance -= addcash;

        Changed?.Invoke();

    }


}
