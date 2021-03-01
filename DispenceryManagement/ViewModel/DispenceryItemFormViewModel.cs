using DispenceryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DispenceryManagement.ViewModel
{
    public class DispenceryItemFormViewModel
    {
        public IEnumerable<DispenceryType> DispenceryTypes { get; set; }
        public DispenceryItems DispenceryItem { get; set; }
        public string Title
        {
            get
            {
                if (DispenceryItem != null && DispenceryItem.Id != 0)
                    return "Edit Dispencery Item";

                return "New Dispencery Item";
            }
        }
    }
}
