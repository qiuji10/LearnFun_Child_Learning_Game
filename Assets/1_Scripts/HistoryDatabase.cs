using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class HistoryDatabase : MonoBehaviour
{
    public bool needText;

    [EnableIf("needText")][SerializeField] TMP_Text SuccessCountText;
    [EnableIf("needText")][SerializeField] TMP_Text FailCountText;

    int successCount;
    int failCount;
    int totalCount;

    private void Start()
    {
        if (needText)
            ShowPlayerResult();
    }

    public void SavePlayerResult(bool isCorrect)
    {
        GetPlayerResult();
        if (isCorrect)
        {
            successCount += 1;
            PlayerPrefs.SetInt("Success", successCount);
        }
        else
        {
            failCount += 1;
            PlayerPrefs.SetInt("Fail", failCount);
        }
    }

    public void GetPlayerResult()
    {
        successCount = PlayerPrefs.GetInt("Success");
        failCount = PlayerPrefs.GetInt("Fail");
        totalCount = successCount + failCount;
    }

    public void ShowPlayerResult()
    {
        GetPlayerResult();
        SuccessCountText.text = $"{successCount} / {totalCount}";
        FailCountText.text = $"{failCount} / {totalCount}";
    }

    [Button]
    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.SetInt("Success", 0);
        PlayerPrefs.SetInt("Fail", 0);
    }
}
