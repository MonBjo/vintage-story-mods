using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace adminbook.src 
{
	class AdminBookMod : ModSystem 
    {
		public override void Start(ICoreAPI api) 
        {
			base.Start(api);
			api.RegisterItemClass("adminbook", typeof(AdminBookItem));
		}
	}

	class AdminBookItem : ItemBook 
    {
		// Some code here maybe?
        // TODO: Create a player friendly command to get an adminbook
        // TODO: Make sure the book can't be used as fuel! 
        // TODO: figure out how to populate the '/help adminbook' command
	}

    public class Command : ModSystem 
    {
        public override bool ShouldLoad(EnumAppSide side) 
        {
            return side == EnumAppSide.Server;
        }

        public override void StartServerSide(ICoreServerAPI api) 
        {
            base.StartServerSide(api);
            string command = "adminbook";
            string description = "edit the adminbook";

            api.RegisterCommand(command, description, "[edit|give]", adminBookCmd, Privilege.commandplayer);
        }

        private void adminBookCmd(IServerPlayer player, int groupId, CmdArgs args) 
        {
            //ItemStack adminbookItem = new ItemStack(3042, ItemBooks, 1, TreeAttribute stackAttributes, IWorldAccessor resolver);
            ItemStack adminbookItem = new ItemStack();

            string firstArgument = args.PopWord();
            string secondArgument = args.PopWord();
            int maxPageCount = 10;
            

            if(firstArgument == "edit")
            {
                player.SendMessage(groupId, "Edit the adminbook", EnumChatType.Notification);
                // var dlg = new GuiDialogEditableBook(adminbookItem, api as ICoreClientAPI, maxPageCount);

            } 
            else if(firstArgument == "give")
            {
                if(secondArgument == null)
                {
                    player.SendMessage(groupId, "Give one adminbook to yourself" + secondArgument, EnumChatType.Notification);
                    // TODO: Give a adminbook to yourself
                }
                else
                {
                    player.SendMessage(groupId, "Give one adminbook to " + secondArgument, EnumChatType.Notification);
                    // TODO: Give a adminbook to targeted player
                }
            } 
            else
            {
                player.SendMessage(groupId, "Info about the adminbook \n will this create a new line?", EnumChatType.Notification);
                // TODO: Write some info about the mod / commands
            }
        }
    }
}
