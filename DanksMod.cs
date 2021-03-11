using Terraria.ModLoader;
using log4net;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;
using DanksMod;
using DanksMod.UI;
using DanksMod.Items.Weapons.RiftWeapons;
using System;
using System.Collections.Generic;
using System.IO;

namespace DanksMod
{
	public class DanksMod : Mod
	{
		private UserInterface _riftBarUserInterface;
		internal RiftResourceBar RiftBar;
		public DanksMod()
		{

		}
		public override void Load()
		{
			Logger.InfoFormat("{0} Danks Logging", Name);
			if (Main.dedServ)
			{
				// Custom Resource Bar
				RiftBar = new RiftResourceBar();
				_riftBarUserInterface = new UserInterface();
				_riftBarUserInterface.SetState(RiftBar);
			}
		}
		public override void Unload()
		{

		}
		public override void UpdateUI(GameTime gameTime)
		{
			_riftBarUserInterface?.Update(gameTime);
		}
	}
}