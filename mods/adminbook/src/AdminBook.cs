using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.GameContent;

namespace adminbook.src {
	class AdminBookMod : ModSystem {
		public override void Start(ICoreAPI api) {
			base.Start(api);
			api.RegisterItemClass("adminbook", typeof(AdminBookItem));
		}
	}

	class AdminBookItem : ItemBook {

        // public void Transcribe(IPlayer player, string pageText, string bookTitle, int pageNumber, ItemSlot bookSlot) {
        public void Transcribe(IPlayer player, ItemSlot bookSlot) {

            string pageText = "i mean aged firewood is better than fresh ones right\r\nand they wont work in normal firewood recipes\r\nso they would be exclusive as a fuel only";
            string bookTitle = "Firewood";
            string transcribedby = "God";
            int pageNumber = 2;

            ItemSlot matSlot = null;
            player.Entity.WalkInventory((slot) => {
                if(slot.Empty) return true;
                if(slot.Itemstack.Collectible.Attributes?["canTranscribeOn"].AsBool(false) == true && !slot.Itemstack.Attributes.HasAttribute("text"))
                {
                    matSlot = slot;
                    return false;
                }

                return true;
            });

            var paperStack = matSlot.TakeOut(1);
            paperStack.Attributes.SetString("text", pageText);
            paperStack.Attributes.SetString("title", bookTitle);
            paperStack.Attributes.SetInt("pageNumber", pageNumber);
            paperStack.Attributes.SetString("signedby", bookSlot.Itemstack.Attributes.GetString("signedby"));
            paperStack.Attributes.SetString("signedbyuid", bookSlot.Itemstack.Attributes.GetString("signedbyuid"));
            paperStack.Attributes.SetString("transcribedby", transcribedby);
            /*
            paperStack.Attributes.SetString("transcribedbyuid", player.PlayerUID);
            
            paperStack.Attributes.SetString("text", pageText);
            paperStack.Attributes.SetString("title", bookTitle);
            paperStack.Attributes.SetInt("pageNumber", pageNumber);
            paperStack.Attributes.SetString("signedby", bookSlot.Itemstack.Attributes.GetString("signedby"));
            paperStack.Attributes.SetString("signedbyuid", bookSlot.Itemstack.Attributes.GetString("signedbyuid"));
            paperStack.Attributes.SetString("transcribedby", player.PlayerName);
            paperStack.Attributes.SetString("transcribedbyuid", player.PlayerUID);
             */
        }

	}
}
