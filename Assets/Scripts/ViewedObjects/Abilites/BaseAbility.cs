using UnityEngine;

public abstract class BaseAbility : MonoBehaviour
{
    private bool _isActive;
    public bool IsActive { get { return _isActive; } }

    protected bool _isBusy = false;
    public bool IsBusy { get { return _isBusy; } }

    public abstract string GetAbilityName();
    public virtual void ActivateAbility() { _isActive = true; }
    public virtual void DeactivateAbility() { _isActive = false; }
}