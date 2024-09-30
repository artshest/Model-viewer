using System.Collections.Generic;
using UnityEngine;

public class AbilityButtonsController : MonoBehaviour, IService
{
    [SerializeField]
    private AbilityButton _abilityButtonPrefab;

    private List<AbilityButton> _currentAbilityButtons = new List<AbilityButton>();

    private AbilityButtonsPool _abilityButtonsPool;

    private void Awake()
    {
        _abilityButtonsPool = new AbilityButtonsPool(_abilityButtonPrefab, transform);
    }


    public void SetAbilities(List<BaseAbility> abilities)
    {
        foreach(AbilityButton abilityButton in _currentAbilityButtons)
        {
            _abilityButtonsPool.Release(abilityButton);
        }
        _currentAbilityButtons.Clear();

        foreach (BaseAbility ability in abilities)
        {
            AbilityButton abilityButton = _abilityButtonsPool.Get();

            _currentAbilityButtons.Add(abilityButton);

            abilityButton.SetAbility(ability);
        }
    }
}
