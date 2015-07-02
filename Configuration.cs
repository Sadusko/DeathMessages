using Rocket.API;

namespace Sample
{
    public class SampleConfiguration : IRocketPluginConfiguration
    {
        public string zombie;
        public string shot;
        public string melee;
        public string melee2;
        public string punch;
        public string punch2;
        public string roadkilling;
        public string explosion;
        public string hunger;
        public string dehydration;
        public string infection;
        public string bleeding;


        public IRocketPluginConfiguration DefaultConfiguration
        {
            get
            {
                return new SampleConfiguration()
                {
                    zombie = "has been eaten alive by a zombie!",
                    shot = "shot and killed",
                    melee = "melee'd",
                    melee2 = "to death!",
                    punch = "has punched" ,
                    punch2 = "to death!",
                    roadkilling = "ran over",
                    explosion = "died due to an explosion!",
                    hunger = "has starved to death!",
                    dehydration = "dehydrated to death!",
                    infection = "became a zombie himself!",
                    bleeding = "has bled to death!",





                };
            }
        }
    }
}