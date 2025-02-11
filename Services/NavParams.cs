namespace Alloy_Calc.Services
{
    public struct NavParams
    {
        public string Name { get; set; }
        public string[] Metals { get; set; }
        public int[] Mins { get; set; }
        public int[] Maxs { get; set; }

        public NavParams() 
        {
            Name = "debug";
            Metals = [];
            Mins = [];
            Maxs = [];
        }
    }
}
