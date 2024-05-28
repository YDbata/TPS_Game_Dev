using System;
using UnityEngine;

namespace TPSGame.Camera
{
    public class miniMapCamera : MonoBehaviour
    {
        [SerializeField] private Transform player;

        private void Update()
        {
            this.transform.position = new Vector3(player.position.x, 30, player.position.z);
        }
    }
}