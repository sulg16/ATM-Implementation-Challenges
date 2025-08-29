using System;
using UnityEngine;

[Serializable]
public class UserData
{
    public string UserName;
    public int Balance;
    public int Cash;

    public event Action Changed; //�ܺ� Ŭ������ ��ũ��Ʈ������ �����ϰ� ����


    public UserData() 
    {
        // public UserData userData = new UserData ��
        // �� �����Ⱑ �־�� ���ӸŴ������� ��������
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
