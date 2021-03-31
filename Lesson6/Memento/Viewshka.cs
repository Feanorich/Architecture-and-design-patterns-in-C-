using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memento
{
    public class Viewshka : MonoBehaviour
    {
        private IMemento _mementoController;
        private float _recordTime = 7;
        void Start()
        {
            _mementoController = new TimeController(_recordTime);
        }

        void Update()
        {
            _mementoController.RewindControl();
        }

        void FixedUpdate()
        {
            _mementoController.ControlRecord();
        }
    }
}