using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BGE.States;

namespace BGE.Scenarios
{
	class SecondScene : Scenario
	{
		
		public override string Description()
		{
			return "Path Following Demo";
		}
		static Vector3 initialPos = Vector3.zero;
		
		private GameObject enemySmall1;
		private GameObject enemySmall2;
		private GameObject enemySmall3;
		private GameObject enemyLarge1;
		private GameObject enemyLarge2;
		private GameObject enemyLarge3;
		private GameObject enemyLarge4;
		private GameObject alliSmall1;
		private GameObject alliSmall2;
		private GameObject alliSmall3;
		private GameObject alliSmall4;
		private GameObject alliLarge1;
		private GameObject alliLarge2;
		private GameObject alliLarge3;
		private GameObject origonalFollower;
		bool updateScene=false;
		float timeShot = 0;
		
		public override void Start()
		{

			//GameObject Planet = CreateBoid (new Vector3 (1000, 0, 0), planet);
			leader = CreateBoid(new Vector3(-100, 10, 0), leaderPrefab);
			leader.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			leader.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = true;
			leader.GetComponent<SteeringBehaviours>().maxSpeed =200;
			leader.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(150, 10, 0);
			
			
			enemySmall1 = CreateBoid(new Vector3(-125, 0, 0), smallEnemyPrefab);
			enemySmall1.GetComponent<SteeringBehaviours>().ArriveEnabled = true;

					
			
			
			enemySmall2 = CreateBoid(new Vector3(-125, 50, -50), smallEnemyPrefab);
			enemySmall2.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			enemySmall2.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(100, 50, -50);
						
			enemySmall3 = CreateBoid(new Vector3(-125, 50, 50), smallEnemyPrefab);
			enemySmall3.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			enemySmall3.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(100, 30, 80);

			enemyLarge1 = CreateBoid(new Vector3(-125, -50, 100), largeEnemyPrefab);
			enemyLarge1.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			enemyLarge1.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(100, -50, 100);
						
			
			enemyLarge2 = CreateBoid(new Vector3(-125, -50, -100), largeEnemyPrefab);
			enemyLarge2.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			enemyLarge2.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(100, -50, -100);

			alliSmall1 = CreateBoid(new Vector3(200, -50, -75), smallAllyPrefab);
			alliSmall1.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			alliSmall1.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(100, -50, -75);

			alliSmall2 = CreateBoid(new Vector3(200, -50, -125), smallAllyPrefab);
			alliSmall2.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			alliSmall2.GetComponent<SteeringBehaviours> ().seekTargetPos = new Vector3 (100, -50, -125);

			alliSmall3 = CreateBoid(new Vector3(200, 50, 50), smallAllyPrefab);
			alliSmall3.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			alliSmall3.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(90, 50, 50);

			alliSmall4 = CreateBoid(new Vector3(200, 50, 100), smallAllyPrefab);
			alliSmall4.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			alliSmall4.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(90, 50, 100);

			alliLarge1 = CreateBoid(new Vector3(200, 0, 0), largeAllyPrefab);
			alliLarge1.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			alliLarge1.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(90, 0, 0);

			alliLarge2 = CreateBoid(new Vector3(200, -25, -100), largeAllyPrefab);
			alliLarge2.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			alliLarge2.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(90, -25, -100);

			alliLarge3 = CreateBoid(new Vector3(200, 75, 75), largeAllyPrefab);
			alliLarge3.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			alliLarge3.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(90, 75, 75);


		
			CreateCamFollower(leader, new Vector3(0, 5, -10));
			
			GroundEnabled(false);
			
		}
		
		public override void Update ()
		{
			base.Update ();
			Shoot (leader, alliLarge1);
			Shoot (alliLarge2, enemyLarge1);
			Shoot (enemyLarge3, alliSmall2);



							
				
				
		}
			


		public void Shoot(GameObject shipLeader,GameObject shooter)
		{
			float range = 50.0f;
			timeShot += Time.deltaTime;
			float fov = Mathf.PI / 4.0f;

			
			Vector3 toEnemy1 = (shipLeader.transform.position - shooter.transform.position);
			toEnemy1.Normalize();
			
			if (timeShot > 0.5f)
			{
				GameObject lazer = new GameObject();
				lazer.AddComponent<Lazer>();
				lazer.transform.position = shooter.transform.position;
				lazer.transform.forward = shooter.transform.forward;
				timeShot = 0.0f;
				
				
			}
		}
	}
}
	
	