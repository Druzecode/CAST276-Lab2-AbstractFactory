using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceComponents
{
    public interface IProduct
    {
        public void Draw();
        public string ProductName { get; }
    }
}
