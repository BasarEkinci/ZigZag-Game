using System;
using TMPro;
using UnityEngine;
using DG.Tweening;
using Button = UnityEngine.UI.Button;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Transform startText;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private GameObject textsPanel;

    public static bool isSoundsOpen = true;

    private bool isSettingsOpen;


    private void Start()
    {
        startText.DOScale(new Vector3(0.9f, 0.9f, 1), 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.OutSine);
    }

    private void Update()
    {
        TextAnimations();
        scoreText.text = GameManager.score.ToString();
        highScoreText.text = GameManager.highScore.ToString();

        


    }
    private void TextAnimations()
    {
        if (GameManager.isGameStarted)
            textsPanel.transform.DOMoveY(-80,0.5f);

        if (!GameManager.isBallActive)
            restartPanel.transform.DOScale(new Vector3(0.4f, 0.7f, 1), 0.5f);
        else
            restartPanel.transform.DOScale(new Vector3(0,0,0), 0f);

    }
}
