using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    public Button startButton;
    public Button playButton;
    public Button enforceButton;
    public Button charButton;
    public Button storeButton;
    public Scrollbar scrollbar;
    public Image player;
    void Start() // �ʱⰪ ����
    {
        playButton.Select();
        scrollbar.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
    }
    public void Character() // �ϴ� ��ư Ŭ�� �� ������ ȭ�� ���
    {
        startButton.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        scrollbar.gameObject.SetActive(true);
    }
    public void Enforce()
    {
        startButton.gameObject.SetActive(false);
        scrollbar.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
    }
    public void Play()
    {
        startButton.gameObject.SetActive(true);
        scrollbar.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
    }
    public void Store()
    {
        startButton.gameObject.SetActive(false);
        scrollbar.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
    }
    public void EStart()
    {
        playButton.Select();
    }
    public void EScrollbar()
    {
        charButton.Select();
    }
}
