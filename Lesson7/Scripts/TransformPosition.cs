using UnityEngine;

namespace Asteroids
{
    public static class TransformPosition
    {
        private static Vector3 _leftBot;
        private static Vector3 _rightTop;
#region properties
        public static float MinX
        {
            get { return _leftBot.x; }
        }

        public static float MaxX
        {
            get { return _rightTop.x; }
        }

        public static float MinY
        {
            get { return _leftBot.y; }
        }

        public static float MaxY
        {
            get { return _rightTop.y; }
        }
#endregion
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
            float minX = MinX - deltaWidht;
            float minY = MinY - deltaHeight;
            float maxX = MaxX + deltaWidht;
            float maxY = MaxY + deltaHeight;

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
