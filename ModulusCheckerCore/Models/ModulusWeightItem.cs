using ModulusCheckerCore.Business.Entities;

namespace ModulusCheckerCore.Models
{
    public class ModulusWeightItem
    {
        public double SortCodeStart { get; set; }

        public double SortCodeEnd { get; set; }

        public ModulusCalculationType ModulusCalculationType { get; set; }

        public int[] Weight { get; set; }

        public int? Exception { get; set; }
    }
}