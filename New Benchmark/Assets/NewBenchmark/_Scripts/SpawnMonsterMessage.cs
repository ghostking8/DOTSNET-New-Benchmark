using DOTSNET;
using Unity.Collections;
using Unity.Mathematics;

namespace MyNameSpace_XXXXX
{
    public struct SpawnMonsterMessage : NetworkMessage
    { 
        public int spawnAmount;
        
        public byte GetID() => 0x55; //需要设定返回值


        //初始化
        public SpawnMonsterMessage(int spawnAmount)
        { 
            this.spawnAmount = spawnAmount;
            
        }
		
		 
        public bool Serialize(ref BitWriter writer) =>           
            writer.WriteInt(spawnAmount)  ;

        public bool Deserialize(ref BitReader reader) =>           
           reader.ReadInt(out spawnAmount)   ;


    }
}