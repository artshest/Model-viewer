using TMPro;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _buttonText;
    private BaseAbility _ability;

    private void Awake()
    {
        _buttonText = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void SetAbility(BaseAbility ability)
    {
        _ability = ability;
        _buttonText.text = _ability.GetAbilityName();
    }

    public void OnClick()
    {
        if (_ability.IsBusy)
        {
            return;
        }

        if (_ability.IsActive)
        {
            _ability.DeactivateAbility();
        }
        else
        {
            _ability.ActivateAbility();
        }
    }
}
