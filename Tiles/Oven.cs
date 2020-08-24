using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;

namespace CookingMod.Tiles
{
	public class Oven : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateHeights = new int[] {16, 16};
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Oven");
			AddMapEntry(new Color(0, 20, 20), name);
			dustType = mod.DustType("Sparkle");
			disableSmartCursor = true;
			animationFrameHeight = 36;
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{ 
			if (++frameCounter >= 13)
			{
				frameCounter = 0;
				frame = ++frame % 12;
			}
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 2 : 2;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("Oven"));
		}
	}
}
