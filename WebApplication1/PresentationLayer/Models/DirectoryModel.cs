using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class DirectoryViewModel : PageViewModel
    {
        public DataLayer.Entities.Directory Directory { get; set; }
        public List<MaterialViewModel> Materials { get; set; }
    }

    public class DirectoryEditModel : PageEditModel
    {
    }
}
