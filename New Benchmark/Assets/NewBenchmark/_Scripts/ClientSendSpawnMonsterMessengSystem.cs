using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using DOTSNET;
using System.Collections.Generic;
using Unity.Collections;

namespace MyNameSpace_XXXXX
{
    [ClientWorld]
    [UpdateInGroup(typeof(ClientConnectedSimulationSystemGroup))]
    [DisableAutoCreation]
    public class ClientSendSpawnMonsterMessengSystem : SystemBase
    {
        [AutoAssign] protected NetworkClientSystem client;

         
        protected override void OnStartRunning()
        {            
            SpawnMonsterMessage message = new SpawnMonsterMessage(500);
            client.Send(message);   
        }

        protected override void OnUpdate()
        { 

             
        }
    }

}