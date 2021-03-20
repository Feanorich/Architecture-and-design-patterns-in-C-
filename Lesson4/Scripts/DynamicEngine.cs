using UnityEngine;

namespace Asteroids
{
    class DynamicEngine : IEngine
    {
        public void MoveObject(Transform transform, float horizontal, float vertical,
            float speed, float deltaTime)
        {
            Rigidbody2D _rigidbody = transform.gameObject.GetOrAddComponent<Rigidbody2D>();

            _rigidbody.AddForce(Vector3.up * vertical * _rigidbody.mass);
            _rigidbody.AddForce(Vector3.right * horizontal * _rigidbody.mass);
        }
    }
}
