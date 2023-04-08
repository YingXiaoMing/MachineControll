using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormControll
{
    public class ItemInfo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public decimal XOffset { get; set; }
        public decimal YOffset { get; set; }

        public decimal PointX => X + XOffset;
        public decimal PointY => Y + YOffset;

        public decimal CenterX => PointX + (decimal)Length / 2;
        public decimal CenterY => PointY + (decimal)Width / 2;
    }
}