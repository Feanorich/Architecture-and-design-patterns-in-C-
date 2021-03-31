using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Memento
{
    public class TimeController : IMemento
    {
        private IGetMementos _mementoSource;
        private List<IMemento> _mementos;
        private float _recordTime;
        public TimeController(float recordTime = 5f)
        {
            _recordTime = recordTime;
            _mementoSource = new GetMemento(_recordTime);
            _mementos = _mementoSource.MementoList;
        }

        public void RewindControl()
        {
            foreach (var _memento in _mementos)
            {
                _memento.RewindControl();
            }
        }

        public void ControlRecord()
        {
            foreach (var _memento in _mementos)
            {
                _memento.ControlRecord();
            }
        }
    }
}