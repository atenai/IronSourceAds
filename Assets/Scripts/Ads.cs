using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ads : MonoBehaviour
{
    public TextMeshProUGUI RewardStatusText;
    public TextMeshProUGUI InterstitialStatusText;

    private void Awake()
    {
        //IronSource���g���ׂ̏����������i�������ɁAAPP KEY:�̌�ɏ����Ă��鐔���𕶎���ɂ��ē����j
        IronSource.Agent.init("16a036d7d", IronSourceAdUnits.REWARDED_VIDEO, IronSourceAdUnits.INTERSTITIAL, IronSourceAdUnits.OFFERWALL, IronSourceAdUnits.BANNER);
    }

    void Start()
    {
        IsRewardReady();
        IsInterstitialReady();
        LoadInterstitial();

        //�o�i�[�L���̕\��
        IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
    }

    void Update()
    {
        IsRewardReady();
        IsInterstitialReady();

        IronSourceBannerSize.BANNER.SetAdaptive(true);
        IronSource.Agent.displayBanner();
    }

    //�C���^�[�X�e�[�V���i���L���̃��[�h
    public void LoadInterstitial()
    {
        IronSource.Agent.loadInterstitial();
    }

    //�C���^�[�X�e�[�V���i���L���̏������ł������H�ǂ���
    void IsInterstitialReady()
    {
        InterstitialStatusText.text = IronSource.Agent.isInterstitialReady().ToString();
    }

    //�C���^�[�X�e�[�V���i���L���̕\��
    public void ShowInterstitial()
    {
        IronSource.Agent.showInterstitial();
    }

    //�����[�h�L���̏������ł������H�ǂ���
    void IsRewardReady()
    {
        RewardStatusText.text = IronSource.Agent.isRewardedVideoAvailable().ToString();
    }

    //�����[�h�L����\��
    public void ShowReward()
    {
        IronSource.Agent.showRewardedVideo();
    }
}
