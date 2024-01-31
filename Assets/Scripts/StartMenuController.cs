using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AnimationRequest
{
    public Animator animator;
    public string animationName;
    public bool disable;
}

public class StartMenuController : MonoBehaviour
{
    public static StartMenuController Instance { get; private set; }
    public MenuState menuState = MenuState.Idle;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject settings;
    private Animator animator;

    [SerializeField] Animator[] otherAnimators;
    enum Menu { Main,Settings, Credits}

    [SerializeField] Animator[] buttonAnimators;

    private Animator nextRequest;

    private void Start()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;

        animator = GetComponent<Animator>();

        InitiateStartMenu();
    }

    public void ShowMenu(int menu)
    {
        if (menuState == MenuState.Transitioning) return;

        MenuNames picked = (MenuNames)menu;
        switch (picked)
        {
            case MenuNames.StartGame:
                StartGame();
                break;
            case MenuNames.Settings:
                ShowSettings();
                break;
            case MenuNames.Credits:
                ShowCredits();
                break;
            case MenuNames.CloseMenuOption:
                ShowCredits();
                break;
            case MenuNames.Exit:
                ExitGame();
                break;
        }
    }

    private void InitiateStartMenu()
    {
        animator.CrossFade("InitiateStartMenu",0.1f);
    }

    private IEnumerator AnimateAllButtons()
    {
        while (animatorQueue.Count > 0)
        {
            AnimateNextButton();
            yield return new WaitForSeconds(0.1f); 
        }
    }

    public void MenuAnimationComplete()
    {
        Debug.Log("MenuAnimation complete");
        nextRequest.CrossFade("Show", 0.1f);
    }

    public void ButtonAnimationComplete()
    {
        Debug.Log("Button Animation complete");
    }
    private Queue<Animator> animatorQueue = new Queue<Animator>();
    private void AnimateNextButton()
    {
        Debug.Log("Animating next button: "+animatorQueue.Count);
        if(animatorQueue.Count>0)
            animatorQueue.Dequeue().CrossFade("SpawnButton",0.1f);
        else
            menuState = MenuState.Idle;
    }

    private void StartGame()
    {
        Debug.Log("Start Game Pressed");
        animator.CrossFade("StartGame",0.1f);
    }

    private void ShowSettings()
    {
        Debug.Log("Settings Pressed");
        menuState = MenuState.Transitioning;
        otherAnimators[(int)Menu.Main].CrossFade("Hide",0.1f);
        settings.SetActive(true);
        nextRequest = otherAnimators[(int)Menu.Settings];
    }

    private void ShowCredits()
    {
        Debug.Log("Credits Pressed");
        menuState = MenuState.Transitioning;
        animator.CrossFade("ShowCredits",0.1f);
    }

    private void ExitGame()
    {
                Debug.Log("Exit Pressed");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
public enum MenuNames {StartGame,Settings,Credits,Exit,
    CloseMenuOption
}
public enum MenuState {Idle,Transitioning}
