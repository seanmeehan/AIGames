using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BGE.Scenarios
{
	class Open2 : Scenario
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
		private GameObject origonalFollower;
		private bool changeScene = false;private bool changeScene2= false;		
		public override void Start()
		{
			
			Params.Load("default.txt");
			
			leader = CreateBoid(new Vector3(350, 0, 0), leaderPrefab);
			leader.GetComponent<SteeringBehaviours>().ArriveEnabled = true;
			leader.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = true;
			leader.GetComponent<SteeringBehaviours>().maxSpeed =400;
			leader.GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(700, 30, 80);
			
			
			enemySmall1 = CreateBoid(new Vector3(75, 5, 50), smallEnemyPrefab);
			enemySmall1.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = true;
			enemySmall1.GetComponent<SteeringBehaviours>().WanderEnabled = false;
			enemySmall1.GetComponent<SteeringBehaviours>().SphereConstrainEnabled = true;
			enemySmall1.GetComponent<SteeringBehaviours>().SeparationEnabled = true;
			enemySmall1.GetComponent<SteeringBehaviours>().maxSpeed =9;
			
			
			enemySmall2 = CreateBoid(new Vector3(100, -10, 100), smallEnemyPrefab);
			enemySmall2.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = true;
			enemySmall2.GetComponent<SteeringBehaviours>().WanderEnabled = false;
			enemySmall2.GetComponent<SteeringBehaviours>().SphereConstrainEnabled = true;
			enemySmall2.GetComponent<SteeringBehaviours>().SeparationEnabled = true;
			enemySmall2.GetComponent<SteeringBehaviours>().maxSpeed =9;
			
			
			enemySmall3 = CreateBoid(new Vector3(300, 80, -50), smallEnemyPrefab);
			enemySmall3.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = true;
			enemySmall3.GetComponent<SteeringBehaviours>().WanderEnabled = false;
			enemySmall3.GetComponent<SteeringBehaviours>().SphereConstrainEnabled = true;
			enemySmall3.GetComponent<SteeringBehaviours>().SeparationEnabled = true;
			enemySmall3.GetComponent<SteeringBehaviours> ().maxSpeed = 9;
			
			enemyLarge1 = CreateBoid(new Vector3(130, -50, 105), largeEnemyPrefab);
			enemyLarge1.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = true;
			enemyLarge1.GetComponent<SteeringBehaviours>().WanderEnabled = false;
			enemyLarge1.GetComponent<SteeringBehaviours>().SeparationEnabled = true;
			enemyLarge1.GetComponent<SteeringBehaviours>().SphereConstrainEnabled = true;
			enemyLarge1.GetComponent<SteeringBehaviours>().maxSpeed =9;
			
			enemyLarge2 = CreateBoid(new Vector3(300, 10, -60), largeEnemyPrefab);
			enemyLarge2.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = true;
			enemyLarge2.GetComponent<SteeringBehaviours>().WanderEnabled = false;
			enemyLarge2.GetComponent<SteeringBehaviours>().SeparationEnabled = true;
			enemyLarge2.GetComponent<SteeringBehaviours>().SphereConstrainEnabled = true;
			enemyLarge2.GetComponent<SteeringBehaviours>().maxSpeed =9;
			
			origonalFollower = CreateBoid(new Vector3(300, 100, 30), smallEnemyPrefab);
			origonalFollower.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = true;
			origonalFollower.GetComponent<SteeringBehaviours>().PursuitEnabled = true;
			origonalFollower.GetComponent<SteeringBehaviours>().SeparationEnabled = true;
			origonalFollower.GetComponent<SteeringBehaviours>().target = leader;
			origonalFollower.GetComponent<SteeringBehaviours>().maxSpeed =9;
			
			CreateCamFollower(leader, new Vector3(0, 5, -10));


			SetShipToFollowLeader(enemySmall1);
			SetShipToFollowLeader(enemySmall2);
			SetShipToFollowLeader(enemySmall3);
			SetShipToFollowLeader(enemyLarge1);
			SetShipToFollowLeader(enemyLarge2);

			GroundEnabled(false);
			
		}
		
		public override void Update ()
		{
			base.Update ();
			
			float waitTimer = 0;
			
			if (!changeScene && leader.transform.position.x > 200) 
			{
				waitTimer += Time.deltaTime;
				
				Vector3 toEnemy = (origonalFollower.transform.position - leader.transform.position);
				toEnemy.Normalize();
				
				GameObject lazer = new GameObject();
				lazer.AddComponent<Lazer>();
				//offset height as model is not at 0,0
				lazer.transform.position = leader.transform.position;
				lazer.transform.forward = toEnemy;
				
				
				
				
				changeScene =  true;
				
				CreateCamFollower(origonalFollower, new Vector3(0, 5, -10));
				
			}
			
			if (!changeScene2 && leader.transform.position.x > 300) 
			{
				SetShipToFollowLeader(enemySmall1);
				SetShipToFollowLeader(enemySmall2);
				SetShipToFollowLeader(enemySmall3);
				SetShipToFollowLeader(enemyLarge1);
				SetShipToFollowLeader(enemyLarge2);
				changeScene2 = true;
			}
			
			
		}
		
		public void SetShipToFollowLeader(GameObject ship)
		{
			ship.GetComponent<SteeringBehaviours> ().TurnOffAll ();
			ship.GetComponent<SteeringBehaviours>().PursuitEnabled = true;
			ship.GetComponent<SteeringBehaviours>().target = leader;
			ship.GetComponent<SteeringBehaviours>().ObstacleAvoidanceEnabled = true;
			ship.GetComponent<SteeringBehaviours>().SeparationEnabled = true;
			
		}
	}
}

