﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using FargowiltasSoulsDLC.Thorium.Enchantments;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class VanaheimForce : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Vanaheim");
            Tooltip.SetDefault(
@"'Holds a glimpse of the future...'
All armor bonuses from Lich, Plague Doctor, and White Dwarf
All armor bonuses from Celestial and Shooting Star
Effects of Lich's Gaze and Ascension Statuette");
            DisplayName.AddTranslation(GameCulture.Chinese, "华纳海姆之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'对未来的一瞥...'
神秘屏障环绕周身
每7次攻击会释放魔法箭
暴击释放长时间的宇宙星光和虚空之焰吞没敌人
按下'特殊能力'键将在光标处召唤无比强大的光环
召唤光环消耗150法力
每拥有一种咒音, 获得以下增益:
增加8%伤害
增加3%移动速度
拥有魔力充能火箭靴和飞升雕像效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 11;
            item.value = 600000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            mod.GetItem("LichEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("WhiteDwarfEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("CelestialEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("ShootingStarEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<LichEnchant>());
            recipe.AddIngredient(ModContent.ItemType<WhiteDwarfEnchant>());
            recipe.AddIngredient(ModContent.ItemType<CelestialEnchant>());
            recipe.AddIngredient(ModContent.ItemType<ShootingStarEnchant>());

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
