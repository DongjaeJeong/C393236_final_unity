using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameTime;
    public float maxGameTime = 2 * 10f;

    public PlayerMove player;
    public PoolManager pool;
    public TMP_Text text;
    int score = 0;
    private void Start()
    {
        Instance = this;
        SetText();
    }

    void Update()
    {
        if (gameTime >= maxGameTime) return;
        gameTime += Time.deltaTime;
        score += 1;
        SetText();
    }

    public void SetText()
    {
        int printscore = score / 60;
        text.text = "Score : " + printscore.ToString();
    }
}
