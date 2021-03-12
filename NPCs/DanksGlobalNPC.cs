using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DanksMod.NPCs
{
    public class DanksGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool burningVoid;

        public override void ResetEffects(NPC npc)
        {
            burningVoid = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (burningVoid)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 3000;
                if (damage < 2)
                {
                    damage = 2;
                }
            }
        }
    }
    }
}
