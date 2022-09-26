﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldController : BaseController {
    public RectTransform mainUI, scrollContent;
    public HorizontalLayoutGroup contentLayoutGroup;
    public SnapScrollRect snapScroll;
    public ScrollRect scrollRect;

    protected override void Start()
    {
        base.Start();
        UpdateUI();
        //snapScroll.SetPage(Prefs.unlockedWorld);
        //scrollRect.enabled = true;
    }

    private void Update()
    {
        //UpdateUI();
    }

    private void UpdateUI()
    {
        scrollContent.sizeDelta = new Vector2(mainUI.rect.width * scrollContent.childCount, scrollContent.sizeDelta.y);
        contentLayoutGroup.spacing = mainUI.rect.width;
    }
}
