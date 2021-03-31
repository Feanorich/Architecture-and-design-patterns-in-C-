using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Memento
{
    public class TimeUnit : IMemento
    {
        private float _recordTime;
        private List<PointInTime> _pointsInTime;
        private Rigidbody _rb;
        private Transform _transform;
        private bool _isRewinding;

        public TimeUnit(Transform transform, Rigidbody rb, float recordTime = 5f)
        {
            _pointsInTime = new List<PointInTime>();
            _transform = transform;
            _rb = rb;
            _recordTime = recordTime;
        }

        public void RewindControl()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartRewind();
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                StopRewind();
            }
        }

        public void ControlRecord()
        {
            if (_isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }

        private void Rewind()
        {
            if (_pointsInTime.Count > 1)
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }

        private void Record()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }

            _pointsInTime.Insert(0, new PointInTime(_transform.position, _transform.rotation, _rb.velocity, _rb.angularVelocity));
        }

        private void StartRewind()
        {
            _isRewinding = true;
            _rb.isKinematic = true;
        }

        private void StopRewind()
        {
            _isRewinding = false;
            _rb.isKinematic = false;
            _rb.velocity = _pointsInTime[0].Velocity;
            _rb.angularVelocity = _pointsInTime[0].AngularVelocity;
        }
    }
}
