﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class SvartalfheimForce : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Svartalfheim");
            Tooltip.SetDefault(
@"'Behold the craftsmanship of the Dark Elves...'
All armor bonuses from Granite, Bronze, and Darksteel
All armor bonuses from Durasteel, Titan, and Conduit
Effects of Eye of the Storm, Champion's Rebuttal, Olympic Torch, and Spartan Sandals
Effects of Spiked Bracers and Rock Music Player
Effects of Ogre Sandals, Crystal Spear Tip, Mask of the Crystal Eye, and Abyssal Shell");
            DisplayName.AddTranslation(GameCulture.Chinese, "瓦特阿尔海姆之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'黑暗精灵的精湛技艺'
增加10%伤害
满血时增加90%伤害减免
免疫高温以及蹒跚者的链球效果
攻击时概率释放闪电链和闪电箭
获得冲刺能力
右键用盾牌防御
攻击时每隔几秒召唤一次流星雨
移动时产生最多5层静电环, 接着产生一个能量泡保护你免受一次伤害
拥有风暴之眼, 充能音箱, 斯巴达音箱的效果
拥有反击之盾, 食人魔凉鞋和尖刺索的效果
拥有贪婪磁铁, 水晶之眼和深渊贝壳的效果
召唤宠物欧米茄核心, 天外来客和生化水母");
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

            mod.GetItem("GraniteEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("BronzeEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("DurasteelEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("ConduitEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("TitanEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "GraniteEnchant");
            recipe.AddIngredient(null, "BronzeEnchant");
            recipe.AddIngredient(null, "DurasteelEnchant");
            recipe.AddIngredient(null, "TitanEnchant");
            recipe.AddIngredient(null, "ConduitEnchant");

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
