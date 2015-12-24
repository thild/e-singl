using System;
using System.Linq;
using Singl.Models;

namespace Singl.Areas.Admin.ViewModels
{
    public class MetadataUIViewModel
    {
        public MetadataUIViewModel()
        {
        }
        
        public MetadataUI Metadata { get; set; }
        public IQueryable<MetadataUI> MetadataList { get; set; }
    }
}
