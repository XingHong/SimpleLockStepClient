using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    public Button singleBattleBtn;
    // Start is called before the first frame update
    void Start()
    {
        singleBattleBtn.onClick.AddListener(OnSingleBattle);
    }

    private void OnSingleBattle()
    {
        UnityTools.Log("OnStartBattle!");
    }
}
