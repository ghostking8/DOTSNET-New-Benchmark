using DOTSNET;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace MyNameSpace_XXXXX
{
   
    [DisableAutoCreation]
    public class ServerReceiveSpawnMonsterMessageSystem : NetworkServerMessageSystem<SpawnMonsterMessage>
    {
        // dependencies
        //[AutoAssign] protected NetworkServerSystem server;
        [AutoAssign] protected PrefabSystem prefabs;

        public Bytes16 spawnPrefabId;
        //public int spawnAmount;
        public float interleave;

        //消息体 ClientXXXXXMessage
        protected override void OnMessage(int connectionId, SpawnMonsterMessage message)
        {         
            SpawnAll(connectionId,message.spawnAmount);
        }

        protected override void OnUpdate()
        {
           
        }

        protected override bool RequiresAuthentication()
        {
            return true;
        }

        public void SpawnAll(int connectionId,int spawnAmount)
        {
            // get the ECS prefab
            if (prefabs.Get(spawnPrefabId, out Entity prefab))
            {
                // calculate sqrt so we can spawn N * N = Amount
                float sqrt = math.sqrt(spawnAmount);

                // calculate spawn xz start positions
                // based on spawnAmount * distance
                float offset = -sqrt / 2 * interleave;

                // spawn exactly the amount, not one more.
                int spawned = 0;
                for (int spawnX = 0; spawnX < sqrt; ++spawnX)
                {
                    for (int spawnZ = 0; spawnZ < sqrt; ++spawnZ)
                    {
                        // spawn exactly the amount, not any more
                        // (our sqrt method isn't 100% precise)
                        if (spawned < spawnAmount)
                        {
                            Entity entity = EntityManager.Instantiate(prefab);
                            float x = offset + spawnX * interleave;
                            float z = offset + spawnZ * interleave;
                            float3 position = new float3(x, 0, z);
                            SetComponent(entity, new Translation { Value = position });

                            // spawn it on all clients, owned by no one
                            server.Spawn(entity, connectionId);

                            ++spawned;
                        }
                    }
                }
            }
            else Debug.LogError("Failed to find Spawn prefab. Was it added to the PrefabSystem's spawnable prefabs list?");
        }
    }
}
