using Vintagestory.API.Common;
using Vintagestory.API.Common.CommandAbbr;
using Vintagestory.API.Server;
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
            //string command = "adminbook";
            //string description = "edit the adminbook";

            //api.RegisterCommand(command, description, "[edit|give]", adminBookCmd, Privilege.commandplayer);

            var parsers = api.ChatCommands.Parsers;
            api.ChatCommands.Create("adminbook")
            .WithAlias("ab")
            .RequiresPrivilege(Privilege.commandplayer)
            .BeginSubCommand("edit")
                .WithDescription("Edit the adminbook")
                .HandleWith(adminBookEdit)
            .EndSubCommand()
            .BeginSubCommand("get")
                .RequiresPrivilege(Privilege.chat)
                .WithDescription("Give the adminbook to oneself")
                .HandleWith(adminBookGet)
            .EndSubCommand()
            .BeginSubCommand("give")
                .WithDescription("Give the adminbook to a player")
                .WithArgs(parsers.Word("player name"))
                .HandleWith(adminBookGive)
            .EndSubCommand();
        }

        private TextCommandResult adminBookEdit(TextCommandCallingArgs args)
        {
            return TextCommandResult.Success("Command to edit the admin book");
        }

        private TextCommandResult adminBookGive(TextCommandCallingArgs args)
        {
            // if args matches player, give book
            
            return TextCommandResult.Success("Command to give an admin book");
        }

        private TextCommandResult adminBookGet(TextCommandCallingArgs args)
        {
            // if args matches player, give book

            return TextCommandResult.Success("Command to give an admin book to player");
        }


        /*
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
        */

    }
}
