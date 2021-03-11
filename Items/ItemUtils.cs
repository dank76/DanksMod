using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DanksMod.Items
{
    public class CalamityRarity
    {
        public const int Turquoise = 12;
        public const int PureGreen = 13;
        public const int DarkBlue = 14;
        public const int Violet = 15;
        public const int HotPink = 16;
        public const int Developer = 16;
        public const int Rainbow = 17;
        public const int RareVariant = 18;
        public const int DedicatedCal = 19;
        public const int Void = 20;
        public const int VoidHM = 22;
        public const int VoidPML = 23;
        public const int DraedonsArsenal = 21;
    }

    public class ItemUtils
    {
        /// <summary>
        ///     Does the dirty work for the item name color. You use this in ModifyTooltips (Check BloodstoneBrick.cs for an
        ///     example)
        /// </summary>
        /// <param name="rare">Use CalamityRarity.[rarity name]</param>
        /// <param name="tooltips">tooltips</param>
        public static void CheckRarity(int rare, List<TooltipLine> tooltips)
        {
            if (rare <= 11)
            {
                return;
            }

            Color color;

            switch (rare)
            {
                case CalamityRarity.Turquoise:
                    color = new Color(0, 255, 200); //Turquoise
                    break;

                case CalamityRarity.PureGreen:
                    color = new Color(0, 255, 0); //Pure Green
                    break;

                case CalamityRarity.DarkBlue:
                    color = new Color(43, 96, 222); //Dark Blue
                    break;

                case CalamityRarity.Violet:
                    color = new Color(108, 45, 199); //Violet
                    break;

                case 16:
                    color = new Color(255, 0, 255); //Hot Pink/Developer
                    break;

                case CalamityRarity.Rainbow:
                    color = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB); //rainbow (no expert tag on item)
                    break;

                case CalamityRarity.RareVariant:
                    color = new Color(255, 140, 0); //rare variant
                    break;

                case CalamityRarity.DedicatedCal:
                    color = new Color(139, 0, 0); //dedicated(patron items) (calamity)
                    break;

                case CalamityRarity.VoidPML:
                    color = new Color(22, 9, 41); //Void pml
                    break;

                case CalamityRarity.VoidHM:
                    color = new Color(60, 17, 97); //void hm
                    break;

                case CalamityRarity.Void:
                    color = new Color(91, 33, 130); //void
                    break;

                case CalamityRarity.DraedonsArsenal:
                    color = new Color(204, 71, 35); //Draedon's Arsenal (Dark Orange)
                    break;

                default:
                    color = Color.White;
                    break;
            }

            foreach (TooltipLine tooltipLine in tooltips)
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = color;
                }
        }
    }
}