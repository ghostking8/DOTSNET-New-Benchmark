using DOTSNET;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNameSpace_XXXXX
{

    public class ServerReceiveSpawnMonsterMessageSystemAuthoring : MonoBehaviour, SelectiveSystemAuthoring
    {
        // spawn prefab
        public NetworkEntityAuthoring spawnPrefab;

        // the system
        ServerReceiveSpawnMonsterMessageSystem system =>
            Bootstrap.ServerWorld.GetExistingSystem<ServerReceiveSpawnMonsterMessageSystem>();

        public Type GetSystemType()
        {
            return typeof(ServerReceiveSpawnMonsterMessageSystem);
        }

        // configuration
       // public int spawnAmount = 100;
        public float interleave = 1;

        // apply configuration
        void Awake()
        {
            system.spawnPrefabId = Conversion.GuidToBytes16(spawnPrefab.prefabId);
            //system.spawnAmount = spawnAmount;
            system.interleave = interleave;
        }

    }
}

