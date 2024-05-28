using System;
using UnityEngine;

namespace TPSGame.Enemy
{
    public class RobberyEnemy : MonoBehaviour
    {
        [Header("Info")] [SerializeField] private float visionRadius;
        [SerializeField] private float shootingRadius;
        [SerializeField] private bool playerInVisionRadius;
        [SerializeField] private bool playerInShootingRadius;
        [SerializeField] LayerMask playerLayer;
        
        
        [Header("Enemy State")]
        [SerializeField] private PatrolState patrolState;
        [SerializeField] private ChaseState chaseState;
        //[SerializeField] private ShootState shootState;


        private GameObject Player;
        private bool isDead = false;
        private EnemyStateContext enemyStateContext;
        

        private void Awake()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            enemyStateContext = new EnemyStateContext(this.transform, Player.transform);
        }

        private void Update()
        {
            if(isDead) return;
            playerInVisionRadius = Physics.CheckSphere(this.transform.position, visionRadius, playerLayer);
            playerInShootingRadius = Physics.CheckSphere(this.transform.position, shootingRadius, playerLayer);

            Debug.Log(playerInVisionRadius +"  "+playerInShootingRadius);
            if (!playerInVisionRadius && !playerInShootingRadius) UpdateState(EState.Patrol);
            if (playerInVisionRadius && !playerInShootingRadius) UpdateState(EState.Chase);
            //if (playerInVisionRadius && playerInShootingRadius) UpdateState(EState.Shoot);

            enemyStateContext.CurrentState.UpdateState();
        }
        
        /// <summary>
        /// 현재 상태를 받아 상태별 script에서 에니메이션을 실행하는 함수
        /// </summary>
        /// <param name="eState"></param>
        private void UpdateState(EState eState)
        {
            switch(eState){
                case EState.Patrol:
                    enemyStateContext.Transition(patrolState);
                    break;
                case EState.Chase:
                    enemyStateContext.Transition(chaseState);
                    break;
                /*case EState.Shoot:
                    enemyStateContext.Transition(shootState);
                    break;*/

            }
        }
    }
}