using UnityEngine;
using UnityEngine.Pool;

public class AbilityButtonsPool 
{
    private ObjectPool<AbilityButton> _pool;
    private AbilityButton _prefab;
    private Transform _parentTransform;

    public AbilityButtonsPool(AbilityButton prefab, Transform parentTransform)
    {
        _prefab = prefab;
        _parentTransform = parentTransform;
        _pool = new ObjectPool<AbilityButton>(OnCreate, OnGet, OnRelease, OnDestroy, false);
    }

    public AbilityButton Get()
    {
        var abilityButton = _pool.Get();
        return abilityButton;
    }

    private AbilityButton OnCreate()
    {
        return GameObject.Instantiate(_prefab, _parentTransform);
    }

    private void OnGet(AbilityButton abilityButton)
    {
        abilityButton.gameObject.SetActive(true);
    }

    public void Release(AbilityButton abilityButton)
    {
        _pool.Release(abilityButton);
    }

    private void OnDestroy(AbilityButton abilityButton)
    {
        Object.Destroy(abilityButton);
    }

    private void OnRelease(AbilityButton abilityButton)
    {
        abilityButton.gameObject.SetActive(false);
    }




}
