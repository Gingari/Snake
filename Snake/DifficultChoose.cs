using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultChoose : MonoBehaviour
{
    public Button easyButton;
    public Button hardButton;
    public Button mediumButton;
    public Button imposibleButton;

    // Цвета для каждого уровня сложности
    public Color easyColor;
    public Color hardColor;
    public Color mediumColor;
    public Color impossibleColor;

    void Start()
    {
        // Привязка методов к кнопкам
        easyButton.onClick.AddListener(SetEasy);
        hardButton.onClick.AddListener(SetHard);
        mediumButton.onClick.AddListener(SetMedium);
        imposibleButton.onClick.AddListener(SetImp);
    }

    void OnEnable()
    {
        // Привязка методов к кнопкам при активации объекта
        easyButton.onClick.AddListener(SetEasy);
        hardButton.onClick.AddListener(SetHard);
        mediumButton.onClick.AddListener(SetMedium);
        imposibleButton.onClick.AddListener(SetImp);
    }

    void OnDisable()
    {
        // Отписка методов от кнопок при деактивации объекта
        easyButton.onClick.RemoveListener(SetEasy);
        hardButton.onClick.RemoveListener(SetHard);
        mediumButton.onClick.RemoveListener(SetMedium);
        imposibleButton.onClick.RemoveListener(SetImp);
    }

    void SetEasy()
    {
        GameManager.instance.diff = 0;
        SetButtonVisibility(easyButton, false);
        SetButtonVisibility(mediumButton, true);
        SetButtonVisibility(hardButton, true);
        SetButtonVisibility(imposibleButton, true);
    }

    void SetHard()
    {
        GameManager.instance.diff = 2;
        SetButtonVisibility(easyButton, true);
        SetButtonVisibility(mediumButton, true);
        SetButtonVisibility(hardButton, false);
        SetButtonVisibility(imposibleButton, true);
    }

    void SetMedium()
    {
        GameManager.instance.diff = 1;
        SetButtonVisibility(easyButton, true);
        SetButtonVisibility(mediumButton, false);
        SetButtonVisibility(hardButton, true);
        SetButtonVisibility(imposibleButton, true);
    }

    void SetImp()
    {
        GameManager.instance.diff = 3;
        SetButtonVisibility(easyButton, true);
        SetButtonVisibility(mediumButton, true);
        SetButtonVisibility(hardButton, true);
        SetButtonVisibility(imposibleButton, false);
    }

    void SetButtonVisibility(Button button, bool isVisible)
    {
        CanvasGroup canvasGroup = button.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = button.gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = isVisible ? 1 : 0;
        canvasGroup.interactable = isVisible;
        canvasGroup.blocksRaycasts = isVisible;

        Text buttonText = button.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.enabled = isVisible;
        }
    }
}
