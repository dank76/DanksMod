using Terraria.ModLoader;
using log4net;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;
using DanksMod;
using DanksMod.Items.Weapons.RiftWeapons;
using System;
using System.Collections.Generic;
using System.IO;

namespace DanksMod
{
	public class DanksMod : Mod
	{
		public DanksMod()
		{

		}
		public override void Load()
		{
			Logger.InfoFormat("{0} Danks Logging", Name);
			if (Main.dedServ)
			{
				// Custom Resource Bar
			}
		}
		public override void Unload()
		{

		}
	}
}