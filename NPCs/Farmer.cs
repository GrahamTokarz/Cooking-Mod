using System;
using System.Collections.Generic;
using CookingMod.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;

namespace CookingMod.NPCs
{
	[AutoloadHead]
	public class Farmer : ModNPC
	{
		// public override string Texture => "CookingMod/NPCs/Farmer";

		public override bool Autoload(ref string name) {
			name = "Farmer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 8;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Merchant;
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}

				foreach (Item item in player.inventory) {
					if (item.type == mod.ItemType("EssenceOfCreature")) {
						return true;
					}
				}
			}
			return false;
		}

		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(5)) {
				case 0:
					return "Hickory";
				case 1:
					return "Richard";
				case 2:
					return "Carl";
				case 3:
					return "Billy";
				default:
					return "Ferdinand";
			}
		}

		public override void FindFrame(int frameHeight) {
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}


		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you remind " + Main.npc[partyGirl].GivenName + " that she still has my shotgun?");
			}
			chat.Add("I'm pretty sure my cows keep escaping.");
			chat.Add("Make it snappy. I've got work to do.");
			chat.Add("I've heard legend of a giant cow that's turned carnivore. Or maybe I saw it.. I can't remember");
			chat.Add("Oh good, a sl... worker. Grab a shovel and start helping.");
			chat.Add("Where are you going with that money? Come and give me some of that!", 0.1);
			return chat; 
		}


		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "Animals";

		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				shop = true;
			}
			else {
				string[] animalCoins = new string[] {"Cow"};
				List<string> avAnimals = new List<string>();
				for(int a = 0; a < animalCoins.Length; a++){
					if (Main.LocalPlayer.HasItem(mod.ItemType(animalCoins[a] + "Coin"))) avAnimals.Add(animalCoins[a]);
				}
				if (avAnimals.Count > 0){
					var animal = Main.rand.Next(avAnimals.Count);
					var animalName = avAnimals[animal];
					Main.LocalPlayer.inventory[Main.LocalPlayer.FindItem(mod.ItemType(animalName + "Coin"))].TurnToAir();
					Main.npcChatText = "I spawned a " + (animalName.ToLower()) + " for a " + animalName.ToLower() + " coin!";
					NPC.NewNPC((int)npc.Left.X, (int)npc.Bottom.Y, mod.NPCType(animalName));
				}
				else {
					Main.npcChatText = "If you have animal coins, I can spawn that animal for you.";
				}
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(mod.ItemType("CocoaSeeds"));
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Sickle);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Hay);
			nextSlot++;
			// if (Main.LocalPlayer.HasBuff(BuffID.Milked)) {
			// }

			// if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>().ZoneExample && !ExampleMod.exampleServerConfig.DisableExampleWings) {
			// 	shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleWings"));
			// 	nextSlot++;
			// }

			// if (Main.moonPhase < 2) {

			// }
			// else if (Main.moonPhase < 4) {

			// }
			// else if (Main.moonPhase < 6) {

			// }
			// else {
			// }
		}

		public override void NPCLoot() {
		}


		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = 93;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}
