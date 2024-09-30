using System.Collections.Generic;

public class RootViewedObject : ViewedObject
{
    private List<BaseAbility> _abilities;

    public List<BaseAbility> Abilities { get { return _abilities; } }

    private void Awake()
    {
        _abilities = new List<BaseAbility>(GetComponents<BaseAbility>());
    }

    private void OnEnable()
    {
        ServiceLocator.Instance.Get<RootViewedObjectDescription>().SetObjectDesctiption(Name, Description);
    }
}
