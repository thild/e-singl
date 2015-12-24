using System;
using System.Linq;
using Singl.Models;

namespace Singl.Areas.Admin.ViewModels
{
    public class MetadataUICreateViewModel
    {
        public MetadataUICreateViewModel()
        {
        }
        
        public Guid ModelId { get; set; }
        public MetadataUI Metadata { get; set; }
        public IQueryable<MetadataUI> MetadataList { get; set; }
        
    }
}
