using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceAbility : BaseAbility
{
    [SerializeField]
    private List<GameObject> _slisedObjects;

    public override string GetAbilityName()
    {
        return "Разрез";
    }

    public override void ActivateAbility()
    {
       base.ActivateAbility();

       foreach (GameObject obj in _slisedObjects) 
       {
            obj.SetActive(false);
       }
    }

    public override void DeactivateAbility()
    {
        base.DeactivateAbility();

        foreach (GameObject obj in _slisedObjects)
        {
            obj.SetActive(true);
        }
    }
}
