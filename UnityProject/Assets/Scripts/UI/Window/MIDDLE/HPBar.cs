using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[WindowAttribute("MIDDLE/HPBar.prefab")]
public class HPBar : UIWindow
{
    [SerializeField] private Image hpBar;

    public override void OnInit()
    {
        base.OnInit();

        hpBar.fillAmount = 0.8f;
    }

    public override void OnOpen()
    {
        base.OnOpen();

        hpBar.fillAmount = 0.5f;
    }

    public override void OnClose()
    {
        base.OnClose();
    }

    public void OnClickHPBar()
    {
        hpBar.fillAmount -= 0.2f;
    }
}
