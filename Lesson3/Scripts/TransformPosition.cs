using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    public static class TransformPosition
    {
        private static Vector3 _leftBot;
        private static Vector3 _rightTop;

        static TransformPosition()
        {
            _leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            _rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            Debug.Log($"Углы экрана {_leftBot} - {_rightTop}");
        }

        public static void ScreenControl(Transform _transform,
            float deltaWidht = 0.0f, float deltaHeight = 0.0f)
        {
            Vector3 _position = _transform.position;
            float X = _position.x;
            float Y = _position.y;
            float minX = _leftBot.x - deltaWidht;
            float minY = _leftBot.y - deltaHeight;
            float maxX = _rightTop.x + deltaWidht;
            float maxY = _rightTop.y + deltaHeight;

            ControlCoordinate(ref X, minX, maxX);
            ControlCoordinate(ref Y, minY, maxY);

            _position.x = X;
            _position.y = Y;
            _transform.position = _position;
        }

        public static void ControlCoordinate(ref float N, float minN, float maxN)
        {
            if (N < minN)
            {
                N = maxN;
                Debug.Log($"вышли за {minN}");
            }

            if (N > maxN)
            {
                N = minN;
                Debug.Log($"вышли за {maxN}");
            }
        }        
    }
}
