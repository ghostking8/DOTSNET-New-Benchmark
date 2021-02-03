using System;
using UnityEngine;
using DOTSNET;


namespace MyNameSpace_XXXXX
{
	//需要改名 ClientSendXXXXXMessengSystem
  public class ClientSendSpawnMonsterMessengSystemAuthoring : MonoBehaviour, SelectiveSystemAuthoring
    {
        
        // add system if Authoring is used
        public Type GetSystemType() => typeof(ClientSendSpawnMonsterMessengSystem);

       

    }
}