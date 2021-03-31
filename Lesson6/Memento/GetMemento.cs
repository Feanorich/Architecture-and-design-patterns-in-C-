using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Memento
{
    public class GetMemento : IGetMementos
    {
        private List<IMemento> _mementos;
        private float _recordTime;
        public GetMemento(float recordTime = 5f)
        {
            _mementos = new List<IMemento>();

            var mementoObject = GameObject.FindGameObjectsWithTag("Memento");
            if (mementoObject.Length > 0)
            {                
                for (int i = 0; i < mementoObject.Length; i++)
                {
                    _mementos.Add(new TimeUnit(mementoObject[i].transform,
                        mementoObject[i].GetComponent<Rigidbody>(), recordTime));                    
                }
                Debug.Log($"Найдено {_mementos.Count} mementos");
            }
            else
            {
                Debug.LogError("mementos не найдено");
            }
        }

        public List<IMemento> MementoList 
        {
            get { return _mementos; }
        }
    }
}
