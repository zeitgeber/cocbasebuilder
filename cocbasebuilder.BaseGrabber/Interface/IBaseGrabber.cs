using cocbasebuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocbasebuilder.BaseGrabber.Interface
{
    public interface IBaseGrabber
    {
        void Process();
        List<Building> ParseData();
    }
}
