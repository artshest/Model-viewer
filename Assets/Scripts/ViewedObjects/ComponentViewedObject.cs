using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ComponentViewedObject : ViewedObject
{
    private Tooltip _tooltip;

    private void Start()
    {
        _tooltip = ServiceLocator.Instance.Get<Tooltip>();
    }

    private void OnMouseEnter()
    {
        _tooltip.ShowTooltip(Name, Description);
    }

    private void OnMouseExit()
    {
        _tooltip.HideTooltip();
    }
}
