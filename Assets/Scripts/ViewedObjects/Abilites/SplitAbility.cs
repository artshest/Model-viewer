using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitAbility : BaseAbility
{
    [SerializeField]
    private float _splitDistance = 3;

    [SerializeField]
    private float _splitSpeed = 3;

    private Dictionary<GameObject, Vector3> _initialPositions;

    private void Start()
    {
        InitializeChildrenPositions();
    }

    public override string GetAbilityName()
    {
        return "Декомпозиция";
    }

    private void InitializeChildrenPositions()
    {
        _initialPositions = new Dictionary<GameObject, Vector3>();

        for (int i = 0; i < transform.childCount; ++i)
        {
            var curentChild = transform.GetChild(i);
            _initialPositions.Add(curentChild.gameObject, curentChild.localPosition);
        }
    }

    public override void ActivateAbility()
    {
        base.ActivateAbility();
        _isBusy = true;

        StartCoroutine(SplitChildObjects());
    }
    public override void DeactivateAbility()
    {
        base.DeactivateAbility();
        _isBusy = true;

        StartCoroutine(MergeChildObjects());
    }

    private IEnumerator SplitChildObjects()
    {
        float curentDistance = 0;   
        while (true)
        {
            foreach (var item in _initialPositions)
            {
                item.Key.transform.localPosition += item.Value.normalized * Time.deltaTime * _splitSpeed;
            }

            curentDistance += Time.deltaTime * _splitSpeed;

            if(curentDistance >= _splitDistance)
            {
                _isBusy = false;
                break;
            }

            yield return null;
        }
    }

    private IEnumerator MergeChildObjects()
    {
        float curentDistance = 0;
        while (true)
        {
            foreach (var item in _initialPositions)
            {
                item.Key.transform.localPosition -= item.Value.normalized * Time.deltaTime * _splitSpeed;
            }

            curentDistance += Time.deltaTime * _splitSpeed;

            if (curentDistance >= _splitDistance)
            {
                foreach (var item in _initialPositions)
                {
                    item.Key.transform.localPosition = item.Value;
                }
                _isBusy = false;
                break;
            }

            yield return null;
        }
    }
}
