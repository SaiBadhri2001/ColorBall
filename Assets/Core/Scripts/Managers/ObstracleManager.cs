using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheColorBall.Core
{
    public class ObstracleManager : MonoBehaviour
    {
        public static ObstracleManager Instance;
        void Awake()
        {
            Instance = this;
        }
        public int ObstracleHealthSetter(ObstracleType obstracleType)
        {
            int _tempHealth = 0;
            switch (obstracleType)
            {
                case ObstracleType.Hard:
                    {
                        _tempHealth = 100;
                        break;
                    }
                case ObstracleType.Meduim:
                    {
                        _tempHealth = 60;
                        break;
                    }
                case ObstracleType.Sticky:
                    {
                        _tempHealth = 30;
                        break;
                    }
            }
            return _tempHealth;
        }
    }
    public enum ObstracleType
    {
        Hard,
        Meduim,
        Sticky
    }
}