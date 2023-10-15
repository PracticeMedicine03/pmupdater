# PracticeMedicine's Updater Install Project
This is where the main install.exe code is.

its disgusting but it works

# Files
- Program.cs - I feel like I dont have to explain this one. This is where all of the command-line arguments and Git shit are.
To point it to your mod's repository, go to around line 75 and inside of the static void InstallMod function around line 94
replace `https://github.com/Daisreich/tf2i` with your mod's repository link (for example: https://github.com/YourUser/your_mod_repo),
and also replace ``\\tf2i`` with your mod's directory (for example: MyMod or mymod), you can replace some `Console.WriteLine` shit
mentioning "EF2". I would recommend changing it to avoid confusion.
