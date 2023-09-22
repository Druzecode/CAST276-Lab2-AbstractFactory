using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceComponents.Factories
{
    public interface IFactory
    {
        public IProduct CreateCase();
        public IProduct CreateCharger();
        public IProduct CreateScreenProtector();
    }
}
