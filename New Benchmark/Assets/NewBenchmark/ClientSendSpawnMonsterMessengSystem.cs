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

            //消息内容，由消息结构体 ClientXXXXXMessage 实例化
            SpawnMonsterMessage message = new SpawnMonsterMessage(500);
            client.Send(message);  //发送消息

        }

        protected override void OnUpdate()
        { 

             
        }
    }

}