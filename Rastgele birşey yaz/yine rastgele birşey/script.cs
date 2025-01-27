using UnityEngine; //You'll probably need this...

namespace Mod
{
    public class Mod
    {
        public static void Main()
        {
            // register item to the mod registry
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
                    NameOverride = "Karakteri ismi", //new item name with a suffix to assure it is globally unique
                    DescriptionOverride = "Karakteri açıklaması", //new item description
                    CategoryOverride = ModAPI.FindCategory("Entities"), //new item category
                    ThumbnailOverride = ModAPI.LoadSprite("Thumb.png"), //new item thumbnail (relative path)
                    AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
                    {
                        //load textures for each layer (see Human textures folder in this repository)
                        var skin = ModAPI.LoadTexture("Skin.png");
                        var flesh = ModAPI.LoadTexture("Flesh.png");
                        var bone = ModAPI.LoadTexture("Bone.png");

                        //get person
                        var person = Instance.GetComponent<PersonBehaviour>();

                        //use the helper function to set each texture
                        person.SetBodyTextures(skin, flesh, bone, 1);

                        //change procedural damage colours if they interfere with your texture (rgb 0-255)
                        person.SetBruiseColor(86, 62, 130); //main bruise colour. purple-ish by default
                        person.SetSecondBruiseColor(154, 0, 7); //second bruise colour. red by default
                        person.SetThirdBruiseColor(207, 206, 120); // third bruise colour. light yellow by default
                        person.SetRottenColour(202, 199, 104); // rotten/zombie colour. light yellow/green by default
                        person.SetBloodColour(108, 0, 4); // blood colour. dark red by default. note that this does not change decal nor particle effect colours. it only affects the procedural blood color which may or may not be rendered
                    }
                }
            );
        }
    }
}