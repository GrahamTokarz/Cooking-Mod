using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CookingMod.NPCs
{
	internal class Cow : ModNPC
	{

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cow");
			Main.npcFrameCount[npc.type] = 7;
			Main.npcCatchable[npc.type] = true;
		}

		public override void SetDefaults() {
			npc.width = 59;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 50;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.npcSlots = 0.5f;
			npc.noGravity = false;
			npc.catchItem = (short)ItemType<CowItem>();
			npc.lavaImmune = false;
			//npc.aiStyle = 0;
      aiType = NPCID.Bunny;
      animationType = NPCID.Bunny;
			npc.friendly = true; 
		}

		public override bool? CanBeHitByItem(Player player, Item item) {
			return true;
		}

		public override bool? CanBeHitByProjectile(Projectile projectile) {
			return true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return 0.1f;
		}



		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0) {
				for (int i = 0; i < 6; i++) {
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 200, 2 * hitDirection, -2f);
					if (Main.rand.NextBool(2)) {
						Main.dust[dust].noGravity = true;
						Main.dust[dust].scale = 1.2f * npc.scale;
					}
					else {
						Main.dust[dust].scale = 0.7f * npc.scale;
					}
				}
			}
		}

		public override bool PreAI() {
			if (Collision.WetCollision(npc.position, npc.width, npc.height)) 
			{
				npc.life = 0;
				npc.HitEffect();
				npc.active = false;
				Main.PlaySound(SoundID.NPCDeath16, npc.position); 
			}
			return base.PreAI();
		}

	}

	internal class CowItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cow");
			Tooltip.SetDefault("'Wow, these things are EVERYWHERE'");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.consumable = true;
			item.width = 59;
			item.height = 40;
			item.noUseGraphic = true;
			item.makeNPC = (short)NPCType<Cow>();
		}
	}
}
