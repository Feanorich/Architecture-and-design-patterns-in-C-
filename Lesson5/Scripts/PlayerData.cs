using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "New PlayerData", menuName = "Player Data", order = 51)]
    public class PlayerData : ScriptableObject
    {
        [Header("Мобильность")]
        [SerializeField] public float Speed;
        [SerializeField] public float Acceleration;
        [SerializeField] public float Hp;
        [Header("Оружие")]
        [SerializeField] public Rigidbody2D Bullet;        
        [SerializeField] public float Force;
        [SerializeField] public float LifeTime;
    }
}
