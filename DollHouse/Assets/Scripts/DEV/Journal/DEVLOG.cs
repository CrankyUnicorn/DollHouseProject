public class DEVLOG  {

    //MOTIVATE THE PLAYER!

    //CREATE THE GAME YOU WANT TO PLAY!

    /*
    23/12/2018
    GAME PITCH #1
    DOOLHOUSE a game but not a single game. It's a sudo-engine, a Frankanstain Monster of a kind. Part of it's
    heavly based in the Visual Noval the other part is a Micro Econommy Simulator of sorts. There are also plans 
    in the future to have othere genders of game influences put in the pot but for now this is it.
    Within the game I plan to make a base/vanilla story to atrack a community of modder and story maker. The 
    vanilla story in the Roaring 20's specially in the city of New Orelans, I took a lot of inspiratin of the 
    event of this epoque, the mafia wars, the dry law, the every day life of the people, the technological 
    revolutions, the fashion, the culture, the vice, the history and many other aspects. But this game is not 
    only one story as I created the game to be able to be edited in many forms.
    One can easly change the story and characters, the epoque, and the building as the rooms and their fuctions
    are easly changed in the editor. One can easly replace the story for another in other settings quite easly.
    This is a game dedicated to the players and fans since it ables replayability and change to its original 
    contend making it every iteration a unique experience. The game also ables players to create their own story 
    from root and share it with the community.
    */

    /*
    23/12/2018
    GAME PITCH #2
    Characters acquisition and management is in DOOLHOUSE imperative. Characters other then providing history
    progression also able game playability and development. They able the player to earn money via production,
    adquire new rooms and upgrades, atract clients and able many other features like enternainment and even other
    characters. In sum characters are the essencial and a assets of ultmost importance in game. Being clients and 
    stock items the main resources. And personal items buff and flavour to the game play. Recapitulating, 
    maintaining your characters loyalty and happiness is the most important thing to win the game. 
    Being so interaction with them is essencial.
     */

    /*
     23/12/2018
     GAME DEVLOG #1
     It's been around 3 months since the beginning of the project and there is still a ton of thing to do.
     I started the DOOLHOUSE idea after making a small node base visual novel with actionScript 2 for flash.
     I started working with Unity in Version 3.6. but I didn'know much about C# or the workings of Unity and 
     after some time messing around and having problems understanding how load and save works, what the hell
     was a class and that, I quited. I was used to code monolith scripts, something that came from the first
     actionScript. So when I restarted using Unity I decided that I would take the time and study before hand.
     So I invested a lot of time learning and relearning, understanding the fundamental bases of programming,
     finding ways to achive a nice code architecture, to clean and organize code and best practices in general.

     I started the project with a simple data structure based in simple classes and found a way to save and
     load them. I picked XML but I could picked JSON, this choice was based in the mount of data possible to
     store under XML and nothing else. I know that would be best to use binary but I found it a bit umpractical
     for prototyping and testing since I didn't undestud or trusted this method.
     After that I went ahead and constructed an editor to populate the data structure and a displayer to show
     the result in game. Easy stuff and only a few set backs, it only took me a month to learn and to do so.
     I started then investing time in the front end and menus and was a bit tricky with Unity UI. 
     After that I invested in the other part of the game other then the Visual Noval part the Simulation part 
     was a bit hazy still and I was very unsure the way to go.

     As they say, plan ahead but don't get stuck, I already know that I wanted to do something like a doolhouse
     or as many call it Ant Farm View a Vertical Parallel Cut of the world like a plataformer but focused in 
     a turn base sim and not a action plataformer game with a one character that you control. 
     I love turn base games but I don't like the feeling of it being static.
     In other words I imagine it like being a momment between two diferent times where there is space and time
     and not a static sequencial slice of something. So I decided to give it a feeling of real time by posting
     events in sequence and with some delay even so they already happen, but the player is only gradually
     informed during each turn. If the player decided to advance the results of passive actions are not lost.
     
     In other words I didn't expected this project to extend so much as it did. I thought that it would grow so
     much exponentially that it did. Specilly taking diferent aprouches and changes in the game design a lot. 
     The very first steps where easy and fast but after some reformulations the game had it first emergence.
     New features needed new architectures and so things got a bit more complex. Changes got to be made from the 
     base up, specially around the data structure. Was a nice learning processes since this the first really 
     complex game made by me. Now I got to push on and end the base features. 
     About the front end I still kind of hate the Unity UI and tried to IMGUI that I find much better but even
     so have less features the the regular UI. Scripting for UI is so different and messy compared to regular 
     coding, is dificult to make it clean and nice I guess Unity should have best practrices guide for that.
     Sometimes I feel like I'm not making the best choices but I guess I have to live with then, maybe in the 
     future I will notice them and make a changes to the code. Later on I plan making a LUA interface to make 
     the game fully moddable but that a diferent level from my actual skills.
     I feel that in the front end things got a bit negleted but I prefere do develop all the structure first 
     then adventure myself to do it right now.
     Even thoung I think I got lucky not not to have myself stuck or lost in the coding.
     I think that's great for some one with my level of experience to be able to create something like this. 
     
     Unity and Unity community are great, there are tons of contend being in tutorial, videos, manuals. I got 
     to say they been of great help.

     If you are reading this thank you for your interest I hope to post more content in the future if not the
     first playable Alphas soon.
     */

    /*
     5/1/2019
     GAME DEVLOG #2
     Growing Pain
     Notice I have a lot of information on the rear end that needs to be displayed to the player and as well to 
     me in the Development phase. Since there is a lot of dynamics running in the background like item and client
     generation I need to see what going on and be sure everything is running smoothly.

     So I been implementing new information display modules UI to inform the player of what's going on while on the 
     Game Scape. And also implemented a ton of Game Dev tools for Debuging and Testing. 
     
     This was a painfull week solving some annoying Bugs that are creeping around and new ones with the new Game 
     Info Modules. Yes I know, development is slowing a bit down since the spectrum of what is to be done grows 
     exponentially and since with the festivities I found little time to work on the project. 
     
     In the short future I hope to tie up most of the loose ends and start doing some art and story since those 
     are the field that are a bit negleted in the development. I have some character development done, story wise,
     but still need to research a little bit more to put the story in the right contect. 
     I hope to get two books about New Orleans Storyville soon, so I can have a good reference to the story.
     About the character I still not sure if Antrophomorphics are the way to go but I would like to be able to do 
     both version since fluffy character would be super cute.

    About the music I think I'm going Electro Swing for sure and probably have to outsource that service as well 
    as for sounds effects since I don't have the skills requierd. Also I think is the best option financially 
    since I hope to be able to get some fund via Patreon or Kickstarter for that. I think 1000€ should cover those
    expenses for the royalties for at least 20 tracks but lets see if I find a game music designer.
     */


    /*
    * TODO LIST
    * DEV TOOLS - TOOLS BOX - 50%
    * DEV TOOLS -BETTER SNIFFER
    *
    * STORY - CHARACTER DEVELOPMENT AND HISTORICAL RESEARCH PART 2
    *
    * EDITOR - SEARCH BAR - 0%
    * EDITOR - Make other CLASSES of STORY visible
    * EDITOR - LIMIT proprietes and values shown
    * EDITOR - Reload After LOAD
    * EDITOR - Dialog Line Conditions Options and Handler - 5%
    * EDITOR - Adapting new architecture reformulations to EDITOR
    *
    * OPTIONS - OPTIONS MENU - 0%
    * CHARACTERS - Animation - TO BE DEFINED STILL - 0%
    * CHARACTERS - DESIGN - 1%
    * CHARACTERS - EXPRESSIONS - 0%
    * LOGO - REMAKE AND RENAME
    * BUILDING DESIGN - 20%
    * ROOM DESIGN - 2%
    * BACKGROUND DESIGN - 1%
    * MUSIC AND SOUND - OUTSOURCING - GET FUNDS
    * MINI GAMES - 0%
    *
    * CODE - GENERAL 33%
    * CODE - MODIFIERS and BUFFS SYSTEM
    * CODE - MOODING EXTENTIONS FOR LUA 
    *
    * GAME - GAME MODES - VISUAL NOVEL only... - Parametters Implemented MISSING LOGIC
    * GAME - DIALOG TYPE PROPRIETY on STORY trigger or on DEMAND triggered 
    * GAME - DIALOG TYPE LOGIC AND INTERFACE APPLIED 
    * GAME - Apply logic to CLASS STORY - 50%
    * GAME - Apply CLAMPING int32 values and deny some negatives values to CLASS STORY - 5%
    * GAME - Create Descriptions on for proprieties so they can be self explanatory in the editor - 0%
    * GAME - Make Main CHARACTER a character so can be used in game also
    *
    * UI - Inner Shadow on Dialog Box 
    * UI - On mouse click right button make Dialog Box transparent
    *
    * SAVELOAD - Ask to confirm LOAD or SAVE
    * SAVELOAD - Dedicated Slot for THE HOUSE OF THE RISING SUN
    *
    * SIM - RIVALS Envy Hate Retribution system dynamics implementation
    * SIM - LIMIT how many actions can be made in a tick for main character - PONDERING
    * SIM - FACTIONS AND TROUBLE MAKERS
    * SIM - Ask to confirm ROOM DECONSTRUCTION - NEEDED
    * SIM - Apply ENTERTAINMENT parameters and dynamics with SHOWS showbuisness
    * SIM - Apply SERVICES for prostitutions and what not
    * SIM - Start Dialog with NPC and CHARACTERS
    * SIM - REPUTATION AND NOTORIATY they fall with time - 
    * SIM - ROOM need repairs from time to time: apply degradation rate and misshapes to rooms - 
    * SIM - UTILITIES BUILLS: GAS, ELECTRICITY, WATER - PONDERING 
    * SIM - RANDOM EVENTS to boost or lower moral
    * SIM - INFOBOX have CHARACTER pick ROOM - DONE!
    * SIM - BETTER SELECTED OBJECT CLASS and parsing to INFOBOX - DONE!
    * SIM - EVENT LISTING: Created items, Clients Satisfaction, Ill or Fatigated Characters... - PARTIALLY DONE!
    * SIM - BETTER STATUS BAR WITH DROPDOWN MENU left upper corner
    * SIM - BETTER CLOUD SYSTEM
    * SIM - BETTER SKY
    * SIM - RAW MATERIALS BUY VS PRODUCTION COST - PONDERING
    *
    * GAME TWEEK - 5%
     */


    //LOOK FOR //CHANGE THIS! comment on code to know what to needs to be modified


    /*
     BUGS LIST
    * GAME SCAPE - MINOR BUG - INFOBOX - selector list button and add button doesn't work over building - SOLVED
    * GAME SCAPE - BUG - STATUS BOX exeptions - SOLVED
    * CLASS SCRIPT - BUG - INT32 lenght clamping needed - 
    * GAME SCAPE SIM - ITEMS not being produced over then 1 - SOLVED
    * GAME SCAPE - MOVEMENT - CHARACTER - BUG -Ascending movement pattern - SOLVED
    * GAME INFO MARQUEE - Strange behaviour with listing with 5 and 6 members 
    * INFO - duplicated output of items in stock but not on the story file - SOLVED
     */


    /*LOG 25/12/2018
    * Added some more Clients Types
    * Rechecked Client Dynamics
    * Solved InfoBox movement bug
    * Blocked Raycasting and Time Advancement on information panels with delegates
    * Inserted Money Dynamics with clients
    * Added Resilience on Clients
    * Debuging
     */

    /*LOG 5/1/2019
     * Implementation of Game Info Marquee for tumbler information
     * Connected Game Info Maquee to client list
     * Debuging
     */

    /*LOG 6/1/2019
     * Bug fixes on client happiness and refinements
     * Implemented Nick Name Propriatys
     * Solved Small Bug with WarningWindow
     * Worked on Story
     */

    /*LOG 8/1/2019
     # Solved Small Bugs
     # Worked in the Info Marque.
     # Implemented Sound and Music
     */

    /*LOG 10/1/2019
     * Implementation of Close and Open Building to Public
     * Implementation of Room Repair level and logic, still need UI
     * Implementation of Stamina/Rest/Incapacitation Mechanics, still needs UI to use rest
     * Implementation of Kickout clients
     */

    /*LOG 13/1/2019
     * Created Room Catgories: PRODUCTION, SERVICES, SELLS, ENTERTAINMENT
     * Implementation Selling goods if selling Room exist and is manned
     * Implementation of Selling Dynamics based of workers and worker proefency 
     * Worked to reformulate the ObjType handler WIP
     */

    /*LOG 22/1/2019
     * Implementation of room repairing Interface
     * Able the unlocking room methods and Interface and slot change to other type of room
     * Changed Happiness calculation on clients
     * Able to Rest and TimeOff on Characters and Interface of the same
     * Corrected Display of Opening Building and Kicking out clients
     * Initial implementation of Room Construction, Deconstruction and Upgrading
   */

    /*LOG 26/1/2019
     * Solved Code Reformulation related bug
     */

    /*LOG 3/2/2019
     * Improving Editor
     */
}




