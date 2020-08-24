using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameInput;

namespace CookingMod
{
    public class CModPlayer : ModPlayer
    {
        public bool milked = false;
        internal int originalSelectedItem;
        internal bool autoRevertSelectedItem = false;

        public override void clientClone(ModPlayer clientClone)
        {
            CModPlayer clone = clientClone as CModPlayer;
        }
        
        
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (CookingMod.MilkHotkey.JustPressed)
            {
                originalSelectedItem = player.selectedItem;
                autoRevertSelectedItem = true;
                if (player.HasItem(mod.ItemType("ChocolateMilk"))){
                    player.selectedItem = player.FindItem(mod.ItemType("ChocolateMilk"));
                    player.controlUseItem = true;
                    player.ItemCheck(Main.myPlayer);
                }
                else
                {
                    if (player.HasItem(mod.ItemType("Milk"))){
                        player.selectedItem = player.FindItem(mod.ItemType("Milk"));
                        player.controlUseItem = true;
                        player.ItemCheck(Main.myPlayer);
                    }
                }
            }
        }
        public override void ResetEffects()
        {
            milked = false;
        }

        public override void PostUpdate()
        {
            if (autoRevertSelectedItem)
            {
                if (player.itemTime == 0 && player.itemAnimation == 0)
                {
                    player.selectedItem = originalSelectedItem;
                    autoRevertSelectedItem = false;
                }
            }
        }

    }
}
