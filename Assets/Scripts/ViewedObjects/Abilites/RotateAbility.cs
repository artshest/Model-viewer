using UnityEngine;

public class RotateAbility : BaseAbility
{
    [SerializeField]
    private float _speed = 3;

    private Quaternion _initialRotation;

    public override string GetAbilityName()
    {
        return "Вращение";
    }

    private void Start()
    {
        _initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (IsActive)
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * _speed);
        }
        
    }

    public override void DeactivateAbility()
    {
        base.DeactivateAbility();

        transform.rotation = _initialRotation;
    }
}
