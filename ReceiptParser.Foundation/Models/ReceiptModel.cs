using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptParser.Module.Models
{
    public class ReceiptModel
    {
        public string locale { get; set; }
        public string description { get; set; }
        public BoundingPoly boundingPoly { get; set; }
        public VertexItem GetVertex(int index)
        {
            return boundingPoly.vertices.Skip(index).Take(1).FirstOrDefault();
        }
    }
}
