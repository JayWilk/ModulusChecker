using ModulusCheckerCore.Business.Entities;

namespace ModulusCheckerCore.Models
{
    public class ModulusWeightItem
    {
        public double SortCodeStart { get; set; }

        public double SortCodeEnd { get; set; }

        public ModulusCheck ModulusCheck { get; set; }

        public int[] Weight { get; set; }

        public int Ex { get; set; }
    }
}