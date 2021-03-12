using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using DanksMod;
using DanksMod.Buffs.DoTDebuffs;
using Terraria.ModLoader;

namespace DanksMod
{
    public class DanksPlayer : ModPlayer
    {
        public bool burningVoid;
        public override void ResetEffects()
        {
            burningVoid = false;
        }
        public override void UpdateDead()
        {
            burningVoid = false;
        }

		public override void UpdateBadLifeRegen()
		{
			if (burningVoid)
			{
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
				player.lifeRegen -= 400;
			}
		}
	}
}