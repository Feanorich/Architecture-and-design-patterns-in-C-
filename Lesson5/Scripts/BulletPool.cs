using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal class BulletPool : ObjectPool
    {
        public BulletPool(GameObject prefab) : base(prefab) 
        { 
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
