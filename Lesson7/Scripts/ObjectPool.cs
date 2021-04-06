using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class ObjectPool
    {
        protected readonly Stack<GameObject> _stack = new Stack<GameObject>();
        protected GameObject _prefab;

        public ObjectPool(GameObject prefab)
        {
            _prefab = prefab;
        }

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.SetActive(false);
        }

        protected GameObject PopObject()
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
    }
}
