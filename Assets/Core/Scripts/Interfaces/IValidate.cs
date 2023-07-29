using UnityEngine;

namespace Core.Interfaces
{
    public interface IValidateTroughTransform
    {
        public void Validate(Transform transform);
    }

    public interface IValidate
    {
        public void Validate();
    }
}
