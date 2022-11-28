
using System;

public interface IPlayerGetData
{
    event Action<int> eventChangeCoints;
    event Action<int> eventChangePoints;
    event Action<int> eventChangeAbility;

    int GetCoins();
    int GetPoints();
    int GetAbility();
}
