using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CookingMod.Items
{
	public class Hay : GlobalItem
	{
		public override void SetDefaults(Item item) {
			if (item.type == ItemID.Hay) {
				item.value = Item.buyPrice(copper: 50);
			}
		}
	}
}