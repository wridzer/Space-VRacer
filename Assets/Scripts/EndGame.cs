using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

    public enum FinalScoreTypes
    {
        PERFECT = 0,
        AMAZING = 1,
        GOOD = 2,
        KINDAGOOD = 3,
        NEUTRAL = 4,
        KINDABAD = 5,
        BAD = 6,
        TERRIBLE = 7,
        WORST = 8,
    }


public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject phoneNormal, phoneListner, UILineR, UILineL;
    [SerializeField] private int maxScore = 24;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Transform headlineHolder;
    [SerializeField] private GameObject credits;
    [SerializeField] private AudioClip endingPerfect, endingAmazing, endingGood, endingKindaGood, endingNeutral, endingKindaBad, endingBad, endingTerrible, endingWorst;
    private AudioSource audioSource;
    private FinalScoreTypes myScore;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ShowHeadlines(Dictionary<CallObject, ScoreTypes> callList, int score)
    {
        phoneNormal.GetComponent<PhoneManager>().enabled = false;
        phoneListner.GetComponent<ListnerPhone>().enabled = false;
        phoneListner.GetComponent<PhoneManager>().enabled = false;
        UILineL.SetActive(true);
        UILineR.SetActive(true);

        scoreText.text = score + "/" + maxScore;
        foreach(KeyValuePair<CallObject, ScoreTypes> call in callList)
        {
            if(call.Value == ScoreTypes.WRONG)
            {
                Instantiate(call.Key.headlinePrefab, headlineHolder);
            }
        }

        if (score == 24) myScore = FinalScoreTypes.PERFECT;
        if (score >= 18 && score <= 24) myScore = FinalScoreTypes.AMAZING;
        if (score >= 9 && score <= 18) myScore = FinalScoreTypes.GOOD;
        if (score > 0 && score <= 9) myScore = FinalScoreTypes.KINDAGOOD;
        if (score == 0) myScore = FinalScoreTypes.NEUTRAL;
        if (score >= -9 && score <= 0) myScore = FinalScoreTypes.KINDABAD;
        if (score >= -18 && score <= -9) myScore = FinalScoreTypes.BAD;
        if (score >= -24 && score <= -18) myScore = FinalScoreTypes.TERRIBLE;
        if (score == -24) myScore = FinalScoreTypes.WORST;


        switch (myScore)
        {
            case FinalScoreTypes.PERFECT:
                audioSource.PlayOneShot(endingPerfect);
                break;
            case FinalScoreTypes.AMAZING:
                audioSource.PlayOneShot(endingAmazing);
                break;
            case FinalScoreTypes.GOOD:
                audioSource.PlayOneShot(endingGood);
                break;
            case FinalScoreTypes.KINDAGOOD:
                audioSource.PlayOneShot(endingKindaGood);
                break;
            case FinalScoreTypes.NEUTRAL:
                audioSource.PlayOneShot(endingNeutral);
                break;
            case FinalScoreTypes.KINDABAD:
                audioSource.PlayOneShot(endingKindaBad);
                break;
            case FinalScoreTypes.BAD:
                audioSource.PlayOneShot(endingBad);
                break;
            case FinalScoreTypes.TERRIBLE:
                audioSource.PlayOneShot(endingTerrible);
                break;
            case FinalScoreTypes.WORST:
                audioSource.PlayOneShot(endingWorst);
                break;
        }
    }

    public void ToCredits()
    {
        credits.SetActive(true);
        gameObject.SetActive(false);
    }
}