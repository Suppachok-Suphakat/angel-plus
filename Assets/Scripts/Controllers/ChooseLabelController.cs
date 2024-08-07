using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using static ChooseScene;

public class ChooseLabelController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color defaultColor;
    public Color hoverColor;
    private StoryScene scene;
    private TextMeshProUGUI textMesh;
    private ChooseController controller;

    private ChooseScene.ChooseLabel chooseLabel;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.color = defaultColor;
    }

    public float GetHeight()
    {
        return textMesh.rectTransform.sizeDelta.y * textMesh.rectTransform.localScale.y;
    }

    public void Setup(ChooseScene.ChooseLabel label, ChooseController controller, float y)
    {
        scene = label.nextScene;
        textMesh.text = label.text;
        this.controller = controller;

        chooseLabel = label;

        Vector3 position = textMesh.rectTransform.localPosition;
        position.y = y;
        textMesh.rectTransform.localPosition = position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (chooseLabel.heartChange > 0)
        {
            Heart.Instance.IncreaseHeart();
        }
        else if (chooseLabel.heartChange < 0)
        {
            Heart.Instance.DecreaseHeart();
        }

        if (chooseLabel.choiceSound != null)
        {
            controller.PlayAudio(chooseLabel.choiceSound);
        }

        controller.PerformChoose(scene);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textMesh.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMesh.color = defaultColor;
    }
}
