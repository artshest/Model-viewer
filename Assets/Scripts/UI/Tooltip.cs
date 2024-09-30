using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour, IService
{
    [SerializeField]
    private TextMeshProUGUI _title;

    [SerializeField]
    private TextMeshProUGUI _description;

    private GameObject _tooltipObject;
    private RectTransform _canvasTransform;
    private RectTransform _transform;

    private void Awake()
    {
        _canvasTransform = transform.parent.GetComponent<RectTransform>();
        _tooltipObject = transform.GetChild(0).gameObject;
        HideTooltip();
        _transform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasTransform, Input.mousePosition, Camera.main, out localPoint);

        transform.localPosition = localPoint;
    }

    public void ShowTooltip(string title, string description)
    {
        _tooltipObject.SetActive(true);

        _title.text = title;
        _description.text = description;
    }

    public void HideTooltip()
    {
        _tooltipObject.SetActive(false);
    } 
}
