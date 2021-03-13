using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class ObjectPool
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;

        public ObjectPool(GameObject prefab)
        {
            _prefab = prefab;
        }

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.SetActive(false);
        }

        private GameObject PopObject()
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = Object.Instantiate(_prefab);
            }
            else
            {
                go = _stack.Pop();
            }
            return go;
        }
        public GameObject Pop()
        {
            GameObject go = PopObject();
            
            go.SetActive(true);

            return go;
        }

        public GameObject Pop((Vector3 position, Quaternion rotation) _transform)
        {
            GameObject go = PopObject();

            go.transform.position = _transform.position;
            go.transform.rotation = _transform.rotation;

            go.SetActive(true);

            return go;
        }
    }
}
