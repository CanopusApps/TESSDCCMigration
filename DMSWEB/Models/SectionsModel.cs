using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMSWEB.Models
{
    public class SectionsModel
    {
        public SectionsModel()
        {
            SectionList = new List<SelectListItem>();
        }

        [DisplayName("Sections")]
        public List<SelectListItem> SectionList
        {
            get;
            set;
        }
    }
}